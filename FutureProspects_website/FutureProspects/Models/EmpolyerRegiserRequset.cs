﻿namespace FutureProspects.Models
{
    public class EmpolyerRegiserRequset
    {
        [Required(ErrorMessage = "Company Name filed is reqired")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Email filed is reqired")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone filed is reqired")]
        [MinLength(9),MaxLength(80)]
        public string Phone { get; set; }
        [StringLength(maximumLength: 90, MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surrname is reqired ")]
        [StringLength(maximumLength: 40)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "adress is reqired")]
        [StringLength(maximumLength: 90, MinimumLength = 2)]

        public string Adress { get; set; }
        public string? CompadnyDescription { get; set; }
        [Required(ErrorMessage = "a city is reqired ")]
        [StringLength(maximumLength: 90, MinimumLength = 2)]

        public string City { get; set; }
        [Required, MinLength(6)]
        public string password { get; set; }
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
}
