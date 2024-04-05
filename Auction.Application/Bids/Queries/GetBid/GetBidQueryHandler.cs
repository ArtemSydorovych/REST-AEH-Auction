using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.Bids.Queries.GetBid;

public class GetBidQueryHandler(IBidRepository repository) : IRequestHandler<GetBidQuery, Bid>
{
    public async Task<Bid> Handle(GetBidQuery request, CancellationToken cancellationToken) => 
        await repository.GetByIdAsync(request.Id);
}