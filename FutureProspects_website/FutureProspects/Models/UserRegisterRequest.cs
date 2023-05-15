namespace FutureProspects.Models
{
    public class UserRegisterRequest
    {
        [Required,EmailAddress]
        public string email{ get; set; }
        [Required, MinLength(6)]
        public string password{ get; set; }
        [Required,Compare("Password")]
        public string ConfirmPassword{ get; set; }
        [Required(ErrorMessage = "Name filed is reqired")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string name { get; set; }
        [Required(ErrorMessage = "Surrname is reqired ")]

        [StringLength(maximumLength: 40)]
        public string surname { get; set; }

  
 
        [Required(ErrorMessage = "Phone filed is reqired")]
        [StringLength(maximumLength: 9, MinimumLength = 9)]
        public string phone { get; set; }
        [Required(ErrorMessage = "Select Degree ")]

        [StringLength(maximumLength: 10)]
        public string degree { get; set; }
        [Required(ErrorMessage = "universty reqired ")]

        [StringLength(maximumLength: 60)]
        public string university { get; set; }

        [StringLength(maximumLength: 60)]
        public string? city { get; set; }
        [StringLength(maximumLength: 60)]
        public string? faculty { get; set; }
    }
}
