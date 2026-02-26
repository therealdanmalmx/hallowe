using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.DTOs;
using hallowe_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace hallowe_backend.Services
{
    public class RegisteredParticipantService : IRegisteredParticipantService
    {

    private readonly UserManager<RegistredParticipants> _registeredParticipantManager;

        public RegisteredParticipantService(UserManager<RegistredParticipants> registeredParticipantManager)
        {
            _registeredParticipantManager = registeredParticipantManager;
        }

        public async Task<RegisteredParticipantResponse> RegisteredParticipant(RegisteredParticipantRequest request)
        {
            var newRegisteredParticipant = new RegistredParticipants
            {
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                StreetName = request.StreetName,
                StreetNumber = request.StreetNumber,
                City = request.City,
                PostalCode = request.PostalCode,
                Longitude = request.Longitude,
                Latitude = request.Latitude,
                TimeSlotId = request.TimeSlotId,
                TimeSlots = request.TimeSlots
            };

            var result = await _registeredParticipantManager.CreateAsync(newRegisteredParticipant, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return new RegisteredParticipantResponse(false, errors);
            }

            return new RegisteredParticipantResponse(true);
        }

        // public async Task<IActionResult> _registeredParticipantManager.GetRegisteredParticipants(List<RegistredParticipants> rp)
        // {
        //     return new OkObjectResult(rp);
        // }
    }
}