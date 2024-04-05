using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using AuctionDomain.ValueObjects;
using MediatR;

namespace Auction.Application.AuctionItems.Commands.UpdateAuctionItem;

public class UpdateAuctionItemCommandHandler(IAuctionItemRepository repository) : IRequestHandler<UpdateAuctionItemCommand, AuctionItem>
{
    public async Task<AuctionItem> Handle(UpdateAuctionItemCommand request, CancellationToken cancellationToken)
    {
        var auctionItem = new AuctionItem(
            request.Item.Title,
            request.Item.Description,
            new Money(request.Item.StartPrice),
            request.Item.StartTime,
            request.Item.EndTime,
            request.Item.SellerId);

        var updatedAuctionItem = await repository.UpdateAsync(auctionItem);

        return updatedAuctionItem;
    }
}