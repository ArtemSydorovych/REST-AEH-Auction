using AuctionDomain.Entities;

namespace AuctionDomain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
}