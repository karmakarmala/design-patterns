
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

- Abstract Factory Pattern : A Singleton can be implemented using the Abstract Factory pattern to ensure that only one instance of the factory is created.
- Builder Pattern : The Builder pattern can be used to create complex Singleton objects with multiple configuration options.
- Prototype Pattern : The Prototype pattern can be used to create new instances of a Singleton object by cloning an existing instance.
- State Pattern : The State pattern can be used to change the behavior of a Singleton object based on its internal state.

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

### Pattern Consequences

- Eliminates the need to bind application-specific classes into the code.
- New types of products can be introduced without changing the client code (Open/Closed Principle).
- Creating products is moved to one specific place in the code, the creator (Single Responsibility Principle).
- Client might need to create  subclasses of the creator to create a particular ConcreteProduct object.

### Related Patterns

- Abstract Factory Pattern : Often implemented with Factory Methods to create families of related objects.
- Prototype Pattern : No subclassing is required, but an initialize action on Product  is often required.
- Template Method Pattern : Factory methods are often called within template methods.

## Abstract Factory Pattern

### Definition
The Abstract Factory pattern is a creational design pattern that provides an interface for creating families of related or dependent objects without specifying their concrete classes.

### Implementation
The Abstract Factory pattern is implemented by defining an abstract class or interface for creating families of related or dependent objects. Subclasses or implementations of the abstract class or interface provide concrete implementations of the objects.

Here's an example of how you can implement the Abstract Factory pattern in C#:

```csharp
public interface IButton
{
    void Paint();
}

public class WinButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Painting a Windows button");
    }
}

public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Painting a Mac button");
    }
}

public interface IGUIFactory
{
    IButton CreateButton();
}

public class WinFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WinButton();
    }
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }
}
```

In this example, `IButton` is the interface for the buttons that will be created. `WinButton` and `MacButton` are concrete implementations of `IButton`.

`IGUIFactory` is the interface for the factories that will create the buttons. `WinFactory` and `MacFactory` are concrete implementations of `IGUIFactory` that create `WinButton` and `MacButton` respectively.

### Use Cases

- When a system should be independent of how its products are created, composed, and represented.
- When a system should be configured with multiple families of products.
- When a family of related product objects is designed to be used together, and you need to enforce this constraint.
- When you want to provide a class library of products, and you want to reveal just their interfaces, not their implementations.

### Real-World Examples
The Abstract Factory pattern is widely used in real-world applications. Here are a few examples:

**UI Component Libraries**: UI component libraries that provide different types of buttons, text boxes, and dropdowns can use the Abstract Factory pattern to create instances of these components based on the selected theme (Windows, Mac, etc.).

**Language Localization**: Applications that support multiple languages can use the Abstract Factory pattern to create language-specific resources like strings, images, and fonts based on the selected language.

**Document Processing**: Document processing applications that need to create different types of documents like PDFs, Word documents, and Excel sheets can use the Abstract Factory pattern to create a `DocumentFactory` interface and concrete implementations like `PDFDocumentFactory`, `WordDocumentFactory`, and `ExcelDocumentFactory`.

**Database Providers**: Database providers that support multiple database types like SQL Server, MySQL, and Oracle can use the Abstract Factory pattern to create database connection objects based on the selected database type.

### Top 5 Tips for Using the Abstract Factory Pattern

**Define an Interface**: Define an interface for the families of related objects that will be created by the Abstract Factory. This allows you to create different families of objects without changing the client code.

**Use Inheritance**: Use inheritance to define the Abstract Factory in a superclass and allow subclasses to override it. This allows subclasses to provide different implementations of the Abstract Factory.

**Encapsulate Object Creation**: Encapsulate object creation in the Abstract Factory to decouple the client code from the concrete implementations of the objects. This allows you to change the object types without affecting the client code.

**Use Dependency Injection**: Use dependency injection to inject the Abstract Factory implementation into the client code. This allows you to change the Abstract Factory implementation at runtime.

**Consider the Factory Method Pattern**: If you need to create individual objects instead of families of related objects, consider using the Factory Method pattern instead of the Abstract Factory pattern. The Factory Method pattern provides an interface for creating individual objects without specifying their concrete classes.

### Pattern Consequences

- Isolates concrete classes.
- Makes exchanging product families easy.
- Promotes consistency among products.
- Supports open/closed principle.
- Can be difficult to support new kinds of products.

### Related Patterns

