using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RazorPagesUser.Models;

public class User
{
   /* public int Id { get; set; }

    public string? firstName { get; set; }
    public string? lastName { get; set; }*/
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string? id { get; set;}
   public string? username { get; set;}

   public string? password { get; set;}
   public string? location { get; set;}

}
