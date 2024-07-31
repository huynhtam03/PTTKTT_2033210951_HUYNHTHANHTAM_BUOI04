// GreedyKnapsackBounded.cs
using System;
using System.Collections.Generic;
using System.Linq;

public static class GreedyKnapsackBounded
{
    public static double Calculate(int capacity, List<Item> items)
    {
        var sortedItems = items.OrderByDescending(item => item.Ratio).ToList();
        double totalValue = 0;
        int currentWeight = 0;

        foreach (var item in sortedItems)
        {
            int count = Math.Min(item.Quantity, (capacity - currentWeight) / item.Weight);
            currentWeight += count * item.Weight;
            totalValue += count * item.Value;
        }

        return totalValue;
    }
}
