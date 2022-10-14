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

            #region Show all Documents
            Console.WriteLine("\nShow all documents\n");

            var listBooks = await conn.Books.Find(new BsonDocument()).ToListAsync();
            foreach(var doc in listBooks)
            {
                Console.WriteLine($"{doc.ToJson<Book>()}\n");
            }

            Console.WriteLine("\nEnd of show\n");

            #endregion

            #region Show Documents with filter

            Console.WriteLine("\nShow documents with filter\n");

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

            #endregion

            #region Filter with documents

            Console.WriteLine("\n****** List documents Writer - Class ******\n");

            var construct = Builders<Book>.Filter;
            var conditional = construct.Eq(x => x.Writer, "Paulo Coelho");

            var bookList = await conn.Books.Find(conditional).ToListAsync();

            foreach(Book book in bookList)
            {
                Console.WriteLine(book.ToJson<Book>());
            }

            Console.WriteLine("\nEnd of list - Filter class\n");

            #endregion

            #region Filter Year Release after 1990

            Console.WriteLine("\n****** List documents Writer - Class - Filter Year Release after 1990 ******\n");

            var construct2 = Builders<Book>.Filter;
            var conditional2 = construct.Gte(x => x.YearRelease, 1990); //Greater than or Equal (Gte)

            var bookList2 = await conn.Books.Find(conditional2).ToListAsync();

            foreach (Book book in bookList2)
            {
                Console.WriteLine(book.ToJson<Book>());
            }

            Console.WriteLine("\nEnd of list - Filter class\n");


            #endregion

            #region Filter Year Release after 1990 and more than 300 pages

            Console.WriteLine("\n****** List documents Writer - Class - Filter Year Release after 1990 and more than 300 pages ******\n");

            var construct3 = Builders<Book>.Filter;
            var conditional3 = construct.Gte(x => x.YearRelease, 1990) & construct.Gte(x => x.NumberOfPages, 300); //Greater than or Equal (Gte)

            var bookList3 = await conn.Books.Find(conditional3).ToListAsync();

            foreach (Book book in bookList3)
            {
                Console.WriteLine(book.ToJson<Book>());
            }

            Console.WriteLine("\nEnd of list - Filter class\n");


            #endregion


            #region Filter Filter Genre (Array) Romance

            Console.WriteLine("\n****** List documents Writer - Class - Genre Romance ******\n");

            var construct4 = Builders<Book>.Filter;
            var conditional4 = construct.AnyEq(x => x.Genre, "Romance"); //AnyEq search inside in Array

            var bookList4 = await conn.Books.Find(conditional4).ToListAsync();

            foreach (Book book in bookList4)
            {
                Console.WriteLine(book.ToJson<Book>());
            }

            Console.WriteLine("\nEnd of list - Filter class\n");


            #endregion

        }
    }
}
