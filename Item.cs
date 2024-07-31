// Item.cs
public class Item
{
    public int Value { get; set; }
    public int Weight { get; set; }
    public int Quantity { get; set; }
    public double Ratio => (double)Value / Weight;

    public Item(int value, int weight, int quantity = 0)
    {
        Value = value;
        Weight = weight;
        Quantity = quantity;
    }
}
