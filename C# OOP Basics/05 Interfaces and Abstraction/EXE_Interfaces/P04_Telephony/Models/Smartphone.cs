using System.Linq;

public class Smartphone : IBrowsable, ICallable
{
    public string Browse(string url)
    {
        if (url.Any(char.IsDigit))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {url}!";
    }

    public string Call(string number)
    {
        if (!number.All(char.IsDigit))
        {
            return "Invalid number!";
        }

        return $"Calling... {number}";  
    }
}