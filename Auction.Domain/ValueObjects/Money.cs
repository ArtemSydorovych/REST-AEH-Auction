namespace AuctionDomain.ValueObjects;

public sealed class Money
{
    public decimal Amount { get; set; }
    
    public Money(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative", nameof(amount));
        }
        Amount = amount;
    }

    public static Money operator +(Money m1, Money m2) => new (m1.Amount + m2.Amount);
    public static Money operator -(Money m1, Money m2) => new (m1.Amount - m2.Amount);
    public static Money operator *(Money m1, decimal multiplier) => new (m1.Amount * multiplier);
    
}