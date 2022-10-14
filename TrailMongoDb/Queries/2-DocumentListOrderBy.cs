using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics.Contracts;
using TrailMongoDb.Entities;
using TrailMongoDb.Infra;

namespace TrailMongoDb.Queries
{
    public class DocumentListOrderBy
    {
        static void Main(string[] args)
        {
            Task T = MainClassAsyncConnClass(args);
            Console.ReadKey();
        }

        static async Task MainClassAsyncConnClass(string[] args)
        {

            var conn = new ConnectionMongoDb();

            #region Filter Filter - More than 200 pages

            Console.WriteLine("\n****** List documents - More than 200 pages ******\n");

            var construct = Builders<Book>.Filter;
            var conditional = construct.Gt(x => x.NumberOfPages, 200); //AnyEq search inside in Array

            var bookList = await conn.Books.Find(conditional)
                .SortBy(x => x.Title)
                .Limit(1)
                .ToListAsync();

            foreach (Book book in bookList)
            {
                Console.WriteLine(book.ToJson<Book>());
            }

            Console.WriteLine("\nEnd of list - Filter class\n");


            #endregion

        }
    }
}
