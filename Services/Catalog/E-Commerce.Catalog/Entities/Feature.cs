using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace E_Commerce.Catalog.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
