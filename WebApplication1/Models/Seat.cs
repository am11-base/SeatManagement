using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }
        [Required]
        public string SeatName { get; set;}
        [Required]
        public int FacilityId { get; set; }
        public bool IsAssigned { get; set; }

        [ForeignKey("FacilityId")]
        public virtual Facility Facility { get; set;}
    }
}
