using Net8.Data.Enum;

namespace Net8.Data.Entities
{
    public class Car : BaseEntity
    { 
        public int BrandId { get; set; } 
        public virtual Brand Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageModel { get; set; }
        public int Km { get; set; }
        public TransMissionEnum TransMission { get; set; }
        public byte Seat { get; set; }
        public byte Lungage { get; set; }
        public FuelEnum Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public virtual List<CarFeature> CarFeatures { get; set; }
        public virtual List<CarDescription> CarDescriptions { get; set; }
        public virtual  List<CarPricing> CarPricings { get; set; }
    }
}
