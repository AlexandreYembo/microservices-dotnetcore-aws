namespace domain.Models
{
    public class ResetPasword
    {
        public string Username{get;set;}
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}