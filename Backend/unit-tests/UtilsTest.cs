using Xunit;
namespace WebApp;

public class UtilsTest
{
    [Fact]
    public void TestIsPasswordGoodEnough()
    {
        bool result = Utils.IsPasswordGoodEnough("Password1!");
        Assert.True(result);
    }
}