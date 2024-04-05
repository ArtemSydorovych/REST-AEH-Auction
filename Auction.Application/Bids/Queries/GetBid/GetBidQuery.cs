using AuctionDomain.Entities;
using MediatR;

public sealed record GetBidQuery(int Id) : IRequest<Bid>;