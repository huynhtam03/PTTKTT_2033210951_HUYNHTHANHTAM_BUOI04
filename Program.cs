// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Item> items = new List<Item>
        {
            new Item(60, 10, 2),
            new Item(100, 20, 1),
            new Item(120, 30, 3)
        };

        int capacity = 50;
        
        // Gọi hàm giải bài toán balo 0/1
        double maxValue01 = GreedyKnapsack01.Calculate(capacity, items);
        Console.WriteLine("Gia tri toi da trong balo (0/1) = " + maxValue01);

        // Gọi hàm giải bài toán balo phân số
        double maxValueFractional = GreedyKnapsackFractional.Calculate(capacity, items);
        Console.WriteLine("Gia tri toi da trong balo (Fractional) = " + maxValueFractional);

        // Gọi hàm giải bài toán balo có số lượng giới hạn
        double maxValueBounded = GreedyKnapsackBounded.Calculate(capacity, items);
        Console.WriteLine("Gia tri toi da trong balo (Bounded) = " + maxValueBounded);
    }
}
