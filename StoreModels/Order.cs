namespace Models;

using System.Data;

public class Order
{
    //You can also use DateTime data type for this
    public DateOnly OrderDate { get; set; }
    public string CustomerName { get; set; }
    public int OrderNumber { get; set; }
    public string StoreName { get; set; }
    public int LineItemID { get; set; }
    public decimal Total { get; set; }

    public Order(){}

    public Order(int ordernumber, string customerid, string storeid, int lineitemid){
        this.OrderDate = new DateOnly();
        this.CustomerName = customerid;
        this.OrderNumber = ordernumber;
        this.StoreName = storeid;
        this.LineItemID = lineitemid;
        //this.CalculateTotal();
    }

    public Order(DataRow row){
        this.OrderNumber = (int) row["OrderID"];
        this.OrderDate = (DateOnly) row["DateOfOrder"];
        this.CustomerName = (string) row["UserName"];
        this.StoreName = (string) row["Name"];
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
        return $"Date: {this.OrderDate} \nCustomer UserName: {this.CustomerName} \nOrder ID: {this.OrderNumber} \nStore Name: {this.StoreName} \n Total Cost: {this.Total}";
    }

    public void ToDataRow(ref DataRow row){
        this.OrderNumber = (int) row["OrderID"];
        this.OrderDate = (DateOnly) row["DateOfOrder"];
        this.CustomerName = (string) row["UserName"];
        this.StoreName= (string) row["Name"];
        this.Total = (decimal) row["Total"];
        this.LineItemID = (int) row["LineItemID"];
    }
}