using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        public int id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { set; get; }
        public string Categoria { set; get; }
    }
}
