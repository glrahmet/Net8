namespace Net8.Data.Entities
{
    public class Feature
    {
        public int FeatureId {get; set; }   
        public string FeatureName {get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
