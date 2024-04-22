using Common.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Concrete
{
    public class OpeningHoursRepository : Repository<OpeningHours> , IOpeningHoursRepository
    {
        public OpeningHoursRepository(AppDbContext context) : base(context) { }
  
    }
}
