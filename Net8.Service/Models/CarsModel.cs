using Net8.Data.Entities;
using Net8.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Service.Models
{
    public class CarsModel
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
        public virtual List<CarPricing> CarPricings { get; set; }
    }

}
