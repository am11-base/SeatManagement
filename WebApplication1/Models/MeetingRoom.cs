using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class MeetingRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeetingRoomId { get; set; }
        [Required]
        public string MeetingRoomName { get;set; }
        [Required]
        public int FacilityId { get; set; }
        [Required]
        public int NumberofChairs { get; set; }
        [ForeignKey("FacilityId")]
        public virtual Facility Facility { get; set; }
    }
}
