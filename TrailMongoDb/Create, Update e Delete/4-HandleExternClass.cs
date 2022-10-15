using TrailMongoDb.Entities;
using TrailMongoDb.Infra;

namespace TrailMongoDb.Create
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

            #region includeWithOnePerTime
            //Book book = new Book();
            //book.Title = "The Richest Man In Babylon";
            //book.Writer = "George Samuel Clason";
            //book.YearRelease = 1926;
            //book.NumberOfPages = 160;

            //List<string> genres = new List<string>
            //{
            //    "Finance"
            //};

            //book.Genre = genres;
            #endregion

            #region includeWithAllProprieties

            //Book book = new Book();
            //book = BookValues.inputBookValues("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Brasilian Liteture")

            #endregion

            List<Book> books = new List<Book>();   

            books.Add(BookValues.inputBookValues("The Iliad", "Homer", 1991, 835, "Poetry, Epic"));
            books.Add(BookValues.inputBookValues(" Art of War", "Sun Tzu", 1990, 160, "Treated, Non - fiction"));

            var conn = new ConnectionMongoDb();

            await conn.Books.InsertManyAsync(books);

            Console.WriteLine("Docs include");

        }

    }
}
