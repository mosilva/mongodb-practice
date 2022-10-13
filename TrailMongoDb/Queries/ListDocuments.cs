using MongoDB.Bson;
using MongoDB.Driver;
using TrailMongoDb.Entities;
using TrailMongoDb.Infra;

namespace TrailMongoDb.Queries
{
    public class ListDocuments
    {
        static void Main(string[] args)
        {
            Task T = MainClassAsyncConnClass(args);
            Console.ReadKey();
        }

        static async Task MainClassAsyncConnClass(string[] args)
        {

            var conn = new ConnectionMongoDb();

            Console.WriteLine("Show all documents\n");

            var listBooks = await conn.Books.Find(new BsonDocument()).ToListAsync();
            foreach(var doc in listBooks)
            {
                Console.WriteLine($"{doc.ToJson<Book>()}\n");
            }

            Console.WriteLine("\nend of show\n\n\n");


            Console.WriteLine("Show documents with filter\n");

            var filter = new BsonDocument
            {
                {
                    "Writer", "Machado de Assis"
                }
            };

            var listBooksWithFilter = await conn.Books.Find(filter).ToListAsync();
            foreach (var doc in listBooksWithFilter)
            {
                Console.WriteLine($"{doc.ToJson<Book>()}\n");
            }

            Console.WriteLine("\nend of show\n");



        }
    }
}
