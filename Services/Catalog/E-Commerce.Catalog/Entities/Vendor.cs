using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace E_Commerce.Catalog.Entities
{
    public class Vendor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VendorID { get; set; }
        public string VendorName { get; set; }
        public string ImageUrl { get; set; }
    }
}
