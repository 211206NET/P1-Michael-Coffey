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

    public Storefront(string address, string name, int inventoryid, int orderid){
        this.Address = address;
        this.Name = name;
        this.InventoryID = inventoryid;
        this.OrderID = orderid;
    }

    public Storefront(DataRow row){
        this.Name = row["Name"].ToString() ?? "";
        this.Address = row["Address"].ToString() ?? "";
        this.InventoryID = (int) row["InventoryID"];
        this.OrderID = (int) row["SOrderHistoryID"];
    }

    // public void printInventories(){
    //     foreach(Inventory inv in this.Inventories){
    //         Console.WriteLine($"{inv.ToString()}");
    //     }
    // }

    // public void printOrders(){
    //     foreach(Order ord in this.Orders){
    //         Console.WriteLine($"{ord.ToString()}");
    //     }
    // }

    public override string ToString()
    {
        return $"Name: {this.Name} \nAddress: {this.Address}";
    }

    public void ToDataRow(ref DataRow row){
        row["Name"] = this.Name ?? "";
        row["Address"] = this.Address ?? "";
        row["InventoryID"] = this.InventoryID;
        row["SOrderHistoryID"] = this.OrderID;
    }
}