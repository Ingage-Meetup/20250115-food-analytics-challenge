using System;
using System.Linq;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodItems foodItems = new([.. System.IO.File.ReadAllLines("../../../../dataset.csv")]);
            var overallStats = foodItems.GetOverallStats();
            Console.WriteLine($"Overall: Total: {overallStats.totalPrice:F2}, Min: {overallStats.minPrice:F2}, Max: {overallStats.maxPrice:F2}, Avg: {overallStats.averagePrice:F2}");
            var categoryStats = foodItems.GetCategoryStats();
            foreach (var category in categoryStats)
            {
                Console.WriteLine($"  Category: {category.Key}, Total: {category.Value.totalPrice:F2}, Min: {category.Value.minPrice:F2}, Max: {category.Value.maxPrice:F2}, Avg: {category.Value.averagePrice:F2}");
                var subCategoryStats = foodItems.GetSubCategoryStats(category.Key);
                foreach (var subCategory in subCategoryStats)
                {
                    Console.WriteLine($"    Subcategory: {subCategory.Key}, Total: {subCategory.Value.totalPrice:F2}, Min: {subCategory.Value.minPrice:F2}, Max: {subCategory.Value.maxPrice:F2}, Avg: {subCategory.Value.averagePrice:F2}");
                }
            }
        }
    }
}
