using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;

namespace Auction.Application.AuctionItems.Queries.GetAllAuctionItems;

public sealed record GetAllAuctionItemsQuery : IRequest<IEnumerable<AuctionItem>>;