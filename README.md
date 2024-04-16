
## Design Patterns

Design patterns are reusable solutions to common problems in software design. They are templates that can be applied to different situations to solve recurring design problems in object-oriented software.

### Creational Patterns

Creational patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation. The basic form of object creation could result in design problems or added complexity to the design. Creational design patterns solve this problem by controlling the object creation.

1. [Singleton Pattern](#singleton-pattern)
2. [Factory Method Pattern](#factory-method-pattern)
3. [Abstract Factory Pattern](#abstract-factory-pattern)
4. [Builder Pattern](#builder-pattern)
5. [Prototype Pattern](#prototype-pattern)


### Structural Patterns

Structural patterns are concerned with how classes and objects can be composed to form larger structures. They focus on simplifying the structure of a software system by identifying relationships between objects.

1. [Adapter Pattern](#adapter-pattern)
2. [Bridge Pattern](#bridge-pattern)
3. [Composite Pattern](#composite-pattern)
4. [Decorator Pattern](#decorator-pattern)
5. [Facade Pattern](#facade-pattern)
6. [Flyweight Pattern](#flyweight-pattern)
7. [Proxy Pattern](#proxy-pattern)


### Behavioral Patterns

Behavioral patterns are concerned with algorithms and the assignment of responsibilities between objects. They describe not just patterns of objects or classes but also the patterns of communication between them.

1. [Chain of Responsibility Pattern](#chain-of-responsibility-pattern)
2. [Command Pattern](#command-pattern)
3. [Interpreter Pattern](#interpreter-pattern)
4. [Iterator Pattern](#iterator-pattern)
5. [Mediator Pattern](#mediator-pattern)
6. [Memento Pattern](#memento-pattern)
7. [Observer Pattern](#observer-pattern)
8. [State Pattern](#state-pattern)
9. [Strategy Pattern](#strategy-pattern)
10. [Template Method Pattern](#template-method-pattern)
11. [Visitor Pattern](#visitor-pattern)
12. [Dependency Injection Pattern](#dependency-injection-pattern)

### Singleton Pattern

### Definition
The Singleton pattern is a design pattern that restricts the instantiation of a class to a single
instance. This is useful when exactly one object is needed to coordinate actions across the system.

### Implementation
Lazy initialization in the Singleton pattern is a design approach where the instantiation of a Singleton object is deferred until the first time it is needed. This can be beneficial for performance reasons, especially when the Singleton object is resource-intensive to create, and it might not be needed during the application's runtime.

In C#, the `Lazy<T>` class is often used to implement lazy initialization. The `Lazy<T>` class provides support for lazy initialization with access from multiple threads being safe.

When you create a `Lazy<T>` object, you pass in the constructor of the object you want to instantiate. The `Lazy<T>` object then holds onto this constructor (in a delegate) but doesn't call it. The first time you access the `Value` property of the `Lazy<T>` object, it calls the constructor and stores the result. On subsequent accesses of the `Value` property, it simply returns the stored result.

Here's an example of how you can use the `Lazy<T>` class to implement lazy initialization in the Singleton pattern:

```csharp
public class Singleton
{
    private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

    public static Singleton Instance { get { return lazy.Value; } }

    private Singleton()
    {
    }

    public void DoSomething()
    {
        Console.WriteLine("Doing something...");
    }
}
```

### Real-World Examples
The Singleton pattern is widely used in real-world applications. Here are a few examples:

**Logging**: As in the example provided earlier, a logging utility could be a good candidate for a Singleton. This is because you typically want a single log file where all your log entries are made.

**Configuration Settings**: If your application reads configuration data from a file or a database, you might want to read this data just once and keep it in memory for quick access. A Singleton can be used to read the data and then provide an in-memory representation of the configuration data.

**Database Connections**: Creating a database connection is a time-consuming operation. And often, you only need one connection to your database. A Singleton can be used to create one connection and reuse it for all database operations.

**File Manager**: If your application involves heavy file operations, you might want to have a single point of control that can handle all file operations with the necessary access and locking mechanisms. A Singleton can be used to manage all file operations.

**Hardware Interface Access**: If your application is communicating with a piece of hardware like a printer or a serial port, you might want to ensure that only one object in your application has access to it at a time.

**Cache Management**: If your application involves caching data in memory, you might want to have a single cache manager that can handle all cache operations like adding, removing, and updating cache entries.


Remember, while Singleton can be useful, it's often considered an anti-pattern if not used carefully due to issues like difficulty in unit testing, global state and it can sometimes be an overkill if a simple static instance would suffice.

### Pattern Consequences

- Strict control over how and when clients access it.
- Avoids polluting the namespace with global variables.
- Subclassing allows configuring the application with an instance of the class you need at runtime.
- Multiple instances can be allowed without having to change the client code.
- Violates the Single Responsibility Principle by controlling its own creation and lifecycle.


### Top 5 Tips for Using the Singleton Pattern

**Use Lazy Initialization**: Use lazy initialization to defer the creation of the Singleton object until it's needed. This can help improve performance by avoiding unnecessary object creation.

**Ensure Thread Safety**: If your application is multi-threaded, make sure your Singleton implementation is thread-safe. One way to achieve this is by using the `Lazy<T>` class in C#.

**Avoid Global State**: Be cautious when using the Singleton pattern, as it can lead to global state in your application. Global state can make your code harder to test and maintain.

**Consider Dependency Injection**: If you find yourself needing to pass the Singleton instance to multiple classes, consider using dependency injection instead of relying on the Singleton pattern.

**Use Single Responsibility Principle**: Ensure that your Singleton class follows the Single Responsibility Principle. A Singleton class should have only one reason to change and should be responsible for only one thing.

Note : Before using the Singleton pattern, consider if there are better alternatives. Sometimes, a simple static class or a dependency injection container might be more appropriate for your needs.

### Related Patterns

Below are some design patterns that can be implemented as a singleton:

- Abstract Factory Pattern
- Builder Pattern 
- Prototype Pattern
- State Pattern


## Factory Method Pattern

### Definition
The Factory Method pattern is a creational design pattern that provides an interface for creating objects in a superclass but allows subclasses to alter the type of objects that will be created.

### Implementation
The Factory Method pattern is implemented by defining an interface for creating objects, but allowing subclasses to override the type of objects that will be created. This allows a class to defer instantiation to subclasses.

Here's an example of how you can implement the Factory Method pattern in C#:

```csharp
public interface IProduct
{
    void Operation();
}

public class ConcreteProductA : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Operation from ConcreteProductA");
    }
}

public class ConcreteProductB : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Operation from ConcreteProductB");
    }
}

public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}
```

In this example, `IProduct` is the interface for the products that will be created. `ConcreteProductA` and `ConcreteProductB` are concrete implementations of `IProduct`.

`Creator` is an abstract class that defines the `FactoryMethod` which returns an `IProduct`. `ConcreteCreatorA` and `ConcreteCreatorB` are concrete implementations of `Creator` that override the `FactoryMethod` to return `ConcreteProductA` and `ConcreteProductB` respectively.

### Use Cases

 - When a class can't anticipate the class of objects it must create.
 - When a class wants its subclasses to specify the objects it creates.
 - When a class delegates the responsibility of object creation to one of several helper subclasses.
 - When a class localizes the knowledge of which class gets created.

### Real-World Examples
The Factory Method pattern is widely used in real-world applications. Here are a few examples:

**Document Processing**: Consider a document processing application that needs to create different types of documents like PDFs, Word documents, and Excel sheets. The Factory Method pattern can be used to create a `Document` interface and concrete implementations like `PDFDocument`, `WordDocument`, and `ExcelDocument`.

**Payment Gateways**: Payment gateway integrations often involve creating different payment gateway objects based on the selected payment method. The Factory Method pattern can be used to create payment gateway objects based on the selected payment method.

**Logging Libraries**: Logging libraries that support multiple logging destinations like files, databases, and cloud services can use the Factory Method pattern to create different loggers based on the selected destination.

**UI Components**: UI component libraries that provide different types of buttons, text boxes, and dropdowns can use the Factory Method pattern to create instances of these components based on user requirements.

**Database Connection Factories**: Database connection factories that create database connections based on the selected database type (SQL Server, MySQL, Oracle, etc.) can use the Factory Method pattern to create database connection objects.

**Report Generation**: Report generation libraries that support different report formats like PDF, Excel, and HTML can use the Factory Method pattern to create report objects based on the selected format.

**Notification Services**: Notification services that support different notification channels like email, SMS, and push notifications can use the Factory Method pattern to create notification objects based on the selected channel.

**Data Import/Export**: Data import/export utilities that support different data formats like CSV, XML, and JSON can use the Factory Method pattern to create data objects based on the selected format.

**Authentication Providers**: Authentication providers that support different authentication methods like username/password, OAuth, and SAML can use the Factory Method pattern to create authentication objects based on the selected method.

### Top 5 Tips for Using the Factory Method Pattern

**Define an Interface**: Define an interface for the products that will be created by the Factory Method. This allows you to create different types of products without changing the client code.

**Use Inheritance**: Use inheritance to define the Factory Method in a superclass and allow subclasses to override it. This allows subclasses to provide different implementations of the Factory Method.

**Encapsulate Object Creation**: Encapsulate object creation in the Factory Method to decouple the client code from the concrete implementations of the products. This allows you to change the product types without affecting the client code.

**Use Dependency Injection**: Use dependency injection to inject the Factory Method implementation into the client code. This allows you to change the Factory Method implementation at runtime.

**Consider the Abstract Factory Pattern**: If you need to create families of related objects, consider using the Abstract Factory pattern instead of the Factory Method pattern. The Abstract Factory pattern provides an interface for creating families of related objects without specifying their concrete classes.

