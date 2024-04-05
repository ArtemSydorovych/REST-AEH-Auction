using AuctionDomain.ValueObjects;

namespace AuctionDomain.Entities;

public sealed record AuctionItem
{
    public readonly int Id = 0;
    public string Title = null!;
    public string Description = null!;
    public Money StartPrice = new(0);
    public DateTime StartTime = DateTime.MinValue;
    public DateTime EndTime = DateTime.MinValue;
    public User Seller = User.DefaultUser();
    public int SellerId = 0;
    public readonly List<Bid> Bids = new();
    
    public AuctionItem(string title, string description, Money startPrice, DateTime startTime, DateTime endTime, int sellerId)
    {
        Title = title;
        Description = description;
        StartPrice = startPrice;
        StartTime = startTime;
        EndTime = endTime;
        SellerId = sellerId;
    }

    public AuctionItem()
    { }
}