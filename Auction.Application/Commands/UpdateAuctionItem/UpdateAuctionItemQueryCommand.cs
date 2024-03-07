using AuctionApi.Dtos;
using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.Commands.UpdateAuctionItem;

public sealed record UpdateAuctionItemQueryCommand(AuctionItemDto Item) : IRequest<AuctionItem>;