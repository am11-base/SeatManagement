using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services.Implementations
{
    public class AssetLookupService : IAssetLookupService
    {
        private readonly IRepository<AssetLookup> repository;

        public AssetLookupService(IRepository<AssetLookup> repository)
        {
            this.repository = repository;
        }
        public int? GetAssetId(string assetName)
        {
            var asset = repository.GetAll().Where(asset => asset.AssetType.ToLower() == assetName.ToLower()).FirstOrDefault();
            if(asset == null) 
                return null;
            else
                return asset.AssetTypeId;
        }
    }
}
