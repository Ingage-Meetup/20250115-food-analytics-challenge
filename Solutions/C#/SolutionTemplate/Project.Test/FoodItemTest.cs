using System;
using NUnit.Framework;

namespace Project.Test;

public class FoodItemTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void NotEnoughEntriesInCsvShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new FoodItem("1,category,subCategory,10.0"));
    }

    [Test]
    public void TooManyEntriesInCsvShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new FoodItem("1,category,subCategory,10.0,2021-01-01,extra"));
    }

    [Test]
    public void IdIsNotAnIntegerShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new FoodItem("id,category,subCategory,10.0,2021-01-01"));
    }

    [Test]
    public void PriceIsNotADoubleShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new FoodItem("1,category,subCategory,price,2021-01-01"));
    }

    [Test]
    public void TimestampIsNotADateShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new FoodItem("1,category,subCategory,10.0,timestamp"));
    }
}
