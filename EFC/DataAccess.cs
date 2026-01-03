using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC;

public class DataAccess
{
    private readonly MenuContext context;
    
    public DataAccess()
    {
        context = new MenuContext();
    }
    
    public async Task CreateDrinksMenuAsync(DrinksMenu drinksMenu)
    {
        context.DrinksMenus.Add(drinksMenu);
        await context.SaveChangesAsync();
    }
    
    public async Task AddDrinkToDrinkMenuAsync(int drinksMenuId,
        Drink drink)
    {
        var drinksMenu = await context.DrinksMenus.FindAsync(drinksMenuId);
        if (drinksMenu != null)
        {
            drink.DrinksMenuId = drinksMenuId;
            context.Drinks.Add(drink);
            await context.SaveChangesAsync();
        }
    }
    
    public async Task<List<Drink>> GetDrinks(float? minimumAlcoholPercentage, float? maximumAlcoholPercentage, bool? includesUmbrella)
    {
        var query = context.Drinks.AsQueryable();

        if (minimumAlcoholPercentage.HasValue)
        {
            query = query.Where(d => d.AlcoholPercentage >= minimumAlcoholPercentage.Value);
        }

        if (maximumAlcoholPercentage.HasValue)
        {
            query = query.Where(d => d.AlcoholPercentage <= maximumAlcoholPercentage.Value);
        }

        if (includesUmbrella.HasValue)
        {
            query = query.Where(d => d.IncludesUmbrella == includesUmbrella.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<List<DrinksMenu>> GetDrinksMenusOrderedByTotalPriceAsync()
    {
        return await context.DrinksMenus
            .Include(dm => dm.Drinks)
            .OrderByDescending(dm => dm.Drinks.Sum(d => d.Price))
            .ToListAsync();
    }
    
    public async Task ClearAllDataAsync()
    {
        context.Drinks.RemoveRange(context.Drinks);
        context.DrinksMenus.RemoveRange(context.DrinksMenus);
        await context.SaveChangesAsync();
        Console.WriteLine("All data cleared.");
    }
}
