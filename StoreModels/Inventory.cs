namespace Models;

using System.Data;

public class Inventory 
{
    public Inventory(){}

    public Inventory(int storeId, int quantity, int itemid){
        this.StoreId = storeId;
        this.Quantity = quantity;
        this.ItemID = itemid;
    }
    public int StoreId { get; set; }
    public int Quantity { get; set; }
    public int ItemID { get; set; }

    public override string ToString()
    {
        return $"Store ID: {this.StoreId} \nStock: {this.Quantity} \n {this.ItemID}";
    }

    public void ToDataRow(ref DataRow row){
        this.StoreId = (int) row["InventoryID"];
        this.ItemID = (int) row["ProductID"];
        this.Quantity = (int) row["Quantity"];
    }
}