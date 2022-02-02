using System.IO;  
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Models;
using System.Linq;
public class UsersContext
{
    public string Data { get; private set; }
    public IEnumerable<User> Users { get; private set; }
    private static UsersDBContext DBContext {get; set;}
    public UsersContext()
    {
        DBContext = new UsersDBContext();
        Data  = DBContext.Data;
        DeserializeCollection();
    }
    public bool UpdateUser(string userData)
    {
        User user = Deserialize(userData);
        User userToUpdate = null;
        if(user != null)
        {
            userToUpdate = Users.Where( u => u.Id == user.Id).FirstOrDefault();
            if(userToUpdate != null)
            {
                userToUpdate.Name = user.Name;  
                userToUpdate.Username = user.Username;  
                userToUpdate.Email = user.Email;
                SerializeCollection();
                DBContext.Update(Data);
                Data = DBContext.Data;
            }
        }
        return true;
    }

    private User Deserialize(string data)
    {
        return System.Text.Json.JsonSerializer.Deserialize<User>(data);
    }

    private void DeserializeCollection()
    {
        Users = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<User>>(Data);
    }

    private void SerializeCollection()
    {
        Data = System.Text.Json.JsonSerializer.Serialize(Users, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}