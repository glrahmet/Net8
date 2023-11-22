using AutoMapper;
using Net8.Service.AutoMappers;

namespace Net8.UI.Injections
{
    public class MapperInjection
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CarMapper());

            });
            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        }
    }
}
