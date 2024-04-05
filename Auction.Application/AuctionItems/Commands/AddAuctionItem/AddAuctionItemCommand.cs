using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.AuctionItems.Commands.AddAuctionItem;

public sealed record AddAuctionItemCommand(AuctionItemDto Item) : IRequest<AuctionItem>;