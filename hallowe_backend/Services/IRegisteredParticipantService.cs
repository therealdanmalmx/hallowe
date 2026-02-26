using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hallowe_backend.DTOs;

namespace hallowe_backend.Services
{
    public interface IRegisteredParticipantService
    {
        Task<RegisteredParticipantResponse> RegisteredParticipant(RegisteredParticipantRequest request);
    }
}