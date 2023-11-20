using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS
{
    public class BrandBaseClass
    {
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
