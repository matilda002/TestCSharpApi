// "Built in": System and Microsoft specific
global using System.Text.RegularExpressions;
global using System.Text.Json;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.Extensions.FileProviders;

// Nuget packages
global using Microsoft.Data.Sqlite;
global using BCryptNet = BCrypt.Net.BCrypt;
global using Dyndata;
global using static Dyndata.Factory;
global using Xunit;
global using Xlog = Xunit.Abstractions.ITestOutputHelper;

// Internal
global using WebApp;
global using static WebApp.Shared;
global using static WebApp.RequestBodyParser;
global using static WebApp.DbQuery;