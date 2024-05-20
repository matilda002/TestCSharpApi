namespace WebApp;

public static class Utils
{
    // Read all mock users from file
    private static readonly Arr mockUsers = JSON.Parse(
        File.ReadAllText(FilePath("json", "mock-users.json"))
    );

    // Read all bad words from file and sort from longest to shortest
    // if we didn't sort we would often get "---ing" instead of "---" etc.
    // (Comment out the sort - run the unit tests and see for yourself...)
    private static readonly Arr badWords = ((Arr)JSON.Parse(
        File.ReadAllText(FilePath("json", "bad-words.json"))
    )).Sort((a, b) => ((string)b).Length - ((string)a).Length);

    public static bool IsPasswordGoodEnough(string password)
    {
        return password.Length >= 8
            && password.Any(Char.IsDigit)
            && password.Any(Char.IsLower)
            && password.Any(Char.IsUpper)
            && password.Any(x => !Char.IsLetterOrDigit(x));
    }

    public static bool IsPasswordGoodEnoughRegexVersion(string password)
    {
        // See: https://dev.to/rasaf_ibrahim/write-regex-password-validation-like-a-pro-5175
        var pattern = @"^(?=.*[0-9])(?=.*[a-zåäö])(?=.*[A-ZÅÄÖ])(?=.*\W).{8,}$";
        return Regex.IsMatch(password, pattern);
    }

    public static string RemoveBadWords(string comment, string replaceWith = "---")
    {
        comment = " " + comment;
        replaceWith = " " + replaceWith + "$1";
        badWords.ForEach(bad =>
        {
            var pattern = @$" {bad}([\,\.\!\?\:\; ])";
            comment = Regex.Replace(
                comment, pattern, replaceWith, RegexOptions.IgnoreCase);
        });
        return comment[1..];
    }

    public static Arr CreateMockUsers()
    {
        Arr successFullyWrittenUsers = Arr();
        foreach (var user in mockUsers)
        {
            // user.password = "12345678";
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

    // Ta bort alla mocksanvändare ur databasen.
    // - En metod som tar bort alla mockanvändare som CreateMockUsers skapat ur
    // databasen, men inga andra användare.
    // - Den har inga inparametrar och ska returnera en Arr av Obj:s som innehåller
    // de mock-users som faktiskt har tagits bort ur databasen EXKLUSIVE lösenord
    // - Metoden har inga inparametrar
    
    // RemoveMockUsers

    // Hur många användare har samma domän i sin email?
    // En metod som summerar hur många användare som har samma domän i sin email.
    // - Metoden ska läsa users-tabellen i databasen, via metoden SQLQuery - som är global i projektet).
    // - Den ska returnera ett Obj (se Dyndatas dokumentation för Obj). I detta objekt ska varje domän
    // vara en nyckel/egenskap och värdet tillhörande en nyckel ska vara hur många gånger just detta
    // domän förekommer bland användarnas email.
    // - Metoden har inga inparametrar och ska döpas till CountDomainsFromUserEmails.
    
    // CountDomainsFromUserEmails
    
    
    
}