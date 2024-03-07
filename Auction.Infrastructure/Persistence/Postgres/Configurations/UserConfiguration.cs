using Auction.Infrastructure.Converters;
using AuctionDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Infrastructure.Persistence.Postgres.Configurations;

public static partial class ModelBuilderExtensions 
{
    public static void ConfigureUser(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .HasConversion(new EmailConverter());
    }
}