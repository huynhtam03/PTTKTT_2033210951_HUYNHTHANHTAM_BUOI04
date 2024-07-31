# Thuật toán Sum Array, Binary Search và Quick Sort


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
<a name = '3'></a>
# 3.	Binary Search
<a name = '3.1'></a>
## 3.1.	Binary Search không đệ quy
```
        // Hàm Binary Search không đệ quy
        public static int BinarySearchIterative(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Tính chỉ số giữa

                if (array[mid] == target) // Tìm thấy phần tử
                    return mid;
                else if (array[mid] > target) // Phần tử ở nửa bên trái
                    right = mid - 1;
                else // Phần tử ở nửa bên phải
                    left = mid + 1;
            }

            // Nếu không tìm thấy phần tử
            return -1;
        }
```
https://github.com/user-attachments/assets/02a73667-8355-4022-989a-01a997485869

<a name = '3.2'></a>
## 3.2.	Binary Search đệ quy
```
// Hàm Binary Search đệ quy
        public static int BinarySearchRecursive(int[] array, int left, int right, int target)
        {
            if (left <= right)
            {
                int mid = left + (right - left) / 2; // Tính chỉ số giữa

                if (array[mid] == target) // Tìm thấy phần tử
                    return mid;
                else if (array[mid] > target) // Phần tử ở nửa bên trái
                    return BinarySearchRecursive(array, left, mid - 1, target);
                else // Phần tử ở nửa bên phải
                    return BinarySearchRecursive(array, mid + 1, right, target);
            }

            // Nếu không tìm thấy phần tử
            return -1;
        }
```
https://github.com/user-attachments/assets/51d7834e-9850-4f0b-a7a0-e23b4b156cac

<a name = '4'></a>
# 4.	Quick Sort
```
 public class Quick_Sort
    {
        // Hàm QuickSort chính
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                // Chia mảng thành hai phần và sắp xếp chúng
                int pivotIndex = Partition(array, low, high);
                QuickSort(array, low, pivotIndex - 1); // Sắp xếp phần mảng bên trái Pivot
                QuickSort(array, pivotIndex + 1, high); // Sắp xếp phần mảng bên phải Pivot
            }
        }

        // Hàm phân hoạch mảng
        public static int Partition(int[] array, int low, int high)
        {
            // Chọn Pivot là phần tử cuối cùng trong mảng con
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot) // Nếu phần tử nhỏ hơn hoặc bằng Pivot
                {
                    i++;
                    Swap(array, i, j); // Đổi chỗ phần tử
                }
            }
            // Đưa Pivot về đúng vị trí của nó
            Swap(array, i + 1, high);
            return i + 1;
        }

        // Hàm đổi chỗ hai phần tử trong mảng
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
```
https://github.com/user-attachments/assets/7fe1b12e-d3f0-403c-897e-a1838b1342b3

<a name = '5'></a>
# 5.	Cài đặt và sử dụng

<a name = '5.1'></a>
## 5.1.	Sum Array
```
            // Test hàm tính tổng mảng không đệ quy
            Console.WriteLine("Test SumArrayIterative:");
            int[] array = { 1, 2, 3, 4, 5 };
            int sumIterative = Sum_Array.SumArrayIterative(array, array.Length - 1);
            Console.WriteLine("Tong cua mang la: " +sumIterative);

            // Test hàm tính tổng mảng bằng đệ quy
            Console.WriteLine("\nTest SumArrayRecursive:");
            int sumRecursive = Sum_Array.SumArrayRecursive(array, array.Length - 1);
            Console.WriteLine("Tong cua mang la: " +sumRecursive);
```
<a name = '5.2'></a>
## 5.2.	Binary Search
```
            // Test hàm Binary Search không đệ quy
            Console.WriteLine("\nTest Binary Search khong de quy:");
            int[] sortedArray = { 1, 2, 3, 4, 5, 6 };
            int target = 1;
            int resultIterative = Binary_Search.BinarySearchIterative(sortedArray, target);
            Console.WriteLine(resultIterative != -1 ? "Phan tu " + target + " duoc tim thay o chi so " + resultIterative + "." : "Phan tu " + target + " khong co trong mang.");

            // Test hàm Binary Search đệ quy
            Console.WriteLine("\nTest Binary Search de quy:");
            int resultRecursive = Binary_Search.BinarySearchRecursive(sortedArray, 0, sortedArray.Length - 1, target);
            Console.WriteLine(resultRecursive != -1 ? "Phan tu " + target + " duoc tim thay o chi so " + resultRecursive + "." : "Phan tu " + target + " khong co trong mang.");
```
<a name = '5.3'></a>
## 5.3.	Quick Sort
```
             // Test hàm QuickSort
            Console.WriteLine("\nTest QuickSort:");
            int[] arrayToSort = { 3, 1, 4, 10, 5 };
            Console.WriteLine("Mang truoc khi sap xep:");
            PrintArray(arrayToSort);
            Quick_Sort.QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
            Console.WriteLine("Mang sau khi sap xep:");
            PrintArray(arrayToSort);
```
