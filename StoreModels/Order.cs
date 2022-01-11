namespace Models;

using System.Data;

public class Order
{
    //You can also use DateTime data type for this
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public int StoreID { get; set; }
    public int LineItemID { get; set; }
    public decimal Total { get; set; }

    public Order(){}

    public Order(int ordernumber, int customerid, int storeid, int lineitemid){
        this.OrderNumber = ordernumber;
        this.OrderDate = new DateTime();
        this.CustomerId = customerid;
        this.StoreID = storeid;
        this.LineItemID = lineitemid;
        //this.CalculateTotal();
    }

    public Order(DataRow row){
        this.OrderNumber = (int) row["OrderID"];
        this.OrderDate = (DateTime) row["DateOfOrder"];
        this.CustomerId = (int) row["CustomerID"];
        this.StoreID = (int) row["StoreID"];
        this.Total = (decimal) row["Total"];
        this.LineItemID = (int) row["LineItemID"];

    }
    // public decimal CalculateTotal() {
    //     a method that would go through each lineitem in LineItems property
    //     and sets the total property of the particular order object
    //     decimal total = 0;
    //     if(this.LineItems?.Count > 0)
    //     {
    //         foreach(LineItem lineitem in this.LineItems)
    //         {
    //             //multiply the product's price by how many we're buying
    //             total += lineitem.Item.Price * lineitem.Quantity;
    //         }
    //     }
    //     this.Total = total;
    //     return total;
    // }

    // public void printLineItems(){
    //     foreach(LineItem li in this.LineItems){
    //         Console.WriteLine($"{li.ToString()}");
    //     }
    // }

    public override string ToString()
    {
        return $"Date: {this.OrderDate} \nCustomer: {this.CustomerId} \nOrder ID: {this.OrderNumber} \nStore: {this.StoreID} \nTotal Cost: {this.Total}";
    }

    public void ToDataRow(ref DataRow row){
        this.OrderNumber = (int) row["OrderID"];
        this.OrderDate = (DateTime) row["DateOfOrder"];
        this.CustomerId = (int) row["CustomerID"];
        this.StoreID= (int) row["StoreID"];
        this.Total = (decimal) row["Total"];
        this.LineItemID = (int) row["LineItemID"];
    }
}