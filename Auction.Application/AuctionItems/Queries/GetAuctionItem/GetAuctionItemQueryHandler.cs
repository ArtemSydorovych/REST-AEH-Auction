using Auction.Application.Dtos;
using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAuctionItem;

internal class GetAuctionItemQueryHandler(IAuctionItemRepository auctionRepository) : IRequestHandler<GetAuctionItemQuery, AuctionItem>
{
    public async Task<AuctionItem> Handle(GetAuctionItemQuery request, CancellationToken cancellationToken)
    {
        var auctionItem = await auctionRepository.GetByIdAsync(request.ItemId);

        return auctionItem;
    }
}