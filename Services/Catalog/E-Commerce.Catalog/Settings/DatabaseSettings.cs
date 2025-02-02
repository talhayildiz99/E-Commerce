namespace E_Commerce.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string FeatureSliderCollectionName { get; set ; }
        public string TopDiscountCollectionName { get; set ; }
        public string FeatureCollectionName { get; set ; }
        public string VendorCollectionName { get; set ; }
        public string AboutCollectionName { get; set ; }
    }
}
