# The Food Analytics Challenge

## Problem Statement

In this challenge, you will analyze a dataset containing food-related data. The dataset includes information about various categories (e.g., Fruit, Vegetable, Dairy) and subcategories (e.g., Apple, Carrot, Milk), along with numerical values and timestamps. Your task is to process this data to derive meaningful insights by performing various data aggregation and analysis operations.

### Primary Goals

1. **Aggregate all values**:
   - Calculate the total, average, minimum, and maximum Value for every record.

2. **Group and Aggregate**:
   - Group the data by Category.
   - Calculate the total, average, minimum, and maximum Value for each Category.

3. **Extend Grouping**:
   - Further group by both Category and Subcategory.
   - Calculate the same metrics (total, average, min, max) for each Subcategory.

### Recommended approach

Use subsets of data much like what is provided in the example below, or from the [dataset.csv](dataset.csv) file to write tests incrementally. 

For instance:
1. Start with just the header row and a single line and ensure you get the total, min, max and average values for that single row.
2. Add a test that adds a second line with the same category and subcategory as the test above and ensure that the calculations are still performed correctly
3. Add a test that adds an additional line with a new subcategory and ensure that the calculations are still performed correctly
4. Add a test that adds an additional line with a new category and subcategory and ensure that the calculations are still performed correctly
5. Run against the full dataset and compare to the [Example Completing Primary Goals](#example-completing-primary-goals)

example data:
```
ID,Category,Subcategory,Value,Timestamp
1,Fruit,Apple,74.41,2024-01-23T06:58:00
2,Vegetable,Spinach,73.91,2024-03-02T14:16:00
3,Protein,Chicken,59.46,2024-01-03T21:25:00
4,Fruit,Apple,22.65,2024-02-15T23:57:00
5,Protein,Chicken,56.56,2024-03-06T04:10:00
6,Protein,Tofu,22.82,2024-02-23T15:16:00
7,Dairy,Milk,76.12,2024-01-15T12:46:00
8,Grain,Oats,28.51,2024-01-20T14:21:00
9,Dairy,Milk,10.18,2024-01-09T19:16:00
10,Dairy,Yogurt,60.77,2024-01-04T22:55:00
```

### Stretch Goals (For additional exploration)

1. **Filter by Time**:
   - Allow filtering of the data to include only rows within a specified date and time range.

2. **Dynamic Analysis**:
   - Allow users to specify grouping fields and aggregation metrics dynamically (e.g., choose between Category or Subcategory).

3. **Sorting Results**:
   - Sort the output by calculated metrics, such as highest average value or total value.

4. **Visualize Results**:
   - Generate simple visualizations (e.g., bar charts or tables) for the aggregated data.

5. **Real-Time Updates**:
   - Simulate appending new rows to the dataset and update the analysis in real-time.

6. **Performance Optimization**:
   - Explore optimizations for processing larger datasets efficiently.

### Constraints

- The dataset contains 10,000 rows, so the operations should remain performant.
- Encourage a Test-Driven Development (TDD) approach to ensure correctness at each step.

## Learning Objectives

- Practice Test-Driven Development (TDD) to ensure code correctness and reliability.
- Understand how to perform data aggregation and grouping operations.
- Learn to handle and process large datasets efficiently.
- Gain experience in filtering and sorting data based on specific criteria.
- Develop skills in visualizing data to derive insights.

## Example Completing Primary Goals:
Your final solution should produce something that looks like this (most important part being the actual values. `NOTE:` A bug has been identified in my code since I used TypeScript to produce this which was a bit more forgiving on parsing the values and it included a row that should not have been. Thank you Chris B for pointing this out to me.).
```
Overall: Total: 499999.09, Min: 1.00, Max: 99.99, Avg: 50.03
  Category: Fruit, Total: 103558.85, Min: 1.00, Max: 99.98, Avg: 51.24
    Subcategory: Apple, Total: 20154.74, Min: 1.00, Max: 99.86, Avg: 51.28
    Subcategory: Berry, Total: 20768.54, Min: 1.54, Max: 99.98, Avg: 51.41
    Subcategory: Orange, Total: 21633.93, Min: 1.05, Max: 99.74, Avg: 49.96
    Subcategory: Banana, Total: 19971.65, Min: 1.14, Max: 99.69, Avg: 53.12
    Subcategory: Grape, Total: 21029.99, Min: 2.14, Max: 99.92, Avg: 50.67
  Category: Vegetable, Total: 98589.21, Min: 1.05, Max: 99.99, Avg: 50.02
    Subcategory: Spinach, Total: 19735.91, Min: 1.29, Max: 99.35, Avg: 49.71
    Subcategory: Broccoli, Total: 17305.17, Min: 1.85, Max: 99.99, Avg: 49.44
    Subcategory: Tomato, Total: 19779.30, Min: 1.25, Max: 99.84, Avg: 51.37
    Subcategory: Pepper, Total: 21900.49, Min: 1.22, Max: 99.87, Avg: 51.65
    Subcategory: Carrot, Total: 19868.34, Min: 1.05, Max: 99.79, Avg: 47.88
  Category: Protein, Total: 101087.19, Min: 1.01, Max: 99.93, Avg: 50.32
    Subcategory: Chicken, Total: 19437.05, Min: 1.14, Max: 99.57, Avg: 49.97
    Subcategory: Tofu, Total: 20622.25, Min: 1.41, Max: 99.34, Avg: 50.54
    Subcategory: Fish, Total: 18950.73, Min: 1.26, Max: 99.33, Avg: 49.74
    Subcategory: Beef, Total: 20452.07, Min: 1.71, Max: 99.86, Avg: 51.00
    Subcategory: Egg, Total: 21625.09, Min: 1.01, Max: 99.93, Avg: 50.29
  Category: Dairy, Total: 99515.93, Min: 1.01, Max: 99.96, Avg: 50.13
    Subcategory: Milk, Total: 18009.57, Min: 1.01, Max: 99.50, Avg: 51.02
    Subcategory: Yogurt, Total: 20270.41, Min: 1.80, Max: 99.67, Avg: 50.55
    Subcategory: Butter, Total: 20072.56, Min: 1.07, Max: 99.96, Avg: 49.32
    Subcategory: Cream, Total: 21006.91, Min: 1.14, Max: 99.91, Avg: 50.38
    Subcategory: Cheese, Total: 20156.48, Min: 1.06, Max: 99.94, Avg: 49.52
  Category: Grain, Total: 97247.91, Min: 1.07, Max: 99.80, Avg: 48.45
    Subcategory: Oats, Total: 20380.92, Min: 1.33, Max: 99.68, Avg: 49.59
    Subcategory: Barley, Total: 17183.42, Min: 1.46, Max: 99.67, Avg: 48.82
    Subcategory: Wheat, Total: 20068.05, Min: 1.12, Max: 99.64, Avg: 48.95
    Subcategory: Rice, Total: 18809.94, Min: 1.07, Max: 99.80, Avg: 46.10
    Subcategory: Corn, Total: 20805.58, Min: 1.07, Max: 99.78, Avg: 48.84
```

# C3ProjectTemplate

See solutions in different languages in the "Templates" directory. Once you decide which language you'd like to use,
simply open that directory in your favorite IDE, and you should be able to run the included unit tests "out of the box".

The recommended IDEs are as follows, but feel free to use whatever IDE you are comfortable with.

-   [C#](Templates/C%23) - [Microsoft Visual Studio](https://visualstudio.microsoft.com/vs/community/)
-   [Java](Templates/Java) - [IntelliJ Idea](https://www.jetbrains.com/idea/download) (Community Edition is fine)
-   [JavaScript](Templates/JavaScript) - [Microsoft Visual Studio Code](https://code.visualstudio.com/)
-   [Kotlin](Templates/Kotlin) - [IntelliJ Idea](https://www.jetbrains.com/idea/download) (Community Edition is fine)
-   [Python](Templates/Python) - [Pycharm](https://www.jetbrains.com/pycharm/download/?section=windows) (Community Edition is fine)
-   [TypeScript](Templates/TypeScript) - [Microsoft Visual Studio Code](https://code.visualstudio.com/)
