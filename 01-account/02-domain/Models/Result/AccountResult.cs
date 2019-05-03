using System.Collections.Generic;

namespace domain.Models
{
    public class AccountResult
    {
        public bool Succeeded {get; set; }
        public List<ErrorsResult> Errors {get; set; }
        public bool IsLockedOut { get; set; }
        public bool RequiresTwoFactor { get; set; }
        public bool IsNotAllowed { get; set; }
    }
}