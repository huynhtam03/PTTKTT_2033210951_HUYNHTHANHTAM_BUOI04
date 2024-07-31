// GreedyKnapsack01.cs
using System;
using System.Collections.Generic;
using System.Linq;

public static class GreedyKnapsack01
{
    public static double Calculate(int capacity, List<Item> items)
    {
        var sortedItems = items.OrderByDescending(item => item.Ratio).ToList();
        double totalValue = 0;
        int currentWeight = 0;

        foreach (var item in sortedItems)
        {
            if (currentWeight + item.Weight <= capacity)
            {
                currentWeight += item.Weight;
                totalValue += item.Value;
            }
        }

        return totalValue;
    }
}
