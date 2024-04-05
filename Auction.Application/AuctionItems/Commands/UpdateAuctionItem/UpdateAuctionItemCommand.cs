using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.AuctionItems.Commands.UpdateAuctionItem;

public sealed record UpdateAuctionItemCommand(AuctionItemDto Item) : IRequest<AuctionItem>;