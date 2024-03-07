using AuctionDomain.ValueObjects;

namespace AuctionDomain.Entities;

public sealed record User(int Id, string Username, Email Email, DateTime RegistrationDate, IEnumerable<AuctionItem> AuctionItems)
{
    public User() : this(0, "", new Email("example@test.net"), DateTime.MinValue, new List<AuctionItem>())
    {}
}
