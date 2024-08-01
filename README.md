# Thuật toán Greedy Knapsack


### ***Mục lục***

[1.	Giới thiệu](#1)

[2.	Bài Toán Ba lô](#2)

- [2.1.	0/1 Knapsack Problem ](#2.1)

- [2.2.	Fractional Knapsack Problem ](#2.2)

- [2.3.	Bounded Knapsack Problem ](#2.3)

[3.	Ưu Điểm và Nhược Điểm](#3)

- [3.1.	Ưu điểm](#3.1)

- [3.2.	Nhược điểm](#3.2)

[4. Cài đặt và sử dụng](#4)

- [4.1.	0/1 Knapsack Problem ](#4.1)

- [4.2.	Fractional Knapsack Problem ](#4.2)

- [4.3.	Bounded Knapsack Problem ](#4.3)




<a name = '1'></a>
# 1.	Giới thiệu 

Thuật toán Greedy Knapsack là một phương pháp sử dụng chiến lược greedy để giải quyết bài toán ba lô (Knapsack Problem),
đặc biệt là các phiên bản có thể giải quyết được bằng cách chọn lựa tối ưu cục bộ. Bài toán ba lô là một trong những bài toán tối ưu hóa 
phổ biến trong khoa học máy tính, và thuật toán greedy thường được sử dụng cho phiên bản phân số của bài toán này.

<a name = '2'></a>
# 2.	Bài Toán Ba Lô

<a name = '2.1'></a>
## 2.1.	0/1 Knapsack Problem
```
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
```
https://github.com/user-attachments/assets/c3eb6974-7257-4dd9-a846-a565bd7e3965


<a name = '2.2'></a>
## 2.2.	Fractional Knapsack Problem
```
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

```

https://github.com/user-attachments/assets/3add3f1d-7ecb-4a24-8346-a63f6090c7bd

<a name = '2.3'></a>
## 2.3.	Bounded Knapsack Problem
```
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
```
https://github.com/user-attachments/assets/6640f687-825b-46ad-91e0-f6c354b6b1f3

<a name = '3'></a>
# 3.	Ưu điểm và nhược điểm
<a name = '3.1'></a>
## 3.1.	Ưu điểm

- Đơn giản và dễ triển khai: Thuật toán Greedy có logic đơn giản và dễ dàng triển khai.
- Hiệu quả về thời gian: Thuật toán Greedy thường có độ phức tạp thời gian thấp, giúp giải quyết bài toán nhanh chóng.
- Hiệu quả cho bài toán Fractional Knapsack: Thuật toán Greedy cho kết quả tối ưu với bài toán Fractional Knapsack.
<a name = '3.2'></a>
## 3.2.	Nhược điểm

- Không đảm bảo tối ưu cho mọi trường hợp: Thuật toán Greedy không đảm bảo tìm ra lời giải tối ưu cho tất cả các bài toán, đặc biệt là 0/1 Knapsack.
- Không phù hợp cho các bài toán phức tạp: Với các bài toán có nhiều ràng buộc và yếu tố phức tạp, thuật toán Greedy có thể không cho ra kết quả chính xác.
- Cần sắp xếp dữ liệu đầu vào: Thuật toán yêu cầu sắp xếp các mục theo tỷ lệ giá trị/trọng lượng, điều này có thể tốn thời gian nếu dữ liệu đầu vào lớn.
<a name = '4'></a>
# 4.	Cài đặt và sử dụng

<a name = '4.1'></a>
## 4.1.	0/1 Knapsack Problem
```
var items = new List<Item>
{
    new Item { Value = 60, Weight = 10 },
    new Item { Value = 100, Weight = 20 },
    new Item { Value = 120, Weight = 30 }
};
int capacity = 50;
double maxValue = GreedyKnapsack01.Calculate(capacity, items);
Console.WriteLine("Gia tri lon nhat co the dat duoc: " + maxValue);
```
<a name = '4.2'></a>
## 4.2.	Fractional Knapsack Problem
```
var items = new List<Item>
{
    new Item { Value = 60, Weight = 10 },
    new Item { Value = 100, Weight = 20 },
    new Item { Value = 120, Weight = 30 }
};
int capacity = 50;
double maxValue = GreedyKnapsackFractional.Calculate(capacity, items);
Console.WriteLine("Gia tri lon nhat co the dat duoc: " + maxValue);
```
<a name = '4.3'></a>
## 4.3.	Bounded Knapsack Problem
```
// Sử dụng
var items = new List<Item>
{
    new Item { Value = 60, Weight = 10, Quantity = 2 },
    new Item { Value = 100, Weight = 20, Quantity = 2 },
    new Item { Value = 120, Weight = 30, Quantity = 2 }
};
int capacity = 50;
double maxValue = GreedyKnapsackBounded.Calculate(capacity, items);
Console.WriteLine("Gia tri lon nhat co the dat duoc: " + maxValue);
```
