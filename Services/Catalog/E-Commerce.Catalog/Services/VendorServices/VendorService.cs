using AutoMapper;
using E_Commerce.Catalog.Dtos.VendorDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.VendorServices
{
    public class VendorService : IVendorService
    {
        private readonly IMongoCollection<Vendor> _vendorCollection;
        private readonly IMapper _mapper;

        public VendorService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _vendorCollection = database.GetCollection<Vendor>(_databaseSettings.VendorCollectionName);
            _mapper = mapper;
        }

        public async Task CreateVendorAsync(CreateVendorDto createVendorDto)
        {
            var value = _mapper.Map<Vendor>(createVendorDto);
            await _vendorCollection.InsertOneAsync(value);
        }

        public async Task DeleteVendorAsync(string id)
        {
            await _vendorCollection.DeleteOneAsync(x => x.VendorID == id);
        }

        public async Task<List<ResultVendorDto>> GetAllVendorAsync()
        {
            var value = await _vendorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultVendorDto>>(value);
        }

        public async Task<GetByIdVendorDto> GetByIdVendorAsync(string id)
        {
            var value = await _vendorCollection.Find<Vendor>(x => x.VendorID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdVendorDto>(value);
        }

        public async Task UpdateVendorAsync(UpdateVendorDto updateVendorDto)
        {
            var value = _mapper.Map<Vendor>(updateVendorDto);
            await _vendorCollection.FindOneAndReplaceAsync(x => x.VendorID == updateVendorDto.VendorID, value);
        }

    }
}
