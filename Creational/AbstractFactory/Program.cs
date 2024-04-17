using AbstractFactory.Implementations;

namespace AbstractFactory;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        ICustomerFactory premiumCustomerFactory = new PremiumCustomerFactory();

        IPricingStrategy premiumCustomerPricingStrategy = premiumCustomerFactory.CreatePricingStrategy();
        decimal premiumCustomerPrice = premiumCustomerPricingStrategy.CalculatePrice(100); // $90 for premium customers

        IShippingCostStrategy premiumCustomerShippingCostStrategy = premiumCustomerFactory.CreateShippingCostStrategy();
        decimal premiumCustomerShippingCost =
            premiumCustomerShippingCostStrategy.CalculateShippingCost(50); // $25 for premium customers

        Console.WriteLine(
            $"Total cost: {premiumCustomerPrice + premiumCustomerShippingCost}"); // $115 for premium customers

        ICustomerFactory regularCustomerFactory = new RegularCustomerFactory();

        IPricingStrategy regularCustomerPricingStrategy = regularCustomerFactory.CreatePricingStrategy();
        decimal regularCustomerPrice = regularCustomerPricingStrategy.CalculatePrice(100); // $100 for regular customers

        IShippingCostStrategy regularCustomerShippingCostStrategy = regularCustomerFactory.CreateShippingCostStrategy();
        decimal regularCustomerShippingCost =
            regularCustomerShippingCostStrategy.CalculateShippingCost(50); // $30 for regular customers

        Console.WriteLine(
            $"Total cost: {regularCustomerPrice + regularCustomerShippingCost}"); // $130 for regular customers

        IUIThemeFactory darkThemeFactory = new DarkThemeFactory();

        IButton button = darkThemeFactory.CreateButton();
        button.Render();

        ICheckbox checkbox = darkThemeFactory.CreateCheckbox();
        checkbox.Render();

        IUIThemeFactory lightThemeFactory = new LightThemeFactory();

        IButton lightButton = lightThemeFactory.CreateButton();
        button.Render();

        ICheckbox lightCheckbox = lightThemeFactory.CreateCheckbox();
        checkbox.Render();
    }
}