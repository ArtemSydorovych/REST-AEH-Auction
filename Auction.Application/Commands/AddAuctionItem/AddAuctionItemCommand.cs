using AuctionApi.Dtos;
using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.Commands.AddAuctionItem;

public sealed record AddAuctionItemCommand(AuctionItemDto Item) : IRequest<AuctionItem>;