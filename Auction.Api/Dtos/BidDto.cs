namespace AuctionApi.Dtos;

public sealed record BidDto(int Id, int AuctionItemId, int BidderId, decimal Amount, DateTime Timestamp);
