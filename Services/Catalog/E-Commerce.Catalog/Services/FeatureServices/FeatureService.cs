using AutoMapper;
using E_Commerce.Catalog.Dtos.FeatureDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featureCollection;
        private readonly IMapper _mapper;
        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureCollection = database.GetCollection<Feature>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureID == id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var value = await _featureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(value);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var value = await _featureCollection.Find<Feature>(x => x.FeatureID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(value);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureID == updateFeatureDto.FeatureID, value);
        }

    }
}
