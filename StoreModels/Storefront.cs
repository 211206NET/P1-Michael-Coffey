namespace Models;

using System.Data;

public class Storefront
{
    public int ID { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    public int InventoryID { get; set; }
    public int OrderID { get; set; }

    public Storefront(){}

    public Storefront(string address, string name, int inventoryid){
        this.Address = address;
        this.Name = name;
        this.InventoryID = inventoryid;
    }

    public Storefront(string address, string name, int inventoryid, int orderid){
        this.Address = address;
        this.Name = name;
        this.InventoryID = inventoryid;
        this.OrderID = orderid;
    }

    /// <summary>
    /// Takes a row from the Storefront table and converts it into a Storefront object
    /// </summary>
    /// <param name="row">Row from the Storefront table</param>
    public Storefront(DataRow row){
        this.Name = row["Name"].ToString() ?? "";
        this.Address = row["Address"].ToString() ?? "";
        this.InventoryID = (int) row["InventoryID"];
        this.OrderID = (int) row["SOrderHistoryID"];
    }

    public override string ToString()
    {
        return $"Name: {this.Name} \nAddress: {this.Address}";
    }

    /// <summary>
    /// Takes a row from the Storefront table and converts it into a Storefront object
    /// </summary>
    /// <param name="row">Reference to a row in the Storefront table</param>
    public void ToDataRow(ref DataRow row){
        row["Name"] = this.Name ?? "";
        row["Address"] = this.Address ?? "";
        row["InventoryID"] = this.InventoryID;
        row["SOrderHistoryID"] = this.OrderID;
    }
}