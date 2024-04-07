using AuctionDomain.Entities;

namespace Auction.Application.Dtos;

public sealed record BidDto(AuctionItem AuctionItem, int BidderId, decimal Amount, DateTime Timestamp);
