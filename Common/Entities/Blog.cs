using Common.Constants.Blog;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Blog :BaseEntity
    {
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }


        public BlogType BlogType { get; set; }
        public List<BlogTag> BlogTags { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }



        [NotMapped]
        [MaxLength(3)]
        public List<int> TagIds { get; set; }

    }
}
