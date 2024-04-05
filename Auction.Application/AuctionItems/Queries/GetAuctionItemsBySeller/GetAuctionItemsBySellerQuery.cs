using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAuctionItemsBySeller;

public sealed record GetAuctionItemsBySellerQuery(int SellerId) : IRequest<IEnumerable<AuctionItem>>;