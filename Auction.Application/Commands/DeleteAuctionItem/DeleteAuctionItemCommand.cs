using MediatR;

namespace Auction.Application.Commands.DeleteAuctionItem;

public sealed record DeleteAuctionItemCommand(int Id) : IRequest<Unit>; 