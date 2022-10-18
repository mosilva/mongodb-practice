using MongoDB.Driver;

namespace projetoBlog.Models
{
    public class AcessoMongoDB
    {
        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string DATABASE_NAME = "MongoDataBlog";
        public const string COLLECTION_NAME_PUBLICATION = "Publications";
        public const string COLLECTION_NAME_USERS = "Users";


        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;
        static AcessoMongoDB()
        {
            _client = new MongoClient(CONNECTION_STRING);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Usuario> Users
        {
            get
            {
                return _database.GetCollection<Usuario>(COLLECTION_NAME_USERS);
            }
        }

        public IMongoCollection<Publicacao> Publications
        {
            get
            {
                return _database.GetCollection<Publicacao>(COLLECTION_NAME_PUBLICATION);
            }
        }



    }
}
