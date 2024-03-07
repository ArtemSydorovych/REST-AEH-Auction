using AuctionDomain.ValueObjects;

namespace AuctionDomain.Entities;

public sealed class AuctionItem
{
    public readonly int Id = 0;
    public string Title;
    public string Description;
    public Money StartPrice = new(0);
    public DateTime StartTime = DateTime.MinValue;
    public DateTime EndTime = DateTime.MinValue;
    public User Seller = new();
    public int SellerId = 0;
    public readonly List<Bid> Bids = new();
}