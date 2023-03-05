using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MgDbDemo.Entities;

public class Book: MongoDocBase
{
    [BsonElement("Name")]
    public string BookName { get; set; }

    public decimal Price { get; set; }

    
    public string Category { get; set; }

    public string Author { get; set; }
}

public class MongoDocBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime? CreatedDate { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime? UpdatedDate { get; set; }
}