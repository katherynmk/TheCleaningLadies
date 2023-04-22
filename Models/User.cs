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
    public string cnumber { get; set;}
    public string cdate { get; set;}
    public string ccvv { get; set;}
    public string area {get; set;}
    public string email {get; set;}
    public string? location { get; set;}

    public string sessionID { get; set;}

    public TimeSpan? mondayStart { get; set; }
    public TimeSpan? mondayEnd { get; set; }
    public TimeSpan? tuesdayStart { get; set; }
    public TimeSpan? tuesdayEnd { get; set; }
    public TimeSpan? wednesdayStart { get; set; }
    public TimeSpan? wednesdayEnd { get; set; }
    public TimeSpan? thursdayStart { get; set; }
    public TimeSpan? thursdayEnd { get; set; }
    public TimeSpan? fridayStart { get; set; }
    public TimeSpan? fridayEnd { get; set; }
    public TimeSpan? saturdayStart { get; set; }
    public TimeSpan? saturdayEnd { get; set; }
    public TimeSpan? sundayStart { get; set; }
    public TimeSpan? sundayEnd { get; set; }
}
