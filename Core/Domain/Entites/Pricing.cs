﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Pricing : BaseEntity
    { 
        public string PricingName { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}
