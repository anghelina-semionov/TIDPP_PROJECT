using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dream_voyage.Domain
{
    public partial class Tour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TourId { get; set; }
        [Required]
        public string TourName { get; set; }
        [Required]
        public string TourHref { get; set; }
        [Required]
        public string TourImage { get; set; }

    }
}
