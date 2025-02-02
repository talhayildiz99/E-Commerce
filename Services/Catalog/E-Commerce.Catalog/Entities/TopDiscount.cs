using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace E_Commerce.Catalog.Entities
{
    public class TopDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TopDiscountID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
