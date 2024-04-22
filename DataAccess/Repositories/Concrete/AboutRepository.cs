using Common.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.AboutRepository.Concrete
{
    public class AboutRepository : Repository<About> , IAboutRepository
    {

        public AboutRepository(AppDbContext context) :base(context)
        {
            
        }
    }
}
