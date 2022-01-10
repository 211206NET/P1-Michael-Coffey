namespace Models;

using System.Data;

public class LineItem
{

    public LineItem(){
    }

    public LineItem(int itemid, int orderid, int quantity){
        this.ItemID = itemid;
        this.OrderId = orderid;
        this.Quantity = quantity;
    }

    public LineItem(DataRow row){
        this.OrderId = (int) row["LineItemID"];
        this.ItemID = (int) row["ProductID"];
        this.Quantity = (int) row["Quantity"];
    }
    public int ItemID { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"LineItem ID: {this.OrderId} \nQuantity: {this.Quantity} \n{this.ItemID}";
    }

    public void ToDataRow(ref DataRow row){
        this.OrderId = (int) row["LineItemID"];
        this.ItemID = (int) row["ProductID"];
        this.Quantity = (int) row["Quantity"];
    }
}