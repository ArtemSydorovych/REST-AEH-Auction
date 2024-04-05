using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using AuctionDomain.ValueObjects;
using MediatR;

namespace Auction.Application.Bids.Commands.AddBid;

public sealed class AddBidCommandHandler(
    IBidRepository repository,
    IAuctionItemRepository auctionItemRepository,
    IUserRepository userRepository)
    : IRequestHandler<AddBidCommand, Bid>
{

    public async Task<Bid> Handle(AddBidCommand request, CancellationToken cancellationToken)
    {
        var auctionItem = await auctionItemRepository.GetByIdAsync(request.BidDto.AuctionItemId);
        var bidder = await userRepository.GetByIdAsync(request.BidDto.BidderId);

        var bid = new Bid
        {
            AuctionItem = auctionItem,
            Amount = new Money(request.BidDto.Amount),
            Bidder = bidder,
            Timestamp = DateTime.Now
        };

        var addedBid = await repository.AddAsync(bid);

        return addedBid;
    }
}