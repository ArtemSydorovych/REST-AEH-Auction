using Auction.Application.AuctionItems;
using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Application;

public static class ApplicationServiceExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
      services.AddAuctionItemsCommandAndQueries();

    }
}