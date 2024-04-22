using Common.Constants.Blog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Blog.Request
{
    public class BlogCreateDto
    {
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string Author { get; set; }
    


        public BlogType BlogType { get; set; }




        [NotMapped]
        public IFormFile ImageFile { get; set; }



        [NotMapped]
        [MaxLength(3)]
        public List<int> TagIds { get; set; }
    }
}
