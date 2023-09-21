using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }
        [Required]
        public string FacilityName { get; set; }
        [Required]
        public int FacilityCityId { get;set; }
        [Required]
        public int FacilityBuildingId { get; set; }
        [Required]
        public int Floor { get; set; }
        [ForeignKey("FacilityBuildingId")]
        public virtual BuildingLookUp BuildingLookUp { get; set; }
        [ForeignKey("FacilityCityId")]
        public virtual CityLookUp CityLookUp { get; set; }


    }
}
