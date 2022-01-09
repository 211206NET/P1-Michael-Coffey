namespace Models;

using System.Data;

public class Product
{
    public string ProductName { get; set; }
    public int DirectorID { get; set; }

    public int MPARatingID { get; set; }

    public int ReleaseYearID { get; set; }
    public decimal Price { get; set; }

    public Product(){}

    public Product(string productname, int directorid, int mparatingid, int releaseyearid, decimal price){
        this.ProductName = productname;
        this.DirectorID = directorid;
        this.MPARatingID = mparatingid;
        this.ReleaseYearID = releaseyearid;
        this.Price = price;
    }

    public Product(DataRow row){
        this.ProductName = (string) row["Title"] ?? "";
        this.Price = (decimal) row["Price"];
        this.ReleaseYearID = (int) row["YearID"];
        this.DirectorID = (int) row["DirectorID"];
        this.MPARatingID = (int) row["MPARatingID"];
    }

    public override string ToString()
    {
        return $"Title: {this.ProductName} \nDir.: {this.DirectorID} \nRating: {this.MPARatingID} \n Year: {this.ReleaseYearID} \nCost: {this.Price}";
    }

    public void ToDataRow(ref DataRow row){
        this.ProductName = (string) row["Title"] ?? "";
        this.Price = (decimal) row["Price"];
        this.ReleaseYearID = (int) row["YearID"];
        this.DirectorID = (int) row["DirectorID"];
        this.MPARatingID = (int) row["MPARatingID"];
    }
}