using AutoMapper;
using Microsoft.AspNetCore.Http;
using Net8.Data.UnitOfWork;
using Net8.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Net8.Service.Concrete
{
    public class BaseService : IBaseService
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpAccessor;
        protected string ipAdres { get; set; }
       // protected string kullaniciId { get; set; }
       
        protected string[] roller { get; set; }
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpAccessor)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._httpAccessor = httpAccessor;
            ipAdres = httpAccessor.HttpContext != null ? httpAccessor.HttpContext.Connection.RemoteIpAddress.ToString() : string.Empty;
            roller = new string[0];
            if (httpAccessor.HttpContext != null && httpAccessor.HttpContext.User != null)
            {
                //if (httpAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier) != null)
                //    kullaniciId = httpAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                
                if (httpAccessor.HttpContext.User.FindAll(o => o.Type == ClaimTypes.Role).Any())
                    roller = httpAccessor.HttpContext.User.FindAll(o => o.Type == ClaimTypes.Role).Select(o => o.Value).ToArray();
            }

        }
    }
}
