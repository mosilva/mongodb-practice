namespace TrailMongoDb
{
    public class HandleExternClass
    {
        static void Main(string[] args)
        {
            Task T = MainClassAsyncConnClass(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadKey();
        }

        static async Task MainClassAsyncConnClass(string[] args)
        {
            Book book = new Book();
            book.Title = "The Richest Man In Babylon";
            book.Writer = "George Samuel Clason";
            book.YearRelease = 1926;
            book.NumberOfPages = 160;

            List<string> genres = new List<string>
            {
                "Finance"
            };

            book.Genre = genres;


            //Acess to Connection Class

            var conn = new ConnectionMongoDb();
            
            await conn.Books.InsertOneAsync(book); 

            Console.WriteLine("Documento incluido - finance");

        }

    }
}
