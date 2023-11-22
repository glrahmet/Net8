namespace Net8.Data.Entities
{
    public class CarPricing : BaseEntity
    {
       
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PringId { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
