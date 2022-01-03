namespace Models;

public class Product
{
    public string ProductName { get; set; }
    public string Director { get; set; }

    public string MPARating { get; set; }

    public int ReleaseYear { get; set; }
    public decimal Price { get; set; }

    public Product(){}

    public Product(string productname, string director, string mparating, int releaseyear, decimal price){
        this.ProductName = productname;
        this.Director = director;
        this.MPARating = mparating;
        this.ReleaseYear = releaseyear;
        this.Price = price;
    }

    public override string ToString()
    {
        return $"Title: {this.ProductName} \nDir.: {this.Director} \nRating: {this.MPARating} \n Year: {this.ReleaseYear} \nCost: {this.Price}";
    }
}