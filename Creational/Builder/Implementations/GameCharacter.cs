namespace Builder.Implementations;

public class GameCharacter
{
    public string? Name { get; set; }
    public string? Class { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public string? Weapon { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Class: {Class}, Health: {Health}, Mana: {Mana}, Weapon: {Weapon}";
    }
}

public interface IGameCharacterBuilder
{
    void BuildName();
    void BuildClass();
    void BuildHealth();
    void BuildMana();
    void BuildWeapon();
    GameCharacter GetGameCharacter();
}

public class WarriorCharacterBuilder : IGameCharacterBuilder
{
    private  readonly GameCharacter _character = new GameCharacter();

    public void BuildName()
    {
        _character.Name = "Warrior";
    }

    public void BuildClass()
    {
        _character.Class = "Warrior";
    }

    public void BuildHealth()
    {
        _character.Health = 200;
    }

    public void BuildMana()
    {
        _character.Mana = 50;
    }

    public void BuildWeapon()
    {
        _character.Weapon = "Sword";
    }

    public GameCharacter GetGameCharacter()
    {
        return _character;
    }
}

public class MageCharacterBuilder : IGameCharacterBuilder
{
    private readonly GameCharacter _character = new GameCharacter();

    public void BuildName()
    {
        _character.Name = "Mage";
    }

    public void BuildClass()
    {
        _character.Class = "Mage";
    }

    public void BuildHealth()
    {
        _character.Health = 100;
    }

    public void BuildMana()
    {
        _character.Mana = 200;
    }

    public void BuildWeapon()
    {
        _character.Weapon = "Staff";
    }

    public GameCharacter GetGameCharacter()
    {
        return _character;
    }
}

public class GameCharacterDirector(IGameCharacterBuilder builder)
{
    public void Construct()
    {
        builder.BuildName();
        builder.BuildClass();
        builder.BuildHealth();
        builder.BuildMana();
        builder.BuildWeapon();
    }

    public void Show()
    {
        var character = builder.GetGameCharacter();
        Console.WriteLine(character.ToString());
    }
}