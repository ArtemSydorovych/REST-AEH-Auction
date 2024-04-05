using MediatR;

namespace Auction.Application.Bids.Commands.DeleteBid;

public sealed record DeleteBidCommand(int Id) : IRequest;