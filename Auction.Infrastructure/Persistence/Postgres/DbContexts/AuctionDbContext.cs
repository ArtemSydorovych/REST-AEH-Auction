using Auction.Infrastructure.Persistence.Postgres.Configurations;
using AuctionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistence.Postgres.DbContexts;

public class AuctionDbContext(DbContextOptions<AuctionDbContext> options) : DbContext(options)
{
    public DbSet<AuctionItem> AuctionItems { get; set; }
    public DbSet<Bid> Bids { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureAuctionItem();
        modelBuilder.ConfigureBid();
    }}