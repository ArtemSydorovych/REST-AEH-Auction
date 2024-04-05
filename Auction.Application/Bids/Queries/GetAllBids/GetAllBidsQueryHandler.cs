using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.Bids.Queries.GetAllBids;

public class GetAllBidsQueryHandler(IBidRepository bidRepository) : IRequestHandler<GetAllBidsQuery, IEnumerable<Bid>>
{
    public async Task<IEnumerable<Bid>> Handle(GetAllBidsQuery request, CancellationToken cancellationToken) => 
        await bidRepository.GetAllAsync();
}