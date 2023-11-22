using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Net8.Data.UnitOfWork;
using Net8.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Net8.Service.Concrete
{
    public class CarService : BaseService, ICarService
    {
        private IConfiguration _configuration { get; }
        private readonly IHostingEnvironment _environment;
        public CarService(IUnitOfWork unitOfWork, IMapper mapper,
            IHttpContextAccessor httpAccessor, IConfiguration configuration, IHostingEnvironment environment) : base(unitOfWork, mapper, httpAccessor)
        {
            _configuration = configuration;
            _environment = environment;
        }
      //servis metotları

    }
}
