using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class About :BaseEntity
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }




        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
