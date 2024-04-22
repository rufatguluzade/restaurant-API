using Business.DTOs.Tag.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Blog.Response
{
    public class BlogResponseDto
    {
        public int Id { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }


   

        public List<TagResponseDto> Tags { get; set; }

    }
}
