using AuctionDomain.ValueObjects;

namespace AuctionDomain.Entities;

public sealed record User(int Id, string Username, Email Email, DateTime RegistrationDate, IEnumerable<AuctionItem> AuctionItems)
{
    public static User DefaultUser() => 
        new(0, "", new Email("example@test.net"), DateTime.MinValue, new List<AuctionItem>());
}
