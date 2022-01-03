namespace Models;

public class LineItem
{
    public int ItemID { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"Order ID: {this.OrderId} \nQuantity: {this.Quantity} \n{this.ItemID}";
    }
}