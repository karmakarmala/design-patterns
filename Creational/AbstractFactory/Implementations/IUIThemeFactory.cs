// In this example, two types of UI themes: Light and Dark.
// Each theme has its own way of rendering buttons and checkboxes. 
namespace AbstractFactory.Implementations;

/// <summary>
/// Abstract Factory
/// </summary>
public interface IUIThemeFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

/// <summary>
/// Abstract Product A
/// </summary>
public interface IButton
{
    void Render();
}

/// <summary>
/// Abstract Product B
/// </summary>
public interface ICheckbox
{
    void Render();
}

/// <summary>
/// Concrete Product A1
/// </summary>
public class LightButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a light-themed button.");
    }
}

/// <summary>
/// Concrete Product B1
/// </summary>
public class LightCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering a light-themed checkbox.");
    }
}

/// <summary>
/// Concrete Product A2
/// </summary>
public class DarkButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a dark-themed button.");
    }
}

/// <summary>
/// Concrete Product B2
/// </summary>
public class DarkCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering a dark-themed checkbox.");
    }
}

/// <summary>
/// Concrete Factory 1
/// </summary>
public class LightThemeFactory : IUIThemeFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new LightCheckbox();
    }
}

/// <summary>
/// Concrete Factory 2
/// </summary>
public class DarkThemeFactory : IUIThemeFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new DarkCheckbox();
    }
}