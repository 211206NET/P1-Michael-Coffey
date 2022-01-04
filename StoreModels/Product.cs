namespace Models;

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

    public override string ToString()
    {
        return $"Title: {this.ProductName} \nDir.: {this.DirectorId} \nRating: {this.MPARatingID} \n Year: {this.ReleaseYearId} \nCost: {this.Price}";
    }
}