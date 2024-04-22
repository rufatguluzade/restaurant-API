using Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class AppDbContext :DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        DbSet<About> Abouts { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<BlogTag> BlogTags { get; set; }
        DbSet<Locations> Locations { get; set; }
        DbSet<OpeningHours> OpeningHours { get; set; }

     
    }
}
