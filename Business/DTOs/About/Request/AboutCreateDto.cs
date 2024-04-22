using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.About.Request
{
    public class AboutCreateDto
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
