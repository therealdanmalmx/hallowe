using hallowe_backend.Data;
using hallowe_backend.Models;
using hallowe_backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity — registers the "Identity.Application" cookie scheme and sets it as default
builder.Services.AddDefaultIdentity<User>(options =>
{

    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Configure Identity's cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.SlidingExpiration = true;              // renews if >50% elapsed
    options.Cookie.MaxAge = options.ExpireTimeSpan; // persist across restarts
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Lax;    // same-site in dev (localhost ports)

    // This is an API: return status codes instead of redirecting to /Account/Login
    options.Events.OnRedirectToLogin = ctx =>
    {
        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = ctx =>
    {
        ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
});

// External providers — no scheme defaults here; Identity's already correct
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
        options.SignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Authentication:Facebook:AppId"]!;
        options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"]!;
        options.SignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddLinkedIn(options =>
    {
        options.ClientId = builder.Configuration["Authentication:LinkedIn:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:LinkedIn:ClientSecret"]!;
        options.SignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddTwitter(options =>
    {
        options.ConsumerKey = builder.Configuration["Authentication:Twitter:ConsumerKey"]!;
        options.ConsumerSecret = builder.Configuration["Authentication:Twitter:ConsumerSecret"]!;
        options.SignInScheme = IdentityConstants.ExternalScheme;
    });

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy => policy
        .WithOrigins("http://localhost:5173")
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IloginService, LoginService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors("Frontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();