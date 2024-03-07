using Auction.Infrastructure.Converters;
using Auction.Infrastructure.Persistence.Postgres.Configurations;
using AuctionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistence.Postgres.DbContexts;

public class AuctionDbContext(DbContextOptions<AuctionDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<AuctionItem> AuctionItems { get; set; }
    public DbSet<Bid> Bids { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureAuctionItem();
        modelBuilder.ConfigureBid();
    }}