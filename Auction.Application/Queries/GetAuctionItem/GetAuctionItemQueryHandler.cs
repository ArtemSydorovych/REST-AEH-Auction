using AuctionApi.Dtos;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.Queries.GetAuctionItem;

internal class GetAuctionItemQueryHandler(IAuctionItemRepository auctionRepository) : IRequestHandler<GetAuctionItemQuery, AuctionItemDto>
{
    public async Task<AuctionItemDto> Handle(GetAuctionItemQuery request, CancellationToken cancellationToken)
    {
        var auctionItem = await auctionRepository.GetById(request.Id);
        var auctionItemDto = new AuctionItemDto
        (
            auctionItem.Id,
            auctionItem.Title,
            auctionItem.Description,
            auctionItem.StartPrice.Amount,
            auctionItem.StartTime,
             auctionItem.EndTime,
             auctionItem.SellerId
        );

        return auctionItemDto;
    }
}