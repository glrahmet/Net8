﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class CarDescription : BaseEntity
    { 
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string CarDescriptionName { get; set; }

    }
}
