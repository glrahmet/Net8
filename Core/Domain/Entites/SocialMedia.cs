using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class SocialMedia : BaseEntity
    { 
        public string SocialMediaName  {get; set;}
        public string SocialMediaIconUrl {get; set;}
    }
}
