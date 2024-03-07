using Auction.Application.Queries.GetAuctionItem;
using AuctionApi.Dtos;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.Queries.GetAuctionItemsByBidder;

internal class GetAuctionItemsByBidderQueryHandler(IAuctionItemRepository auctionRepository) : IRequestHandler<GetAuctionItemsByBidderQuery, IEnumerable<AuctionItemDto>>
{
    public async Task<IEnumerable<AuctionItemDto>> Handle(GetAuctionItemsByBidderQuery request, CancellationToken cancellationToken)
    {
        var auctionItems = await auctionRepository.GetByBidderId(request.Id);
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