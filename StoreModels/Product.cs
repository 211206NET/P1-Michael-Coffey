namespace Models;

using System.Data;

public class Product
{
    public string ProductName { get; set; }
    public string Director { get; set; }
    public int DirectorID { get; set;}

    public string MPARating { get; set; }
    public int MPARatingID { get; set; }

    public int ReleaseYear { get; set; }
    public int ReleaseYearID { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int InventoryID { get; set; }

    public Product(){}

    public Product(int invenotryid, string productname, string directorid, string mparatingid, int releaseyearid, decimal price){
        this.InventoryID = invenotryid;
        this.ProductName = productname;
        this.Director = directorid;
        this.MPARating = mparatingid;
        this.ReleaseYear = releaseyearid;
        this.Price = price;
    }

    public Product(string productname, int directorid, int mparatingid, int releaseyearid, decimal price){
        this.ProductName = productname;
        this.DirectorID = directorid;
        this.MPARatingID = mparatingid;
        this.ReleaseYearID = releaseyearid;
        this.Price = price;
    }

    /// <summary>
    /// Takes a row from the Product table and converts it into a Product object
    /// </summary>
    /// <param name="row">Row from the Product Table</param>
    public Product(DataRow row){
        this.ProductName = (string) row["Title"] ?? "";
        this.Price = (decimal) row["Price"];
        this.ReleaseYear = (int) row["Year"];
        this.Director = (string) row["DirectorName"];
        this.MPARating = (string) row["Rating"];
    }

    public override string ToString()
    {
        return $"Inventory ID: {this.InventoryID} \nTitle: {this.ProductName} \nDir.: {this.Director} \nRating: {this.MPARating} \nYear: {this.ReleaseYear} \nCost: {this.Price} \nQuantity: {this.Quantity}";
    }

    /// <summary>
    /// Takes an instance of a Product object and converts it into a row on the Product Table
    /// </summary>
    /// <param name="row">Refernce to a row in the Product table</param>
    public void ToDataRow(ref DataRow row){
        this.ProductName = (string) row["Title"] ?? "";
        this.Price = (decimal) row["Price"];
        this.ReleaseYear = (int) row["Year"];
        this.Director = (string) row["Director"];
        this.MPARating = (string) row["MPARatingID"];
    }
}