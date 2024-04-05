using Auction.Infrastructure.Persistence.Postgres.DbContexts;
using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Repositories;

internal sealed class BidRepository(AuctionDbContext auctionDbContext) : IBidRepository
{
    public async Task<Bid> AddAsync(Bid bid)
    {
        var entry = await auctionDbContext.Bids.AddAsync(bid);
        SaveChanges();

        return entry.Entity;
    }

    public async Task<Bid> GetByIdAsync(int id) => (await auctionDbContext.Bids.FindAsync(id))!;

    public async Task<IEnumerable<Bid>> GetAllAsync() => await auctionDbContext.Bids.ToListAsync();

    public async Task DeleteAsync(int id)
    {
        var bid = await auctionDbContext.Bids.FindAsync(id);
        auctionDbContext.Bids.Remove(bid!);
        await auctionDbContext.SaveChangesAsync();
    }
    
    private void SaveChanges() => auctionDbContext.SaveChangesAsync();
}