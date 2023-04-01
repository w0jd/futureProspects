
namespace FutureProspects.Models
{
    [Index(nameof(Email),IsUnique =true)]
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name filed is reqired")]
        [StringLength(maximumLength:100,MinimumLength =2)]
        public string Name{ get; set; }
        [Required(ErrorMessage = "Email filed is reqired")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone filed is reqired")]
        [StringLength(maximumLength: 9, MinimumLength = 9)]
        public int Phone { get; set; }
        
        [StringLength(maximumLength: 100)]
        public string? Adress { get; set; }
    }
}
