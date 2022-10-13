using MongoDB.Driver;

namespace TrailMongoDb
{
    public class ConnectionMongoDb
    {
        public const string CONNECTION_STRING = "mongodb://localhost:27017";
        public const string DATABASE_NAME = "MongoData";
        public const string COLLECTION_NAME = "Books";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static ConnectionMongoDb()
        {
            _client = new MongoClient(CONNECTION_STRING);
            _database = _client.GetDatabase(DATABASE_NAME);
        }


        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Book> Books
        {
            get
            {
                return _database.GetCollection<Book>(COLLECTION_NAME);
            }
        }


    }
}
