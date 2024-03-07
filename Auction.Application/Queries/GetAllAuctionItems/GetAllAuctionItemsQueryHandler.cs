using Auction.Application.Queries.GetAuctionItem;
using AuctionApi.Dtos;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.Queries.GetAllAuctionItems;

internal class GetAllAuctionItemsQueryHandler(IAuctionItemRepository auctionItemRepository) : IRequestHandler<GetAllAuctionItemsQuery, IEnumerable<AuctionItemDto>>
{
    public async Task<IEnumerable<AuctionItemDto>> Handle(GetAllAuctionItemsQuery request, CancellationToken cancellationToken)
    {
        var auctionItems = await auctionItemRepository.GetAll();
        
        var auctionItemsToReturn = auctionItems.Select(item => new AuctionItemDto
        (
            item.Id,
            item.Title,
            item.Description,
            item.StartPrice.Amount,
            item.StartTime,
            item.EndTime,
            item.SellerId
        )).ToList();
            
        return auctionItemsToReturn;
    }
    
}