using AuctionDomain.Entities;
using AuctionDomain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Repositories;

public class AuctionItemRepository(DbSet<AuctionItem> auctionItems) : IAuctionItemRepository
{
    public async Task Add(AuctionItem auctionItem)
    {
        await auctionItems.AddAsync(auctionItem);
    }

    public async Task<AuctionItem> GetById(int id)
    {
        return (await auctionItems.FindAsync(id))!;
    }

    public async Task<IEnumerable<AuctionItem>> GetAll()
    {
        return await auctionItems.ToListAsync();
    }

    public async Task<IEnumerable<AuctionItem>> GetBySellerId(int sellerId)
    {
        return await auctionItems.Where(x => x.SellerId == sellerId).ToListAsync();
    }

    public async Task<IEnumerable<AuctionItem>> GetByBidderId(int bidderId)
    {
        return await auctionItems.Where(x => x.Bids.Any(b => b.Id == bidderId)).ToListAsync();
    }

    public async Task Update(AuctionItem auctionItem)
    {
        var item = await auctionItems.FindAsync(auctionItem.Id);
        if (item is null)
        {
            return;
        }

        item.Title = auctionItem.Title;
        item.Description = auctionItem.Description;
        item.StartPrice = auctionItem.StartPrice;
        item.StartTime = auctionItem.StartTime;
        item.EndTime = auctionItem.EndTime;
        item.Seller = auctionItem.Seller;
        item.SellerId = auctionItem.SellerId;
    }

    public async Task Delete(int id)
    {
        var item = await auctionItems.FindAsync(id);
        if (item is not null)
        {
            auctionItems.Remove(item);
        }
    }
}