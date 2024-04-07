using Auction.Infrastructure.Persistence.Postgres.DbContexts;
using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Repositories;

public class AuctionItemRepository(AuctionDbContext dbContext) : IAuctionItemRepository
{
    public async Task<AuctionItem> AddAsync(AuctionItem auctionItem)
    {
        var auctionItemEntry = await dbContext.AuctionItems.AddAsync(auctionItem);
        return auctionItemEntry.Entity;
    }

    public async Task<AuctionItem> GetByIdAsync(int id) => (await dbContext.AuctionItems.FindAsync(id))!;

    public async Task<IEnumerable<AuctionItem>> GetAllAsync() => await dbContext.AuctionItems.ToListAsync();

    public async Task<IEnumerable<AuctionItem>> GetBySellerIdAsync(int sellerId) => await dbContext.AuctionItems.Where(x => x.SellerId == sellerId).ToListAsync();

    public async Task<IEnumerable<AuctionItem>> GetByBidderIdAsync(int bidderId) => 
        await dbContext.AuctionItems.Where(x => x.Bids.Any(b => b.Id == bidderId)).ToListAsync();

    public async Task<AuctionItem> UpdateAsync(AuctionItem auctionItem)
    {
        var item = await dbContext.AuctionItems.FindAsync(auctionItem.Id);
        if (item is null)
        {
            return auctionItem;
        }

        item.Title = auctionItem.Title;
        item.Description = auctionItem.Description;
        item.StartPrice = auctionItem.StartPrice;
        item.StartTime = auctionItem.StartTime;
        item.EndTime = auctionItem.EndTime;
        item.SellerId = auctionItem.SellerId;

        var auctionItemEntry = dbContext.AuctionItems.Update(item);

        return auctionItemEntry.Entity;
    }

    public async Task DeleteAsync(int id)
    {
        var item = await dbContext.AuctionItems.FindAsync(id);
        if (item is not null)
        {
            dbContext.AuctionItems.Remove(item);
            await dbContext.SaveChangesAsync();
        }
    }
}