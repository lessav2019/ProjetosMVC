using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using System.Data.SqlClient;
using Blog.Infra;
using Blog.DAO;

namespace Blog.Controllers
{
    public class PostController : Controller
    {

        private IList<Post> lista;

        public PostController()
        {


            /*this.lista = new List<Post>()
             {
                new Post() { Titulo = "harry", Resumo = "Filosofal", Categoria = "Filme" },
                new Post() { Titulo = "Cassino", Resumo = "007", Categoria = "Filme" },
                new Post() { Titulo = "Monge", Resumo = "Romance", Categoria = "Livro" }
             };*/

        }
        public IActionResult Index()
        {

            PostDAO dao = new PostDAO();
            IList < Post > lista = dao.Lista();
            //var listaDePosts = new List<Post>(lista);

            // ViewBag.Posts = listaDePosts ; outro jeito de mandar a lista
            //return View(listaDePosts);
            return View(lista);
        }

        public IActionResult Novo() // método para adicionar e direcionar
        {
            return View();
        }

        public IActionResult Adiciona(Post post)
        {
            PostDAO dao = new PostDAO();
            dao.Adiciona(post);
            return RedirectToAction("Index");
        }

    }
}
