namespace Models;

public class Customer
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }

    public Customer(){}

    public Customer(int id, string username, string password, string email){
        this.Id = id;
        this.UserName = username;
        this.Password = password;
        this.Email = email;
        this.Orders = new List<Order>();
    }

    public void printOrderHistory(){
        foreach(Order oh in this.Orders){
            Console.WriteLine(oh.ToString());
            oh.printLineItems();
            Console.WriteLine(oh.CalculateTotal());
        }
    }

    public override string ToString()
    {
        return $"ID: {this.Id} \nUsername: {this.UserName} \nPassword: {this.Password} \nEmail: {this.Email}";
    }
}