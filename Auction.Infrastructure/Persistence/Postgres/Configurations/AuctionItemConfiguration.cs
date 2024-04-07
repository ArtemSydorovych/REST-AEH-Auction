using Auction.Infrastructure.Converters;
using AuctionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistence.Postgres.Configurations;


public static partial class ModelBuilderExtensions 
{
    public static void ConfigureAuctionItem(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<AuctionItem>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<AuctionItem>()
            .Property(item => item.SellerId)
            .HasColumnType("integer");
        
        modelBuilder.Entity<AuctionItem>()
            .Property(item => item.Title)
            .HasColumnType("varchar(100)");
        
        modelBuilder.Entity<AuctionItem>()
            .Property(item => item.Description)
            .HasColumnType("text");  
        
        modelBuilder.Entity<AuctionItem>()
            .Property(item => item.StartTime)
            .HasColumnType("date");
        
        modelBuilder.Entity<AuctionItem>()
            .Property(item => item.EndTime)
            .HasColumnType("date");
        
        modelBuilder.Entity<AuctionItem>()
            .HasMany(x => x.Bids)
            .WithOne(x => x.AuctionItem);
        
        modelBuilder
            .Entity<AuctionItem>()
            .Property(item => item.StartPrice)
            .HasConversion(new MoneyConverter());
    }
}