using AuctionDomain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Auction.Infrastructure.Converters;

public class MoneyConverter() : ValueConverter<Money, decimal>(money => money.Amount, amount => new Money(amount));