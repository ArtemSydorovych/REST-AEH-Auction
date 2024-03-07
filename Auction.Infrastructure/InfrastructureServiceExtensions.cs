using Auction.Infrastructure.Persistence.Postgres.DbContexts;
using Auction.Infrastructure.Repositories;
using AuctionDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auction.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuctionDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("AuctionDb"));
        });
        
        services.AddSingleton<IAuctionItemRepository, AuctionItemRepository>();
    }
}