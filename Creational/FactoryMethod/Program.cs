using Factory.Implementations;

namespace Factory;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        // Create a factory for console loggers
        LoggerFactory loggerFactory = new ConsoleLoggerFactory();

        // Use the factory to create a console logger
        var logger = loggerFactory.CreateLogger();

        // Use the logger
        logger.LogMessage("Hello, Factory Method!");
        
        // Create a factory for CreditCardPaymentProcessor
        PaymentProcessorFactory paymentProcessorFactory = new CreditCardPaymentProcessorFactory();
        
        // Use the factory to create a CreditCardPaymentProcessor
        var paymentProcessor = paymentProcessorFactory.CreatePaymentProcessor();
        
        // Use the paymentProcessor
        paymentProcessor.ProcessPayment("Payment Details");

    }
}