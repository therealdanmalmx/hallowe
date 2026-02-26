using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hallowe_backend.DTOs
{
    public class RegisteredParticipantResponse
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public RegisteredParticipantResponse()
        {

        }

        public RegisteredParticipantResponse(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
        public RegisteredParticipantResponse(bool isSuccessful, IEnumerable<string>? errors)
        {
            IsSuccessful = isSuccessful;
            Errors = errors;
    }
    }
}