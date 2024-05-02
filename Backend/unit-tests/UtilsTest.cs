using Xunit;
namespace WebApp;

public class UtilsTest
{
    [Fact]
    public void TestSumInt()
    {
        Assert.Equal(12, Utils.SumInts(7, 5));
        Assert.Equal(-3, Utils.SumInts(6, -9));
    }
    
    /*
    [Fact]
    public void TestCreateMockUsers()
    {
        // Read all mock-users from the JSON file
        var read = File.ReadAllText(Path.Combine("json", "mock-users.json")); // neutral way for all machines to find the pathfile
        Arr mockUsers = JSON.Parse(read);
        
        // Get all users from the database
        Arr usersInDb = SQLQuery("select email from users");
        Arr emailsInDb = usersInDb.Map(user => user.email);
        // Only keep the mock users not already in db
        Arr mockUsersNotInDb = mockUsers.Filter(
            mockUser => !emailsInDb.Contains(mockUser.email));
        // Assert that the CreateMockUsers only return
        // newly created users in db
        var result = Utils.CreateMockUsers();
        
        Assert.Equal(mockUsersNotInDb.Length, result.Length);
        
        // check equivalency for each user
        for (var i = 0; i < result.Length; i++)
        {
            Assert.Equivalent(mockUsersNotInDb[i], result[i]);
            Assert.Equal(
                JSON.Stringify(result[i]),
                JSON.Stringify(mockUsersNotInDb[i]));
        }
    }
    */
}