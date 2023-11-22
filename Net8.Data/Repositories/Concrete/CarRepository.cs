using Net8.Data.Context;
using Net8.Data.Entities;
using Net8.Data.Repositories.Abstract;

namespace Net8.Data.Repositories.Concrete
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        Net8Context _cnx;
        public CarRepository(Net8Context context) : base(context)
        {
            _cnx = context;
        }
    }
}
