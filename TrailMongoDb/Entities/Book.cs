using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrailMongoDb.Entities
{
    public class Book
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public int YearRelease { get; set; }
        public int NumberOfPages { get; set; }
        public List<string> Genre { get; set; }

    }

    public class BookValues
    {

        public static Book inputBookValues(string title, string writer, int yearRelease, int numberOfPages, string genre)
        {
            Book book = new Book();
            book.Title = title;
            book.Writer = writer;
            book.YearRelease = yearRelease;
            book.NumberOfPages = numberOfPages;
            string[] vetGenres = genre.Split(',');
            List<string> vetGenres2 = new List<string>();
            for (int i = 0; i < vetGenres.Length; i++)
            {
                vetGenres2.Add(vetGenres[i].Trim());
            }
            book.Genre = vetGenres2;
            return book;

        }



    }


}
