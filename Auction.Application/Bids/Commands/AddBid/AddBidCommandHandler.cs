using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using AuctionDomain.ValueObjects;
using MediatR;

namespace Auction.Application.Bids.Commands.AddBid;

public sealed class AddBidCommandHandler(
    IBidRepository repository,
    IAuctionItemRepository auctionItemRepository)
    : IRequestHandler<AddBidCommand, Bid>
{

    public async Task<Bid> Handle(AddBidCommand request, CancellationToken cancellationToken)
    {
        var auctionItem = await auctionItemRepository.GetByIdAsync(request.BidDto.AuctionItemId);

        var bid = new Bid
        {
            AuctionItem = auctionItem,
            Amount = new Money(request.BidDto.Amount),
            BidderId = request.BidDto.BidderId,
            Timestamp = DateTime.Now
        };

        var addedBid = await repository.AddAsync(bid);

        return addedBid;
    }
}