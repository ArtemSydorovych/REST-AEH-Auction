using AuctionDomain.ValueObjects;

namespace AuctionDomain.Entities;

public class Bid
{
    public int Id { get; set; } = 0;
    public AuctionItem AuctionItem { get; set; } = new();
    public User Bidder { get; set; } = new();
    public Money Amount { get; set; } = new (0);
    public DateTime Timestamp { get; set; } = DateTime.MinValue; 
}