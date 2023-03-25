using RazorPagesUser.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Driver;

namespace RazorPagesUser.Services;

public class UserService
{
    private static readonly IMongoCollection<User> theUsers;

    static UserService() 
    {
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://teamUSER:ZZlaZLsEiSzDekpv@cleaningladiesdb.kpctpsb.mongodb.net/?retryWrites=true&w=majority");
        var client = new MongoClient(settings);
        var database = client.GetDatabase("CleaningLadiesDB");
        theUsers = database.GetCollection<User>("User");



        //User user = new User{username="Test", password="test", location="IL"};

        /*Users = new List<User>
        {
            new User{ Id = 1, firstName = "Ian", lastName = "Gallo" } 
        };*/
        //theUsers.InsertOne(user);
    }
    
    //public static List<User> GetAll() => User;

    public bool CreateAccount(string username, string password)
    {
        if(Get(username) == null) {
            User user = new User();
            user.username = username;
            user.password = password;
            Create(user);
            return true;
        }
        else{
            return false;
        }
    }
    
    public bool LogIn(string username, string password){
        var sha256 = SHA256.Create();
        var toBytes = Encoding.UTF8.GetBytes(password);
        var theHash = sha256.ComputeHash(toBytes);
        var passwordToCheck = BitConverter.ToString(theHash).Replace("-", "");

        try
        {
            if (Get(username).password == passwordToCheck)
            {
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return false;
    }

    public User GetUserBySessionID(string sessionID)
    {
        return theUsers.Find(user => user.sessionID == sessionID).FirstOrDefault();
    }

    public void CreateLoginSession(string cookieID, string username, string password)
    {
        User user = Get(username);
        user.sessionID = cookieID;
        Update(username, user);
    }

    public bool CheckCookie(string cookieID)
    {
        if(theUsers.Find(user => user.sessionID == cookieID).FirstOrDefault() != null)
        {
            return true;
        }
        return false;
    }

    public void LogOut(string cookieID)
    {
        User loggingOut = theUsers.Find(user => user.sessionID == cookieID).FirstOrDefault();

        if (loggingOut != null)
        {
            loggingOut.sessionID = "";
            Update(loggingOut.username, loggingOut);
        }
    }

    //public static User? Get(string id) => theUsers.FirstOrDefault(u => u.id == id);
    public User Get(string username) => theUsers.Find(user => user.username == username).FirstOrDefault();

    public List<User> GetList(string location) => theUsers.Find(user => user.location == location).ToList();

    public User Create(User user)
    {
        var sha256 = SHA256.Create();
        var toBytes = Encoding.UTF8.GetBytes(user.password);
        var theHash = sha256.ComputeHash(toBytes);
        user.password = BitConverter.ToString(theHash).Replace("-", "");
        theUsers.InsertOne(user);
        return user;
    }

    /*public static void Add(User user)
    {
        /*user.Id = nextId++;
        Users.Add(user);
    }*/
    public void Delete(User deleteUser) => theUsers.DeleteOne(user => user.username == deleteUser.username);

    public void Delete(string username) => theUsers.DeleteOne(user => user.username == username);
    /*public static void Delete(string username)
    {
        /*var user = Get(id);
        if (user is null) {
            return;
        }

        Users.Remove(user);
    }*/

    public void Update(string username, User updatedUser) => theUsers.ReplaceOne(user => user.username == username, updatedUser);
    /*public static void Update(User user)
    {
       /* var index = Users.FindIndex(p => p.Id == user.Id);
        if (index == -1) {
            return;
        }

        Users[index] = user;
    }*/

}
