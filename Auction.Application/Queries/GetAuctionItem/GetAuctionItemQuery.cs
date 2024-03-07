using AuctionApi.Dtos;
using MediatR;

namespace Auction.Application.Queries.GetAuctionItem;

public sealed record GetAuctionItemQuery(int Id) : IRequest<AuctionItemDto>;