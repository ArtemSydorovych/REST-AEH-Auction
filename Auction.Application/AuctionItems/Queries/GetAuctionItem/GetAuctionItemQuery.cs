using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAuctionItem;

public sealed record GetAuctionItemQuery(int ItemId) : IRequest<AuctionItem>;