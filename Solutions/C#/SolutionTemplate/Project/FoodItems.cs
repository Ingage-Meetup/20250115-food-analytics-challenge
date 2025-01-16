using System;
using System.Collections.Generic;
using System.Linq;

namespace Project;

public class FoodItems(List<string> csvLines)
{
    public List<FoodItem> Items { get; } = [.. csvLines.Select(csvLine => {
            try {
                return new FoodItem(csvLine);
            } catch (ArgumentException) {
                return null;
            }
        }).Where(item => item != null)];

    public (double totalPrice, double minPrice, double maxPrice, double averagePrice) GetOverallStats()
    {
        return GetStats(Items);
    }

    public Dictionary<string, (double totalPrice, double minPrice, double maxPrice, double averagePrice)> GetCategoryStats()
    {
        return Items.GroupBy(item => item.Category)
                    .ToDictionary(group => group.Key, group => GetStats([.. group]));
    }

    public Dictionary<string, (double totalPrice, double minPrice, double maxPrice, double averagePrice)> GetSubCategoryStats(string category)
    {
        return Items.Where(item => item.Category == category)
                    .GroupBy(item => item.SubCategory)
                    .ToDictionary(group => group.Key, group => GetStats([.. group]));
    }
    
    private static (double totalPrice, double minPrice, double maxPrice, double averagePrice) GetStats(List<FoodItem> Items)
    {
        double totalPrice = Items.Sum(item => item.Price);
        double minPrice = Items.Min(item => item.Price);
        double maxPrice = Items.Max(item => item.Price);
        double averagePrice = Items.Average(item => item.Price);
        return (totalPrice, minPrice, maxPrice, averagePrice);
    }
}
