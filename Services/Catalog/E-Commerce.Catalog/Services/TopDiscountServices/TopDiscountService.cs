using AutoMapper;
using E_Commerce.Catalog.Dtos.CategoryDtos;
using E_Commerce.Catalog.Dtos.TopDiscountDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.TopDiscountServices
{
    public class TopDiscountService : ITopDiscountService
    {
        private readonly IMongoCollection<TopDiscount> _topDiscountCollection;
        private readonly IMapper _mapper;
        public TopDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _topDiscountCollection = database.GetCollection<TopDiscount>(_databaseSettings.TopDiscountCollectionName);
            _mapper = mapper;
        }
        public async Task CreateTopDiscountAsync(CreateTopDiscountDto createTopDiscountDto)
        {
            var value = _mapper.Map<TopDiscount>(createTopDiscountDto);
            await _topDiscountCollection.InsertOneAsync(value);
        }

        public async Task DeleteTopDiscountAsync(string id)
        {
            await _topDiscountCollection.DeleteOneAsync(x => x.TopDiscountID == id);
        }

        public async Task<List<ResultTopDiscountDto>> GetAllTopDiscountAsync()
        {
            var value = await _topDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTopDiscountDto>>(value);
        }

        public async Task<GetByIdTopDiscountDto> GetByIdTopDiscountAsync(string id)
        {
            var value = await _topDiscountCollection.Find<TopDiscount>(x => x.TopDiscountID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdTopDiscountDto>(value);
        }

        public async Task UpdateTopDiscountAsync(UpdateTopDiscountDto updateTopDiscountDto)
        {
            var value = _mapper.Map<TopDiscount>(updateTopDiscountDto);
            await _topDiscountCollection.FindOneAndReplaceAsync(x => x.TopDiscountID == updateTopDiscountDto.TopDiscountID, value);
        }
    }
}
