// In this example, an online shopping cart where we have two types of customers: Regular and Premium.
// Each customer type has a different pricing strategy and shipping cost calculation method. 
// Abstract Factory pattern is used to create these different types of customers and their associated calculations.

namespace AbstractFactory.Implementations;

/// <summary>
/// Abstract Factory
/// </summary>
public interface ICustomerFactory
{
    IPricingStrategy CreatePricingStrategy();
    IShippingCostStrategy CreateShippingCostStrategy();
}

/// <summary>
/// Abstract product A
/// </summary>
public interface IPricingStrategy
{
    decimal CalculatePrice(decimal price);
}

/// <summary>
/// Abstract product B
/// </summary>
public interface IShippingCostStrategy
{
    decimal CalculateShippingCost(int distance);
}

/// <summary>
/// Concrete product A1
/// </summary>
public class RegularPricingStrategy : IPricingStrategy
{
    public decimal CalculatePrice(decimal price)
    {
        // No discount for regular customers
        return price;
    }
}

/// <summary>
/// Concrete product A2
/// </summary>
public class PremiumPricingStrategy : IPricingStrategy
{
    public decimal CalculatePrice(decimal price)
    {
        // 10% discount for premium customers
        return price * 0.9m;
    }
}

/// <summary>
/// Concrete product B1
/// </summary>
public class RegularShippingCostStrategy : IShippingCostStrategy
{
    public decimal CalculateShippingCost(int distance)
    {
        // Regular customers pay $1 per km
        return distance * 1.0m;
    }
}

/// <summary>
/// Concrete product B2
/// </summary>
public class PremiumShippingCostStrategy : IShippingCostStrategy
{
    public decimal CalculateShippingCost(int distance)
    {
        // Premium customers pay $0.5 per km
        return distance * 0.5m;
    }
}

/// <summary>
/// Concrete Factory 1
/// </summary>
public class RegularCustomerFactory : ICustomerFactory
{
    public IPricingStrategy CreatePricingStrategy()
    {
        return new RegularPricingStrategy();
    }

    public IShippingCostStrategy CreateShippingCostStrategy()
    {
        return new RegularShippingCostStrategy();
    }
}

/// <summary>
/// Concrete Factory 2
/// </summary>
public class PremiumCustomerFactory : ICustomerFactory
{
    public IPricingStrategy CreatePricingStrategy()
    {
        return new PremiumPricingStrategy();
    }

    public IShippingCostStrategy CreateShippingCostStrategy()
    {
        return new PremiumShippingCostStrategy();
    }
}