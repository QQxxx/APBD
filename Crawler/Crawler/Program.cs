using System.Text.RegularExpressions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            // check if user provided any input
            if (args == null || args.Length == 0)
            {
                throw new ArgumentNullException(nameof(args), "No arguments provided. Please check that.");
            }

            var set = new HashSet<string>();
            var regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");

            var url = args[0];

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException("Invalid URL format.", nameof(args));
            }

            HttpClient httpClient = new HttpClient();
            var httpResult = await httpClient.GetAsync(url);

            if (httpResult.IsSuccessStatusCode)
            {
                var httpContent = await httpResult.Content.ReadAsStringAsync();
                var matches = regex.Matches(httpContent);
                var numberOfMatches = regex.Matches(httpContent).Count;

                if (numberOfMatches == 0)
                {
                    throw new Exception("No email addresses found.");
                } else
                {
                    matches
                    .Select(e => e.Value)
                    .Distinct()
                    .ToList()
                    .ForEach(e => Console.WriteLine(e));
                }

            } else
            {
                throw new WrongHttpResponseException("Error while loading website.");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ArgumentException: {ex.Message}");
        }
    }



}

public class WrongHttpResponseException : Exception
{
    public WrongHttpResponseException(String message) : base(message) { }
}