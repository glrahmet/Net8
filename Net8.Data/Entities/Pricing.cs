namespace Net8.Data.Entities
{
    public class Pricing : BaseEntity
    { 
        public string PricingName { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
