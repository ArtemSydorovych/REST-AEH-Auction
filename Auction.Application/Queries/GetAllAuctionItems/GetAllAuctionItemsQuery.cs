using AuctionApi.Dtos;
using MediatR;

namespace Auction.Application.Queries.GetAllAuctionItems;

public sealed record GetAllAuctionItemsQuery : IRequest<IEnumerable<AuctionItemDto>>;