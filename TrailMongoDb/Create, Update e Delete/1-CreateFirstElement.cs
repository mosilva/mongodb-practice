using MongoDB.Bson;

namespace TrailMongoDb.Create
{
    class Program
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadKey();
        }

        static async Task MainAsync(string[] args)
        {
            //Console.WriteLine("I'm waiting 10 s...");
            //await Task.Delay(10000);
            //Console.WriteLine("I waited 10 s");


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


        }


    }
}


