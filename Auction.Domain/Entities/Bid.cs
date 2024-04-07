using AuctionDomain.ValueObjects;

namespace AuctionDomain.Entities;

public sealed class Bid
{
    public int Id { get; set; } = default;
    public AuctionItem AuctionItem { get; set; } = new();
    public int BidderId { get; set; } = default;
    public Money Amount { get; set; } = new (0);
    public DateTime Timestamp { get; set; } = DateTime.MinValue; 
}