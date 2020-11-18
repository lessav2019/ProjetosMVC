﻿using Blog.Infra;
using Blog.Models;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DAO
{
    public class PostDAO
    {
        public IList<Post> Lista()
        {
            var lista = new List<Post>();
            using (SqlConnection cnx = ConnectionFactory.CriConexaoAberta())
            {
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "select * from Posts";
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    lista.Add(post);
                }
                
            }
            return lista;
        }
        
        public void Adiciona (Post post)
        {
            using (SqlConnection cnx = ConnectionFactory.CriConexaoAberta())
            {
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "insert into Posts (Titulo, Resumo, Categoria) values (@titulo,@resumo,@categoria)";
                comando.Parameters.Add(new SqlParameter("titulo", post.Titulo));
                comando.Parameters.Add(new SqlParameter("resumo", post.Resumo));
                comando.Parameters.Add(new SqlParameter("categoria", post.Titulo));
                comando.ExecuteNonQuery();
            }
        }
    }
}
