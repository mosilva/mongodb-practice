using MongoDB.Bson;
using MongoDB.Driver;
using TrailMongoDb.Entities;

namespace TrailMongoDb.Create
{
    public class AcessMongoDbForClass
    {

        static async Task MainClassAsync(string[] args)
        {
            Book book = new Book();
            book.Title = "The Alchemist";
            book.Writer = "Paulo Coelho";
            book.YearRelease = 1988;
            book.NumberOfPages = 208;

            List<string> genres = new List<string>
            {
                "Romance",
                "Quest",
                "Drama"
            };

            book.Genre = genres;


            //Acess to Server

            string connectionString = "mongodb://localhost:27017";
            IMongoClient client = new MongoClient(connectionString);

            //Acess to Database

            IMongoDatabase dataBaseMongo = client.GetDatabase("MongoData");

            //Acess to Collection

            IMongoCollection<Book> collection = dataBaseMongo.GetCollection<Book>("Books");

            //Input document

            await collection.InsertOneAsync(book);

            Console.WriteLine("Documento incluido");










        }


    }
}
