namespace FutureProspects.Models
{
    public class Empolyer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Company Name filed is reqired")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Email filed is reqired")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone filed is reqired")]
        [StringLength(maximumLength: 9, MinimumLength = 9)]
        public string Phone { get; set; }
        [StringLength(maximumLength: 60)]
        public string? City { get; set; }
        public ICollection<Offer> ?Offer { get; set; }
    }
}
