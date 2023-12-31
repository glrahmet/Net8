﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
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
