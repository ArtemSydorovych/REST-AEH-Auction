using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAuctionItemsByBidder;

public sealed record GetAuctionItemsByBidderQuery(int BidderId) : IRequest<IEnumerable<AuctionItem>>;