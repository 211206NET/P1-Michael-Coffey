namespace Models;

using System.Data;

public class Order
{
    //You can also use DateTime data type for this
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public int OrderNumber { get; set; }
    public string StoreName { get; set; }
    public int LineItemID { get; set; }
    public decimal Total { get; set; }

    public Order(){}

    public Order(int ordernumber, string customerid, string storeid, int lineitemid){
        this.OrderNumber = ordernumber;
        this.OrderDate = new DateTime();
        this.CustomerName = customerid;
        this.StoreName = storeid;
        this.LineItemID = lineitemid;
        //this.CalculateTotal();
    }

    /// <summary>
    /// Takes a row from the ItemOrder table and converts it to an Order object
    /// </summary>
    /// <param name="row">Row from the ItemOrder table</param>
    public Order(DataRow row){
        this.OrderNumber = (int) row["OrderID"];
        this.OrderDate = (DateTime) row["DateOfOrder"];
        this.CustomerName = (string) row["UserName"];
        this.StoreName = (string) row["Name"];
        this.Total = (decimal) row["Total"];
        this.LineItemID = (int) row["LineItemID"];

    }

    public override string ToString()
    {
        return $"Date: {this.OrderDate} \nCustomer: {this.CustomerName} \nOrder ID: {this.OrderNumber} \nStore: {this.StoreName} \nTotal Cost: {this.Total}";
    }

    /// <summary>
    /// Takes an instance of an Order object and turns it into a row in the ItemOrder table
    /// </summary>
    /// <param name="row">Refence to a row in the ItemOrder table</param>
    public void ToDataRow(ref DataRow row){
        this.OrderNumber = (int) row["OrderID"];
        this.OrderDate = (DateTime) row["DateOfOrder"];
        this.CustomerName = (string) row["UserName"];
        this.StoreName= (string) row["Name"];
        this.Total = (decimal) row["Total"];
        this.LineItemID = (int) row["LineItemID"];
    }
}