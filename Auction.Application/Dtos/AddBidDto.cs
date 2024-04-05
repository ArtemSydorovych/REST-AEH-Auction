namespace Auction.Application.Dtos;

public sealed record AddBidDto
{
    public int AuctionItemId;
    public int BidderId;
    public decimal Amount;
}