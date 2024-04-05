namespace Auction.Application.Dtos;

public sealed record AuctionItemDto(
    string Title, 
    string Description, 
    decimal StartPrice, 
    DateTime StartTime, 
    DateTime EndTime,
    int SellerId);