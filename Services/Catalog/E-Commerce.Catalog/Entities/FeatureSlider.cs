using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace E_Commerce.Catalog.Entities
{
    public class FeatureSlider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureSliderID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
