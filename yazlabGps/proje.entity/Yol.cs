
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace proje.entity
{
    public class Yol
    {
          public ObjectId Id { get; set; }
        public string lati { get; set; }
        public string longi { get; set; }
        public string arabaid { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    public DateTime Date { get; set; }
    public string? tarih { get; set; }
    }
}