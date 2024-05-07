using Xunit;
namespace WebApp;

public class UtilsTest (Xlog Console)
{
    [Fact]
    public void TestIsPasswordGoodEnough()
    {
        bool result = Utils.IsPasswordGoodEnough("Password1!");
        Assert.True(result);
    }
    
    [Fact]
    public void TestRemoveBadWords()
    {
        FilePath("json", "badwords.json");
    }
}