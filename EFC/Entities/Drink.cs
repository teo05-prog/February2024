namespace EFC.Entities;

public class Drink
{
    public int DrinkId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public float AlcoholPercentage { get; set; }
    public bool IncludesUmbrella { get; set; }
    public int DrinksMenuId { get; set; }
    public DrinksMenu DrinksMenu { get; set; }
}