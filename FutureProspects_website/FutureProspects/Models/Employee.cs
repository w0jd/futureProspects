
using System.ComponentModel;

namespace FutureProspects.Models
{
    [Index(nameof(Email),IsUnique =true)]
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name filed is reqired")]
        [StringLength(maximumLength:100,MinimumLength =2)]
        public string Name{ get; set; }
        [Required(ErrorMessage = "Surrname is reqired ")]
        [StringLength(maximumLength: 40)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email filed is reqired")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone filed is reqired")]
        [StringLength(maximumLength: 9, MinimumLength = 9)]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Select Degree ")]
        [StringLength(maximumLength: 10)]
        public string Degree { get; set; }
        [Required(ErrorMessage = "universty reqired ")]
        [StringLength(maximumLength: 60)]
        public string university { get; set; }
        [StringLength(maximumLength: 60)]
        public string? City { get; set; }
        [StringLength(maximumLength: 60)]
        public string? Faculty { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToen { get; set; }
        public DateTime? ResetTokenExpiers { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

    }
}
