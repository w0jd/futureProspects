namespace FutureProspects.Models
{
    public class UserLoginRequest
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
