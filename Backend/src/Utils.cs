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
            var read = File.ReadAllText(FilePath("json", "mock-users.json"));
            Arr mockUsers = JSON.Parse(read);
            // Get all users from the database
            Arr usersInDb = SQLQuery("SELECT email FROM users");
            Arr emailsInDb = usersInDb.Map(user => user.email);
            // Only keep the mock users not already in db
            Arr mockUsersNotInDb = mockUsers.Filter(

                mockUser => !emailsInDb.Contains(mockUser.email)

            );
            // Get the result of running the method in our code
            var result = Utils.CreateMockUsers();
            // Assert that the CreateMockUsers only return
            // newly created users in the db
            Console.WriteLine($"The test expected that {mockUsersNotInDb.Length} users should be added.");
            Console.WriteLine($"And {result.Length} users were added.");
            Console.WriteLine("The test also asserts that the users added " +
                              "are equivalent (the same) to the expected users!");
            Assert.Equivalent(mockUsersNotInDb, result);
            Console.WriteLine("The test passed!");

            return result;
    }
}