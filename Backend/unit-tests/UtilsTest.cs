﻿namespace WebApp;

public class UtilsTest(Xlog Console)
{
    // Read all mock users from file
    private static readonly Arr mockUsers = JSON.Parse(
        File.ReadAllText(FilePath("json", "mock-users.json"))
    );

    // read all users with their unique email address
    private readonly Arr _qUsersInDb = SQLQuery("select email from users");

    [Theory]
    [InlineData("abC9#fgh", true)]  // ok
    [InlineData("stU5/xyz", true)]  // ok too
    [InlineData("abC9#fg", false)]  // too short
    [InlineData("abCd#fgh", false)] // no digit
    [InlineData("abc9#fgh", false)] // no capital letter
    [InlineData("abC9efgh", false)] // no special character
    public void TestIsPasswordGoodEnough(string password, bool expected)
    {
        Assert.Equal(expected, Utils.IsPasswordGoodEnough(password));
    }

    [Theory]
    [InlineData("abC9#fgh", true)]  // ok
    [InlineData("stU5/xyz", true)]  // ok too
    [InlineData("abC9#fg", false)]  // too short
    [InlineData("abCd#fgh", false)] // no digit
    [InlineData("abc9#fgh", false)] // no capital letter
    [InlineData("abC9efgh", false)] // no special character
    public void TestIsPasswordGoodEnoughRegexVersion(string password, bool expected)
    {
        Assert.Equal(expected, Utils.IsPasswordGoodEnoughRegexVersion(password));
    }

    [Theory]
    [InlineData(
        "---",
        "Hello, I am going through hell. Hell is a real fucking place " +
            "outside your goddamn comfy tortoiseshell!",
        "Hello, I am going through ---. --- is a real --- place " +
            "outside your --- comfy tortoiseshell!"
    )]
    [InlineData(
        "---",
        "Rhinos have a horny knob? (or what should I call it) on " +
            "their heads. And doorknobs are damn round.",
        "Rhinos have a --- ---? (or what should I call it) on " +
            "their heads. And doorknobs are --- round."
    )]
    public void TestRemoveBadWords(string replaceWith, string original, string expected)
    {
        Assert.Equal(expected, Utils.RemoveBadWords(original, replaceWith));
    }

    [Fact]
    public void TestCreateMockUsers()
    {
        // Get all users from the database
        Arr emailsInDb = _qUsersInDb.Map(user => user.email);
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
            "are equivalent (the same) as the expected users!");
        Assert.Equivalent(mockUsersNotInDb, result);
        Console.WriteLine("The test passed!");
    }
    /*
    [Fact]
    public void TestRemoveMockUsers()
    {
        Arr emailsInDb = _qUsersInDb.Map(user => user.email);
        Arr mockUsersInDb = mockUsers.Filter(
            mockUser => emailsInDb.Contains(mockUser.email)
        );
        
        Arr result = Utils.RemoveMockUsers();
        // print out all mockusers deleted without password
        Console.WriteLine($"Expected amount of mock users deleted: {mockUsersInDb.Length}");
        Console.WriteLine($"Actual amount of mock users deleted: {result.Length}");
        // seeing if it removed the correct users in db
        Assert.Equivalent(mockUsersInDb, result);
        Console.WriteLine("All the mockusers deleted: " + JSON.Stringify(result));
    }
    */
    [Fact]
    public void TestCountDomainsFromUserEmails()
    {
        Obj domainCount = Obj();

        foreach (var user in _qUsersInDb)
        {
            // checking the domain names
            string domain = user.email.Split('@')[1];
            if (!domainCount.HasKey(domain))
            {
                domainCount[domain] = 1;
            }
            else
            {
                domainCount[domain]++;
            }
        }
        // checking that the expected matches the actual outcome
        Obj result = Utils.CountDomainsFromUserEmails();
        Console.WriteLine($"Expected domain count: {domainCount.GetEntries().Length}");
        Console.WriteLine($"Actual domain count: {result.GetEntries().Length}");
        Console.WriteLine($"Result list of domains and their user count:\n{result}");
        Assert.Equivalent(domainCount, result);
        Console.WriteLine("Test passed, all domains counted for!!");
    }
}