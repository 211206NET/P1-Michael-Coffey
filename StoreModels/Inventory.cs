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

    /// <summary>
    /// Converts the data from the Inventory table into an Inventory object.
    /// </summary>
    /// <param name="row">Data row from the Inventory table</param>
    public Inventory(DataRow row){
        this.StoreId = (int) row["InvnetoryID"];
        this.ItemID = (int) row["ProductID"];
        this.Quantity = (int) row["Quantity"];

    }
    public int StoreId { get; set; }
    public int Quantity { get; set; }
    public int ItemID { get; set; }

    public override string ToString()
    {
        return $"Inventory ID: {this.StoreId} \nStock: {this.Quantity} \n {this.ItemID}";
    }

    /// <summary>
    /// Takes an instance of an Inventory object and adds them to the Inventory Table
    /// </summary>
    /// <param name="row">reference to the row from the Inventory table</param>
    public void ToDataRow(ref DataRow row){
        this.StoreId = (int) row["InventoryID"];
        this.ItemID = (int) row["ProductID"];
        this.Quantity = (int) row["Quantity"];
    }
}