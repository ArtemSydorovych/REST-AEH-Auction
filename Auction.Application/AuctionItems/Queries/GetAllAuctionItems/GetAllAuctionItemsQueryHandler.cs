using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAllAuctionItems;

internal class GetAllAuctionItemsQueryHandler(IAuctionItemRepository auctionItemRepository) : IRequestHandler<GetAllAuctionItemsQuery, IEnumerable<AuctionItem>>
{
    public async Task<IEnumerable<AuctionItem>> Handle(GetAllAuctionItemsQuery request, CancellationToken cancellationToken)
    {
        var auctionItems = await auctionItemRepository.GetAllAsync();
        return auctionItems;
    }
    
}