using AuctionDomain.Entities;

namespace AuctionDomain.Interfaces;

public interface IAuctionItemRepository
{
    Task<AuctionItem> AddAsync(AuctionItem auctionItem);
    Task<AuctionItem> GetByIdAsync(int id);
    Task<IEnumerable<AuctionItem>> GetAllAsync();
    Task<IEnumerable<AuctionItem>> GetBySellerIdAsync(int sellerId);
    Task<IEnumerable<AuctionItem>> GetByBidderIdAsync(int bidderId);
    Task<AuctionItem> UpdateAsync(AuctionItem auctionItem);
    Task DeleteAsync(int id);
    
}