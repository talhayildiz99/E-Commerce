using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.StatisticServices
{
    public class Statisticservice : IStatisticservice
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Vendor> _vendorCollection;

        public Statisticservice(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _vendorCollection = database.GetCollection<Vendor>(_databaseSettings.VendorCollectionName);
        }

        public async Task<long> GetVendorCount()
        {
            return await _vendorCollection.CountDocumentsAsync(FilterDefinition<Vendor>.Empty);
        }

        public Task<long> GetCategoryCount()
        {
            return _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                      y.ProductName).Exclude("ProductID");
            var product = await _productCollection.Find(filter)
                                                .Sort(sort)
                                                .Project(projection)
                                                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                      y.ProductName).Exclude("ProductID");
            var product = await _productCollection.Find(filter)
                                                .Sort(sort)
                                                .Project(projection)
                                                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
              new BsonDocument("$group",new BsonDocument
              {
                  {"_id",null },
                  {"averagePrice",new BsonDocument("$avg","$ProductPrice") }
              })
            };
            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var price = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return price;
        }

        public Task<long> GetProductCount()
        {
            return _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
