namespace Models;

using System.Data;

public class LineItem
{

    public LineItem(){
    }

    public LineItem(DataRow row){
        this.ItemID = (int) row["ProductID"];
        this.Quantity = (int) row["Quantity"];
    }
    public int ItemID { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"Order ID: {this.OrderId} \nQuantity: {this.Quantity} \n{this.ItemID}";
    }

    public void ToDataRow(ref DataRow row){
        this.ItemID = (int) row["ProductID"];
        this.Quantity = (int) row["Quantity"];
    }
}