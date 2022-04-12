using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace proje.entity
{
    public class Student
    {
        [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime CreatedOn { get; set; }
    public string Description { get; set; }
    }
}