namespace Factory.Implementations;

public interface IPaymentProcessor
{
    void ProcessPayment(string payment);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(string payment)
    {
        // Process credit card payment
        Console.WriteLine("Processing credit card payment: " + payment);
    }
}

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(string payment)
    {
        // Process PayPal payment
        Console.WriteLine("Processing PayPal payment: " + payment);
    }
}

public abstract class PaymentProcessorFactory
{
    public abstract IPaymentProcessor CreatePaymentProcessor();
}

public class CreditCardPaymentProcessorFactory : PaymentProcessorFactory
{
    public override IPaymentProcessor CreatePaymentProcessor()
    {
        return new CreditCardPaymentProcessor();
    }
}

public class PayPalPaymentProcessorFactory : PaymentProcessorFactory
{
    public override IPaymentProcessor CreatePaymentProcessor()
    {
        return new PayPalPaymentProcessor();
    }
}
