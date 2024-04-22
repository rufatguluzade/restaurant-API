using Common.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Concrete
{
    public class LocationRepository : Repository<Locations> , ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context) { }
     
    }
}
