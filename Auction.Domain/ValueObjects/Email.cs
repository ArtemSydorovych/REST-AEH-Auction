using System.Text.RegularExpressions;

namespace AuctionDomain.ValueObjects;

public sealed partial class Email
{
    private static readonly Regex EmailRegex = MyRegex();
    public string Value { get; set; }
    
    public Email(string value) 
    {
        if (!EmailRegex.IsMatch(value))
        {
            throw new ArgumentException("Invalid email format", nameof(value));
        }
        Value = value; 
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}