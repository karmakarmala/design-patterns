using Builder.Implementations;

var queryBuilder = new QueryBuilder();
var queryDirector = new QueryDirector(queryBuilder);
queryDirector.Construct();
queryDirector.Show();  // Outputs: SELECT * FROM Users WHERE Age > 21

// Create a warrior character
var warriorBuilder = new WarriorCharacterBuilder();
var warriorDirector = new GameCharacterDirector(warriorBuilder);
warriorDirector.Construct();
warriorDirector.Show();  // Outputs: Name: Warrior, Class: Warrior, Health: 200, Mana: 50, Weapon: Sword

// Create a mage character
var mageBuilder = new MageCharacterBuilder();
var mageDirector = new GameCharacterDirector(mageBuilder);
mageDirector.Construct();
mageDirector.Show();  // Outputs: Name: Mage, Class: Mage, Health: 100, Mana: 200, Weapon: Staff
