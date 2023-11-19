using Application.Feature.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.CQRS.Results.AboutResults
{
    public class GetAboutQueryResult : AboutBaseClass
    { 
        public int Id { get; set; }
    }
}
