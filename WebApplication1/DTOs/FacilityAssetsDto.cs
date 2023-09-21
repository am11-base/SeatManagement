namespace WebApplication1.DTOs
{
    public class FacilityAssetsDto<T> where T : class
   {
            public int FacilityId { get; set; }
            public IEnumerable<T> Assets { get; set; }
        
    }
}
