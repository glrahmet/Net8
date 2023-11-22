namespace Net8.Data.Entities
{
    public class CarDescription : BaseEntity
    { 
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string CarDescriptionName { get; set; }

    }
}
