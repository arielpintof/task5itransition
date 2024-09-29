using Newtonsoft.Json;

namespace task5itransition.Data;

public class User
{
    public int Id { get; set; }
    public Guid UniqueId { get; set; }
    public string Name { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Region { get; set; }
}


public static class ExtensionsForTesting
{
    public static void Dump(this object obj)
    {
        Console.WriteLine(obj.DumpString());
    }

    public static string DumpString(this object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}