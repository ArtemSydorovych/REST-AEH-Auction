using MediatR;

namespace Auction.Application.AuctionItems.Commands.DeleteAuctionItem;

public sealed record DeleteAuctionItemCommand(int Id) : IRequest<Unit>; 