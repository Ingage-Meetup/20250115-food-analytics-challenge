using System.Collections.Generic;
using NUnit.Framework;

namespace Project.Test;

public class FoodItemsTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructingShouldIgnoreInvalidFoodItemCsvRows()
    {
        FoodItems foodItems = new([
            "1,category,subCategory,10.0,2021-01-01", // valid
            "id,category,subCategory,10.0,2021-01-01", // invalid - id is not an integer
            "2,category,subCategory,price,2021-01-01", // invalid - price is not a double
            "3,category,subCategory,10.0,timestamp", // invalid - timestamp is not a date
            "4,category,subCategory,10.0,2021-01-01" // valid
        ]);
        Assert.That(foodItems.Items, Has.Count.EqualTo(2));
        Assert.That(foodItems.Items[0].Id, Is.EqualTo(1));
        Assert.That(foodItems.Items[1].Id, Is.EqualTo(4));
    }

    [Test]
    public void GetOverallStatsShouldReturnCorrectValues()
    {
        FoodItems foodItems = new([
            "1,category1,subCategory1,10.0,2021-01-01",
            "2,category1,subCategory1,20.0,2021-01-02",
            "3,category2,subCategory2,30.0,2021-01-03"
        ]);
        var (totalPrice, minPrice, maxPrice, averagePrice) = foodItems.GetOverallStats();
        Assert.That(totalPrice, Is.EqualTo(60.0));
        Assert.That(minPrice, Is.EqualTo(10.0));
        Assert.That(maxPrice, Is.EqualTo(30.0));
        Assert.That(averagePrice, Is.EqualTo(20.0));
    }

    [Test]
    public void GetCategoryStatsShouldReturnCorrectValues()
    {
        FoodItems foodItems = new([
            "1,category1,subCategory1,10.0,2021-01-01",
            "2,category1,subCategory1,20.0,2021-01-02",
            "3,category2,subCategory2,30.0,2021-01-03"
        ]);
        var categoryStats = foodItems.GetCategoryStats();
        Assert.That(categoryStats["category1"].totalPrice, Is.EqualTo(30.0));
        Assert.That(categoryStats["category1"].minPrice, Is.EqualTo(10.0));
        Assert.That(categoryStats["category1"].maxPrice, Is.EqualTo(20.0));
        Assert.That(categoryStats["category1"].averagePrice, Is.EqualTo(15.0));
        Assert.That(categoryStats["category2"].totalPrice, Is.EqualTo(30.0));
        Assert.That(categoryStats["category2"].minPrice, Is.EqualTo(30.0));
        Assert.That(categoryStats["category2"].maxPrice, Is.EqualTo(30.0));
        Assert.That(categoryStats["category2"].averagePrice, Is.EqualTo(30.0));
    }

    [Test]
    public void GetSubCategoryStatsShouldReturnCorrectValues()
    {
        FoodItems foodItems = new([
            "1,category1,subCategory1,10.0,2021-01-01",
            "2,category1,subCategory1,20.0,2021-01-02",
            "3,category1,subCategory2,30.0,2021-01-03"
        ]);
        var subCategoryStats = foodItems.GetSubCategoryStats("category1");
        Assert.That(subCategoryStats["subCategory1"].totalPrice, Is.EqualTo(30.0));
        Assert.That(subCategoryStats["subCategory1"].minPrice, Is.EqualTo(10.0));
        Assert.That(subCategoryStats["subCategory1"].maxPrice, Is.EqualTo(20.0));
        Assert.That(subCategoryStats["subCategory1"].averagePrice, Is.EqualTo(15.0));
        Assert.That(subCategoryStats["subCategory2"].totalPrice, Is.EqualTo(30.0));
        Assert.That(subCategoryStats["subCategory2"].minPrice, Is.EqualTo(30.0));
        Assert.That(subCategoryStats["subCategory2"].maxPrice, Is.EqualTo(30.0));
        Assert.That(subCategoryStats["subCategory2"].averagePrice, Is.EqualTo(30.0));
    }
}
