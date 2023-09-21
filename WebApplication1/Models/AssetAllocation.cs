using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class AssetAllocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetAllocationId { get; set; }
        [Required]
        public int AssetId { get;set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int AssetTypeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("AssetTypeId")]
        public virtual AssetLookup AssetLookup { get; set; }
    }
}
