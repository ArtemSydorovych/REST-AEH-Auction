using Auction.Application.AuctionItems.Commands.AddAuctionItem;
using Auction.Application.AuctionItems.Commands.DeleteAuctionItem;
using Auction.Application.AuctionItems.Commands.UpdateAuctionItem;
using Auction.Application.AuctionItems.Queries.GetAllAuctionItems;
using Auction.Application.AuctionItems.Queries.GetAuctionItem;
using Auction.Application.AuctionItems.Queries.GetAuctionItemsByBidder;
using Auction.Application.AuctionItems.Queries.GetAuctionItemsBySeller;
using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Application.AuctionItems;

public static class AuctionItemsServiceExtensions
{
    public static void AddAuctionItemsCommandAndQueries(this IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<GetAllAuctionItemsQuery, IEnumerable<AuctionItem>>, GetAllAuctionItemsQueryHandler>()
            .AddTransient<IRequestHandler<GetAuctionItemsBySellerQuery, IEnumerable<AuctionItem>>, GetAuctionItemsBySellerQueryHandler>()
            .AddTransient<IRequestHandler<GetAuctionItemsByBidderQuery, IEnumerable<AuctionItem>>, GetAuctionItemsByBidderQueryHandler>()
            .AddTransient<IRequestHandler<GetAuctionItemQuery, AuctionItem>, GetAuctionItemQueryHandler>()
            .AddTransient<IRequestHandler<AddAuctionItemCommand, AuctionItem>, AddAuctionItemCommandHandler>()
            .AddTransient<IRequestHandler<UpdateAuctionItemCommand, AuctionItem>, UpdateAuctionItemCommandHandler>()
            .AddTransient<IRequestHandler<DeleteAuctionItemCommand, Unit>, DeleteAuctionItemCommandHandler>();
    }
}