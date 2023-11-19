using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class FooterAddres : BaseEntity
    { 
        public string Description { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
    }
}
