using MongoDB.Bson;
using MongoDB.Driver;
using TrailMongoDb.Entities;
using TrailMongoDb.Infra;

namespace TrailMongoDb.Queries
{
    public class DeleteDocument
    {
        static void Main(string[] args)
        {
            Task T = MainClassAsyncDelete(args);
            Console.ReadKey();
        }

        static async Task MainClassAsyncDelete(string[] args)
        {

            var conn = new ConnectionMongoDb();

            #region Filter Filter - Delete

            Console.WriteLine("\n****** List documents - Delete Document ******\n");

            var construct = Builders<Book>.Filter;
            var conditional = construct.Eq(x => x.Title, "The Richest Man In Babylon");

            var book = await conn.Books.Find(conditional).FirstAsync();

            await conn.Books.DeleteOneAsync(conditional);


            Console.WriteLine("\nEnd of list -  Delete\n");
            #endregion

        }
    }
}