- Factory Method Pattern : Often implemented with Abstract Factory to create families of related objects.
- Prototype Pattern : No subclassing is required, but an initialize action on Product  is often required.
- Singleton Pattern : Abstract Factories are often Singletons.

## Builder Pattern

### Definition

The Builder pattern is a creational design pattern that allows you to construct complex objects step by step. 
The pattern separates the construction of a complex object from its representation, allowing the same construction process to create different representations.

### Implementation

The Builder pattern is implemented by defining a `Builder` interface that specifies the steps to build the complex object. Concrete implementations of the `Builder` interface 
provide the step-by-step construction process for the complex object.

Here's an example of how you can implement the Builder pattern in C#:

```csharp
public class Product
{
    private List<string> parts = new List<string>();

    public void AddPart(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("Product Parts:");
        foreach (string part in parts)
        {
            Console.WriteLine(part);
        }
    }
}

public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Product GetProduct();
}

public class ConcreteBuilder : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.AddPart("Part A");
    }

    public void BuildPartB()
    {
        product.AddPart("Part B");
    }

    public void BuildPartC()
    {
        product.AddPart("Part C");
    }

    public Product GetProduct()
    {
        return product;
    }
}

public class Director
{
    private IBuilder builder;

    public Director(IBuilder builder)
    {
        this.builder = builder;
    }

    public void Construct()
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }
}
```

In this example, `Product` is the complex object that will be constructed. `IBuilder` is the interface for the builders that will construct the `Product`.

`ConcreteBuilder` is a concrete implementation of `IBuilder` that provides the step-by-step construction process for the `Product`.

`Director` is a class that directs the construction process by calling the builder's methods in the correct order.

### Use Cases

- When the construction of a complex object should be independent of the object's representation.
- When the construction process must allow different representations of the object being constructed.
- When the construction process should be able to create different types of objects using the same construction code.

### Real-World Examples

The Builder pattern is widely used in real-world applications. Here are a few examples:

**Document Builders**: Document processing applications that need to create different types of documents like PDFs, Word documents, and Excel sheets can use the Builder pattern to create a `DocumentBuilder` interface and concrete implementations like `PDFDocumentBuilder`, `WordDocumentBuilder`, and `ExcelDocumentBuilder`.

**Report Generators**: Report generation libraries that support different report formats like PDF, Excel, and HTML can use the Builder pattern to create report objects based on the selected format.

**UI Component Builders**: UI component libraries that provide different types of buttons, text boxes, and dropdowns can use the Builder pattern to create instances of these components based on the selected theme (Windows, Mac, etc.).

**Database Query Builders**: Database query builders that support multiple database types like SQL Server, MySQL, and Oracle can use the Builder pattern to create database query objects based on the selected database type.

**Notification Builders**: Notification services that support different notification channels like email, SMS, and push notifications can use the Builder pattern to create notification objects based on the selected channel.

**Data Import/Export Builders**: Data import/export utilities that support different data formats like CSV, XML, and JSON can use the Builder pattern to create data objects based on the selected format.

**Authentication Builders**: Authentication providers that support different authentication methods like username/password, OAuth, and SAML can use the Builder pattern to create authentication objects based on the selected method.

### Top 5 Tips for Using the Builder Pattern

**Define an Interface**: Define an interface for the builders that will construct the complex object. This allows you to create different builders without changing the client code.

**Use Inheritance**: Use inheritance to define the builder interface in a superclass and allow subclasses to override it. This allows subclasses to provide different implementations of the builder.

**Encapsulate Object Construction**: Encapsulate object construction in the builder to decouple the client code from the concrete implementations of the object. This allows you to change the object construction process without affecting the client code.

**Use Dependency Injection**: Use dependency injection to inject the builder implementation into the client code. This allows you to change the builder implementation at runtime.

**Consider the Factory Method Pattern**: If you need to create individual objects instead of complex objects, consider using the Factory Method pattern instead of the Builder pattern. The Factory Method pattern provides an interface for creating individual objects without specifying their concrete classes.

### Pattern Consequences

- Separates the construction of a complex object from its representation.
- Provides finer control over the construction process.
- Allows the construction process to create different types of objects using the same construction code.
- Can lead to a more complex codebase with multiple classes involved in the construction process.


### Related Patterns

- Abstract Factory Pattern : Often implemented with Builder to create families of related objects.
- Singleton Pattern : Builders are often Singletons.
- Composite Pattern : Builders can be used to create complex objects with multiple parts.
- 

