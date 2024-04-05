using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using AuctionDomain.ValueObjects;
using MediatR;

namespace Auction.Application.AuctionItems.Commands.AddAuctionItem;

public class AddAuctionItemCommandHandler(IAuctionItemRepository repository) : IRequestHandler<AddAuctionItemCommand, AuctionItem>
{
    public async Task<AuctionItem> Handle(AddAuctionItemCommand request, CancellationToken cancellationToken)
    {
        var auctionItem = new AuctionItem 
        (
            request.Item.Title,
            request.Item.Description,
            new Money(request.Item.StartPrice),
            request.Item.StartTime,
            request.Item.EndTime,
            request.Item.SellerId
        );

        var addedItem = await repository.AddAsync(auctionItem);

        return addedItem;
    }
}