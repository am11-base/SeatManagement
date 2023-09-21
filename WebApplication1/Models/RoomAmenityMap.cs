using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class RoomAmenityMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomAmenityMapId { get; set; }

        [Required]
        public int RoomId { get;set; }
        [Required]
        public int AmenityId { get; set; }
        [ForeignKey("RoomId")]
        public virtual MeetingRoom MeetingRoom { get; set; }
        [ForeignKey("AmenityId")]
        public virtual Amenity Amenity { get; set; }
    }
}
