using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrailMongoDb
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
}
