using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.Bids.Queries.GetBid;

public sealed record GetBidQuery(int Id) : IRequest<Bid>;