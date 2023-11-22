namespace Net8.Data.Entities
{
    public class Brand : BaseEntity
    { 
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
