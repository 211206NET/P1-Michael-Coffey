namespace Models;

public class Storefront
{
    public string Address { get; set; }
    public string Name { get; set; }
    public List<Inventory> Inventories { get; set; }
    public List<Order> Orders { get; set; }

    public Storefront(){}

    public Storefront(string address, string name){
        this.Address = address;
        this.Name = name;
        this.Inventories = new List<Inventory>();
        this.Orders = new List<Order>();
    }

    public void printInventories(){
        foreach(Inventory inv in this.Inventories){
            Console.WriteLine($"{inv.ToString()}");
        }
    }

    public void printOrders(){
        foreach(Order ord in this.Orders){
            Console.WriteLine($"{ord.ToString()}");
        }
    }

    public override string ToString()
    {
        return $"Name: {this.Name} \nAddress: {this.Address}";
    }
}