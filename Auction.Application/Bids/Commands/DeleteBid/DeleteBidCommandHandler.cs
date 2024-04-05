using AuctionDomain.Interfaces;
using MediatR;

namespace Auction.Application.Bids.Commands.DeleteBid;

public class DeleteBidCommandHandler(IBidRepository repository) : IRequestHandler<DeleteBidCommand>
{
    public async Task Handle(DeleteBidCommand request, CancellationToken cancellationToken) => 
        await repository.DeleteAsync(request.Id);
}