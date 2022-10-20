using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using projetoBlog.Models;
using projetoBlog.Models.Home;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace projetoBlog.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            var conn = new AcessoMongoDB();

            var filter = new BsonDocument();
            var publicaçõesList = await conn.Publicacoes.Find(filter).SortByDescending(x => x.DataCriacao).Limit(10).ToListAsync();

            var model = new IndexModel
            {
                PublicacoesRecentes = publicaçõesList
            };


            return View(model);
        }

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
            await conn.Publicacoes.InsertOneAsync(post);


            return RedirectToAction("Publicacao", new {id = post.Id});
        }

        [HttpGet]
        public async Task<ActionResult> Publicacao(string id)
        {

            var connectarMongoDB = new AcessoMongoDB();
            var publicacao = await connectarMongoDB.Publicacoes.Find(x => x.Id == id).SingleOrDefaultAsync();

            if (publicacao == null)
            {
                return RedirectToAction("Index");
            }

            var model = new PublicacaoModel
            {
                Publicacao = publicacao,
                NovoComentario = new NovoComentarioModel
                {
                    PublicacaoId = id
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Publicacoes(string tag = null)
        {

            var conn = new AcessoMongoDB();
            var pots = new List<Publicacao>();

            if (tag == null)
            {
                var filter = new BsonDocument();
                pots = await conn.Publicacoes.Find(filter).SortByDescending(x => x.DataCriacao).Limit(10).ToListAsync();

            }
            else
            {
                var constructor = Builders<Publicacao>.Filter;
                var conditonal = constructor.AnyEq(x => x.Tags, tag);
                pots = await conn.Publicacoes.Find(conditonal).SortByDescending(x => x.DataCriacao).Limit(10).ToListAsync();
            }

            return View(pots);
        }

        [HttpPost]
        public async Task<ActionResult> NovoComentario(NovoComentarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
            }

            var comment = new Comentario()
            {
                Autor = User.Identity.Name,
                Conteudo = model.Conteudo,
                DataCriacao = DateTime.UtcNow
            };

            var conn = new AcessoMongoDB();


            var constructor = Builders<Publicacao>.Filter;
            var conditional = constructor.Eq(x => x.Id, model.PublicacaoId);

            var updateConstructor = Builders<Publicacao>.Update;
            var updateConditional = updateConstructor.Push(x => x.Comentarios, comment);

            await conn.Publicacoes.UpdateOneAsync(conditional,updateConditional);

            return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
        }
    }
}