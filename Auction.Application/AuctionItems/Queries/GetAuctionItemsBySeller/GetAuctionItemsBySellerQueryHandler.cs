using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAuctionItemsBySeller;

internal class GetAuctionItemsBySellerQueryHandler(IAuctionItemRepository auctionRepository) : IRequestHandler<GetAuctionItemsBySellerQuery, IEnumerable<AuctionItem>>
{
    public async Task<IEnumerable<AuctionItem>> Handle(GetAuctionItemsBySellerQuery request, CancellationToken cancellationToken)
    {
        var auctionItems = await auctionRepository.GetBySellerIdAsync(request.SellerId);

        return auctionItems;
    }
}