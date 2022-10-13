using MongoDB.Bson;
using MongoDB.Driver;

namespace TrailMongoDb.Create
{
    public class AcessMongoDb
    {
        //static void Main(string[] args)
        //{
        //    Task T = MainAsync(args);
        //    Console.WriteLine("Pressione ENTER");
        //    Console.ReadKey();
        //}

        static async Task MainAsync(string[] args)
        {

            var doc = new BsonDocument
            {
                {"title", "Game of Thrones" }
            };
            doc.Add("writer", "George R R Martin");
            doc.Add("yearRelease", 1999);
            doc.Add("numberOfPages", 856);

            var genre = new BsonArray();
            genre.Add("Fantasia");
            genre.Add("Ação");

            doc.Add("genre", genre);

            Console.WriteLine(doc);

            //Acess to Server

            string connectionString = "mongodb://localhost:27017";
            IMongoClient client = new MongoClient(connectionString);

            //Acess to Database

            IMongoDatabase dataBaseMongo = client.GetDatabase("MongoData");

            //Acess to Collection

            IMongoCollection<BsonDocument> collection = dataBaseMongo.GetCollection<BsonDocument>("Books");

            //Input document

            await collection.InsertOneAsync(doc);

            Console.WriteLine("Documento incluido");










        }


    }
}
