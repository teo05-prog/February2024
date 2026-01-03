namespace EFC.Entities;

public class DrinksMenu
{
    public int DrinksMenuId { get; set; }
    public string Name { get; set; }
    public bool ContainsAlcohol { get; set; }
    public TimeOnly AvailableFrom { get; set; }
    public ICollection<Drink> Drinks { get; set; } = new List<Drink>();
}