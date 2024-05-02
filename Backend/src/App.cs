// Global settings

using Utils = Microsoft.VisualBasic.CompilerServices.Utils;

Globals = Obj(new
{
    debugOn = true,
    detailedAclDebug = false,
    aclOn = true,
    isSpa = true,
    port = 3001,
    serverName = "Ironboy's Minimal API Server",
    frontendPath = Path.Combine("..", "Frontend"),
    sessionLifeTimeHours = 2
});

//Server.Start();
new UtilsTest().TestCreateMockUsers();
/*var addedUser = WebApp.Utils.CreateMockUsers();

foreach (var user in addedUser)
{
    Log("added users", user);
}*/