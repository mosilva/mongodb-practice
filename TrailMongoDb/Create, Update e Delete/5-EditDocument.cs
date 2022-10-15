using MongoDB.Bson;
using MongoDB.Driver;
using TrailMongoDb.Entities;
using TrailMongoDb.Infra;

namespace TrailMongoDb.Queries
{
    public class EditDocument
    {
        static void Main(string[] args)
        {
            Task T = MainClassAsyncEdit(args);
            Console.ReadKey();
        }

        static async Task MainClassAsyncEdit(string[] args)
        {

            var conn = new ConnectionMongoDb();

            #region Filter Filter - Edit title

            Console.WriteLine("\n****** List documents - Edit Document ******\n");

            var construct = Builders<Book>.Filter;
            var conditional = construct.Eq(x => x.Title, "Art of War");

            var book = await conn.Books.Find(conditional).FirstAsync();

            book.Title = "Art of War";

            await conn.Books.ReplaceOneAsync(conditional,book);

            Console.WriteLine("\nEnd of list - Edit Document\n");

            #endregion

            #region Filter Filter - Edit title for Class

            Console.WriteLine("\n****** List documents - Edit Document for class ******\n");

            var construct2 = Builders<Book>.Filter;
            var conditional2 = construct2.Eq(x => x.Title, "The Iliad");

            var book2 = await conn.Books.Find(conditional2).FirstAsync();

            var constructUpdate = Builders<Book>.Update;
            var conditionalUpdate = constructUpdate.Set(x => x.YearRelease, 1600);
            await conn.Books.UpdateOneAsync(conditional2, conditionalUpdate);


            Console.WriteLine("\nEnd of list -  Edit Document for class\n");
            #endregion

        }
    }
}
