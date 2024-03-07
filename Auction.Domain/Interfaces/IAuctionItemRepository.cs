using AuctionDomain.Entities;

namespace AuctionDomain.Interfaces;

public interface IAuctionItemRepository
{
    Task Add(AuctionItem auctionItem);
    Task<AuctionItem> GetById(int id);
    Task<IEnumerable<AuctionItem>> GetAll();
    Task<IEnumerable<AuctionItem>> GetBySellerId(int sellerId);
    Task<IEnumerable<AuctionItem>> GetByBidderId(int bidderId);
    Task Update(AuctionItem auctionItem);
    Task Delete(int id);
    
}