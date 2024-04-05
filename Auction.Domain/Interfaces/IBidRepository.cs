using AuctionDomain.Entities;

namespace AuctionDomain.Interfaces;

public interface IBidRepository
{
    Task<Bid> AddAsync(Bid bid);
    Task<Bid> GetByIdAsync(int id);
    Task<IEnumerable<Bid>> GetAllAsync();
    Task DeleteAsync(int id);
}