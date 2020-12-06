using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dream_voyage.Domain
{
    public partial class UserTour
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTourId { get; set; }
        [Required]
        public int TourId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
