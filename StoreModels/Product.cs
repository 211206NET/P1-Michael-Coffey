namespace Models;

public class Product
{
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Product(){}

    public Product(string productname, string description, decimal price){
        this.ProductName = productname;
        this.Description = description;
        this.Price = price;
    }

    public override string ToString()
    {
        return $"Title: {this.ProductName} \nDescription: {this.Description} \nCost: {this.Price}";
    }
}