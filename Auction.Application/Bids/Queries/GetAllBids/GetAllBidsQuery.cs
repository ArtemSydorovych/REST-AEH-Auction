using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.Bids.Queries.GetAllBids;

public sealed record GetAllBidsQuery : IRequest<IEnumerable<Bid>>;