// GreedyKnapsackFractional.cs
using System;
using System.Collections.Generic;
using System.Linq;

public static class GreedyKnapsackFractional
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
            else
            {
                int remainingWeight = capacity - currentWeight;
                totalValue += item.Value * ((double)remainingWeight / item.Weight);
                break;
            }
        }

        return totalValue;
    }
}
