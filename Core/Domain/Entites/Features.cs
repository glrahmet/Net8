using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Features
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FeatureId {get; set; }   
        public string FeatureName {get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
