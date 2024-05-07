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
}