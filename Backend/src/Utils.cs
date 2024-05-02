namespace WebApp;

public static class Utils
{
    public static int SumInts(int a, int b)
    {
        return a + b;
    }

    public static Arr CreateMockUsers()
    {
        var read = File.ReadAllText(Path.Combine("json", "mock-users.json")); // neutral way for all machines to find the pathfile
        Arr mockUsers = JSON.Parse(read);
        Arr successFullyWrittenUsers = Arr();
        foreach (var user in mockUsers)
        {
            user.password = "12345678";
            var result = SQLQueryOne(@"insert into users(firstName,lastName,email,password)
                     values ($firstName, $lastName, $email, $password)
            ", user);
            // if we get an error from the db then we haven't added the mock users. If not, they have
            // been successfully added.
            if (!result.HasKey("error"))
            {
                // the specification says return the user list without password
                user.Delete("password");
                successFullyWrittenUsers.Push(user);
            }
        }
        return successFullyWrittenUsers;
    }

    public static bool IsPasswordGoodEnough(string password)
    {
        bool result;
        
        if (password.Length > 6 && password.Any(char.IsLower) && password.Any(char.IsUpper) &&
            password.Any(char.IsNumber) && password.Any(char.IsSymbol) || password.Any(char.IsPunctuation))
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
        
    }
}