using EFC;
using EFC.Entities;

var dataAccess = new DataAccess();

await dataAccess.ClearAllDataAsync();

Console.WriteLine("=== Drinks Menu Database ===\n");

// Create Drinks Menu
Console.WriteLine("--- Creating Drinks Menu ---");
var drinksMenu1 = new DrinksMenu
{
    Name = "Summer Specials",
    ContainsAlcohol = true,
    AvailableFrom = new TimeOnly(12, 0)
};
await dataAccess.CreateDrinksMenuAsync(drinksMenu1);
Console.WriteLine(
    $"Created Drinks Menu: {drinksMenu1.Name} (Contains Alcohol: {drinksMenu1.ContainsAlcohol}, Available From: {drinksMenu1.AvailableFrom})");

var drinksMenu2 = new DrinksMenu
{
    Name = "Kids Menu",
    ContainsAlcohol = false,
    AvailableFrom = new TimeOnly(10, 0)
};
await dataAccess.CreateDrinksMenuAsync(drinksMenu2);
Console.WriteLine(
    $"Created Drinks Menu: {drinksMenu2.Name} (Contains Alcohol: {drinksMenu2.ContainsAlcohol}, Available From: {drinksMenu2.AvailableFrom})");

var drinksMenu3 = new DrinksMenu
{
    Name = "Evening Delights",
    ContainsAlcohol = true,
    AvailableFrom = new TimeOnly(18, 0)
};
await dataAccess.CreateDrinksMenuAsync(drinksMenu3);
Console.WriteLine(
    $"Created Drinks Menu: {drinksMenu3.Name} (Contains Alcohol: {drinksMenu3.ContainsAlcohol}, Available From: {drinksMenu3.AvailableFrom})");

Console.WriteLine();

// Add Drinks
Console.WriteLine("--- Adding Drinks ---");
var drink1 = new Drink
{
    Name = "Mojito",
    Price = 8.5f,
    AlcoholPercentage = 70,
    IncludesUmbrella = true
};
await dataAccess.AddDrinkToDrinkMenuAsync(1, drink1);
Console.WriteLine(
    $"Added: {drink1.Name} (Price: {drink1.Price}, Alcohol: {drink1.AlcoholPercentage}%, Umbrella: {drink1.IncludesUmbrella})");

var drink2 = new Drink
{
    Name = "Lemonade",
    Price = 4.0f,
    AlcoholPercentage = 0,
    IncludesUmbrella = false
};
await dataAccess.AddDrinkToDrinkMenuAsync(1, drink2);
Console.WriteLine(
    $"Added: {drink2.Name} (Price: {drink2.Price}, Alcohol: {drink2.AlcoholPercentage}%, Umbrella: {drink2.IncludesUmbrella})");

var drink3 = new Drink
{
    Name = "Pina Colada",
    Price = 9.0f,
    AlcoholPercentage = 30,
    IncludesUmbrella = true
};
await dataAccess.AddDrinkToDrinkMenuAsync(3, drink3);
Console.WriteLine(
    $"Added: {drink3.Name} (Price: {drink3.Price}, Alcohol: {drink3.AlcoholPercentage}%, Umbrella: {drink3.IncludesUmbrella})");

var drink4 = new Drink
{
    Name = "Virgin Mojito",
    Price = 5.5f,
    AlcoholPercentage = 0,
    IncludesUmbrella = true
};
await dataAccess.AddDrinkToDrinkMenuAsync(2, drink4);
Console.WriteLine(
    $"Added: {drink4.Name} (Price: {drink4.Price}, Alcohol: {drink4.AlcoholPercentage}%, Umbrella: {drink4.IncludesUmbrella})");

var drink5 = new Drink
{
    Name = "Whiskey Sour",
    Price = 10.0f,
    AlcoholPercentage = 40,
    IncludesUmbrella = false
};
await dataAccess.AddDrinkToDrinkMenuAsync(3, drink5);
Console.WriteLine(
    $"Added: {drink5.Name} (Price: {drink5.Price}, Alcohol: {drink5.AlcoholPercentage}%, Umbrella: {drink5.IncludesUmbrella})");

var drink6 = new Drink
{
    Name = "Fruit Punch",
    Price = 6.0f,
    AlcoholPercentage = 0,
    IncludesUmbrella = true
};
await dataAccess.AddDrinkToDrinkMenuAsync(2, drink6);
Console.WriteLine(
    $"Added: {drink6.Name} (Price: {drink6.Price}, Alcohol: {drink6.AlcoholPercentage}%, Umbrella: {drink6.IncludesUmbrella})");

Console.WriteLine();

// Query Drinks
Console.WriteLine("--- Querying Drinks ---");
var alcoholicDrinks = await dataAccess.GetDrinks(20, null, null);
Console.WriteLine("Drinks with at least 20% alcohol:");

foreach (var drink in alcoholicDrinks)
{
    Console.WriteLine(
        $"- {drink.Name} (Alcohol: {drink.AlcoholPercentage}%)");
}

Console.WriteLine("\n--- Verifying data was saved ---");
var allMenus = await dataAccess.GetDrinksMenusOrderedByTotalPriceAsync();
Console.WriteLine($"Total menus in database: {allMenus.Count}");
foreach (var menu in allMenus)
{
    Console.WriteLine($"Menu: {menu.Name}, Drinks count: {menu.Drinks.Count}");
}