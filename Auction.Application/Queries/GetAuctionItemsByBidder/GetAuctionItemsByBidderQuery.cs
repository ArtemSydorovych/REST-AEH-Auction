using AuctionApi.Dtos;
using MediatR;

namespace Auction.Application.Queries.GetAuctionItemsByBidder;

public sealed record GetAuctionItemsByBidderQuery(int Id) : IRequest<IEnumerable<AuctionItemDto>>;