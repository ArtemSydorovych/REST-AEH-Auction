using Auction.Application.AuctionItems;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Application;

public static class ApplicationServiceExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
      services.AddAuctionItemsCommandAndQueries();

    }
}