using Auction.Application.Dtos;
using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAuctionItemsByBidder;

internal class GetAuctionItemsByBidderQueryHandler(IAuctionItemRepository auctionRepository) : IRequestHandler<GetAuctionItemsByBidderQuery, IEnumerable<AuctionItem>>
{
    public async Task<IEnumerable<AuctionItem>> Handle(GetAuctionItemsByBidderQuery request, CancellationToken cancellationToken)
    {
        var auctionItems = await auctionRepository.GetByBidderIdAsync(request.BidderId);
        return auctionItems;
    }
}