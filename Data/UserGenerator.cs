using Bogus;

namespace task5itransition.Data;

public class UserGenerator : IDataGenerator<User>
{
    private readonly string _region;
    private int _userIds;

    public UserGenerator(string region)
    {
        _region = region;
        _userIds = 0; 
    }

    public async Task<IEnumerable<User>> Generate(int count, int seed, double errorsPerRecord)
    {
        Randomizer.Seed = new Random(seed);

        var faker = new Faker<User>(_region)
            .RuleFor(u => u.Id, f => _userIds++)
            .RuleFor(u => u.UniqueId, f => Guid.NewGuid())
            .RuleFor(u => u.Name, f => f.Name.FirstName())
            .RuleFor(u => u.MiddleName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Address, f => f.Address.FullAddress())
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.Region, f => _region);

        
        var users = faker.Generate(count).ToList();

        Console.WriteLine($"Errors per record: {errorsPerRecord}");
        foreach (var user in users)
        {
           
            Error.AddErrorsToRecord(user, errorsPerRecord);
        }

        return await Task.FromResult<IEnumerable<User>>(users);
    }
}