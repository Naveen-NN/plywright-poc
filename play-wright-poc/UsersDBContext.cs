using System.IO;  

public class UsersDBContext
{
    private string FilePath { get; set; } 
    public string Data { get; private set; }

    public UsersDBContext()
    {
        FilePath = Path.Combine(Directory.GetCurrentDirectory()) +  @"\mocks\users.json";  
        SetData();
    }

    private void SetData()
    {
        Data = File.ReadAllText(FilePath);
    }

    public void Update(string content)
    {
        File.WriteAllText(FilePath, content);
        SetData();
    }
}