using AuctionDomain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Auction.Infrastructure.Converters;

public class EmailConverter() : ValueConverter<Email, string>(email => email.Value, value => new Email(value));