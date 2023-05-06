namespace FutureProspects.Models
{
    
    public class EmployeeOffer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id;
        [Required]
        [ForeignKey("Empolyer")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

    }
}
