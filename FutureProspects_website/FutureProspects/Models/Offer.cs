namespace FutureProspects.Models
{
    public class Offer
    {
        public int Id { get; set; }
        [Required]
        public string OfferTitle { get; set; }
        [Required]
        public string OfferDescription { get; set;}
        [Required]
        public string SkllsRequred { get; set; }
        public int ?Salary { get; set; }
        [Required]
        [ForeignKey("Empolyer")]
        public int EmpolyerId { get; set; }
        public Empolyer Empolyer { get; set; }

    }
}
