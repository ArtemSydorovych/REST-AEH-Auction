using Auction.Infrastructure.Converters;
using AuctionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistence.Postgres.Configurations;

public static partial class ModelBuilderExtensions 
{
    public static void ConfigureBid(this ModelBuilder modelBuilder) 
    {
        modelBuilder
            .Entity<Bid>()
            .Property(bid => bid.Amount)
            .HasConversion(new MoneyConverter());
    }
}