using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RazorPagesUser.Models;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

public class User
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string? id { get; set;}
   public string username { get; set;}

   public string password { get; set;}
   public string? location { get; set;}

   public string sessionID { get; set;}

}
