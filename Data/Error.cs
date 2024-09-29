using System.Text;

namespace task5itransition.Data;

public static class Error
{
    private static Random random = new Random();

    public static void AddErrorsToRecord(User user, double errorValue)
    {
        if (errorValue <= 0) return;

        var errorsCount = (int)Math.Floor(errorValue);
        var errorProbability = errorValue % 1;

        if (errorProbability > 0 && random.NextDouble() <= errorProbability)
        {
            errorsCount += 1;
        }

        var fields = new List<(string FieldName, Func<string> Getter, Action<string> Setter)>
        {
            ("Name", () => user.Name, value => user.Name = value),
            ("MiddleName", () => user.MiddleName, value => user.MiddleName = value),
            ("LastName", () => user.LastName, value => user.LastName = value),
            ("Address", () => user.Address, value => user.Address = value),
            ("Phone", () => user.Phone, value => user.Phone = value)
        };

        for (var i = 0; i < errorsCount; i++)
        {
            var fieldIndex = random.Next(fields.Count);
            var field = fields[fieldIndex];
            var originalValue = field.Getter();
            var newValue = AddErrorToField(originalValue);
            field.Setter(newValue);
        }
    }

    private static string AddErrorToField(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var errorType = random.Next(3); // 0: delete, 1: add, 2: swap
        var result = new StringBuilder(input);

        switch (errorType)
        {
            case 0: // Delete character
                if (result.Length > 0)
                {
                    var position = random.Next(result.Length);
                    result.Remove(position, 1);
                }
                break;

            case 1: // Add character
                var newChar = GetRandomCharacter();
                var addPosition = random.Next(result.Length + 1);
                result.Insert(addPosition, newChar);
                break;

            case 2: // Swap near characters
                if (result.Length > 1)
                {
                    var position = random.Next(result.Length - 1);
                    var temp = result[position];
                    result[position] = result[position + 1];
                    result[position + 1] = temp;
                }
                break;
        }

        return result.ToString();
    }

    private static char GetRandomCharacter()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return chars[random.Next(chars.Length)];
    }
}