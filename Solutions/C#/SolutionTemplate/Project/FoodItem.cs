using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Project;

public class FoodItem
{
    public int Id { get; }
    public string Category { get; }
    public string SubCategory { get; }
    public double Price { get; }
    public DateTime Timestamp { get; }

    public FoodItem(int id, string category, string subCategory, double price, DateTime timestamp)
    {
        Id = id;
        Category = category;
        SubCategory = subCategory;
        Price = price;
        Timestamp = timestamp;
    }

    public FoodItem(string csvLine)
    {
        string[] values = [.. Regex.Replace(csvLine, "[\"'$]", "").Split(',').Select(x => x.Trim())];  
        if (values.Length != 5)
        {
            throw new ArgumentException("Invalid CSV line - incorrect number of values");
        }
        Id = int.TryParse(values[0], out int id) ? id : throw new ArgumentException("Invalid CSV line - id is not an integer");
        Category = values[1];
        SubCategory = values[2];
        Price = double.TryParse(values[3], out double price) ? price : throw new ArgumentException("Invalid CSV line - price is not a double");
        Timestamp = DateTime.TryParse(values[4], out DateTime timestamp) ? timestamp : throw new ArgumentException("Invalid CSV line - timestamp is not a date");
    }
}
