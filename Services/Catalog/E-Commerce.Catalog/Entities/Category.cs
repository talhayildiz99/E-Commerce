using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
    }
}
