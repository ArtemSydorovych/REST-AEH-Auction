using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.Bids.Commands.AddBid;

public sealed record AddBidCommand(AddBidDto BidDto) : IRequest<Bid>;