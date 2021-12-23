namespace Models;

public class Inventory 
{
    public int StoreId { get; set; }
    public int Quantity { get; set; }
    public Product Item { get; set; }

    public override string ToString()
    {
        return $"Store ID: {this.StoreId} \nStock: {this.Quantity} \n {this.Item.ToString()}";
    }
}