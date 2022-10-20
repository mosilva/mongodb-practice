﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using projetoBlog.Models;
using projetoBlog.Models.Home;

namespace projetoBlog.Controllers
{
    public class HomeController : Controller
    {

        //public async Task<ActionResult> Index()
        //{

        //    //XXX TRABALHE AQUI
        //    // liste as dez mais recentes publicações
        //    // Descomente as linhas abaixo
        //    //var model = new IndexModel
        //    //{
        //    //    PublicacoesRecentes = PublicacoesRecentes
        //    //};

        //    //return View(model);
        //}

        [HttpGet]
        public ActionResult NovaPublicacao()
        {
            return View(new NovaPublicacaoModel());
        }

        [HttpPost]
        public async Task<ActionResult> NovaPublicacao(NovaPublicacaoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var post = new Publicacao
            {
                Autor = User.Identity.Name,
                Titulo = model.Titulo,
                Conteudo = model.Conteudo,
                Tags = model.Tags.Split(' ', ',', ';'),
                DataCriacao = DateTime.UtcNow,
                Comentarios = new List<Comentario>()
            };

            var conn = new AcessoMongoDB();
            await conn.Publications.InsertOneAsync(post);

            return RedirectToAction("Publicacao", new { id = post.Id });
        }

        //[HttpGet]
        //public async Task<ActionResult> Publicacao(string id)
        //{

        //    XXX TRABALHE AQUI
        //     Busque na base MongoDB a publicação pelo ID
        //     Descomente as linhas abaixo
        //    if (publicacao == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var model = new PublicacaoModel
        //    {
        //        Publicacao = publicacao,
        //        NovoComentario = new NovoComentarioModel
        //        {
        //            PublicacaoId = id
        //        }
        //    };

        //    return View(model);
        //}

        //[HttpGet]
        //public async Task<ActionResult> Publicacoes(string tag = null)
        //{

        //    XXX TRABALHE AQUI
        //     Busque as publicações pela TAG escolhida.

        //    return View(posts);
        //}

        [HttpPost]
        public async Task<ActionResult> NovoComentario(NovoComentarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
            }

            //XXX TRABALHE AQUI
            // Inclua novo comentário na publicação já existente.

            return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
        }
    }
}