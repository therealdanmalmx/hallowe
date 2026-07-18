namespace hallowe_backend.Models.Login
{
    public class LoginResponse
    {
        public bool IsSuccessful { get; set; }
        public string? Errors { get; set; } = null;

        public LoginResponse() { }
        public LoginResponse(bool isSuccessful, string? errors)
        {
            IsSuccessful = isSuccessful;
            Errors = errors;
        }
    }
}