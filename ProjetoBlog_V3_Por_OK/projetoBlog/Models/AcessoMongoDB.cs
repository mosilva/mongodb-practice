using MongoDB.Driver;

namespace projetoBlog.Models
{
    public class AcessoMongoDB
    {
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "MongoDataBlog";
        public const string NOME_DA_COLECAO_PUBLICACAO = "Publicacoes";
        public const string NOME_DA_COLECAO_USUARIO = "Users";

        private static readonly IMongoClient _cliente;
        private static readonly IMongoDatabase _BaseDeDados;

        static AcessoMongoDB()
        {
            _cliente = new MongoClient(STRING_DE_CONEXAO);
            _BaseDeDados = _cliente.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Cliente
        {
            get { return _cliente; }
        }

        public IMongoCollection<Publicacao> Publicacoes
        {
            get { return _BaseDeDados.GetCollection<Publicacao>(NOME_DA_COLECAO_PUBLICACAO); }
        }

        public IMongoCollection<Usuario> Usuarios
        {
            get { return _BaseDeDados.GetCollection<Usuario>(NOME_DA_COLECAO_USUARIO); }
        }
    }
}
