namespace AuctionApi.Dtos;

public sealed record AuctionItemDto(
    int Id, 
    string Title, 
    string Description, 
    decimal StartPrice, 
    DateTime StartTime, 
    DateTime EndTime,
    int SellerId);