using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.AuctionItems.Commands.DeleteAuctionItem;

public class DeleteAuctionItemCommandHandler(IAuctionItemRepository repository) : IRequestHandler<DeleteAuctionItemCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAuctionItemCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);

        return new Unit();
    }
}