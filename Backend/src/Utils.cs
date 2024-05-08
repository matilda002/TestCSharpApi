namespace WebApp;

public static class Utils
{
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

    public static Arr CreateMockUsers() 
    {
            // Read all mock users from the JSON file
            var read = FilePath(FilePath("json", "mock-users.json"));
            Arr mockUsers = JSON.Parse(read);
            Arr successFullyWrittenUsers = Arr();
            foreach (var user in mockUsers)
            {
                var result = SQLQueryOne(
                    @"INSERT INTO users(firstName,lastName,email,password)
                    VALUES($firstName, $lastName, $email, $password)
                ", user);
                // If we get an error from the DB then we haven't added
                // the mock users, if not we have so add to the successful list
                if (!result.HasKey("error"))
                {
                    // The specification says return the user list without password
                    user.Delete("password");
                    successFullyWrittenUsers.Push(user);
                }
            }
            return successFullyWrittenUsers;
    }
}