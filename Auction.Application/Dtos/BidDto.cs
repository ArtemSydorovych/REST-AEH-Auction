using AuctionDomain.Entities;

namespace Auction.Application.Dtos;

public sealed record BidDto(AuctionItem AuctionItem, User Bidder, decimal Amount, DateTime Timestamp);
