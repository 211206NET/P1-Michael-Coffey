namespace Models;

using System.Data;
public class Customer
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Orders { get; set; }

    public Customer(){}

    public Customer(int id, string username, string password, string email, int orders){
        this.Id = (int) id;
        this.UserName = (string) username;
        this.Password = (string) password;
        this.Email = (string) email;
        this.Orders = (int) orders;
    }

    // public void printOrderHistory(){
    //     foreach(Order oh in this.Orders){
    //         Console.WriteLine(oh.ToString());
    //         oh.printLineItems();
    //         Console.WriteLine(oh.CalculateTotal());
    //     }
    // }

    public override string ToString()
    {
        return $"ID: {this.Id} \nUsername: {this.UserName} \nPassword: {this.Password} \nEmail: {this.Email}";
    }

    public void ToDataRow(ref DataRow row){
        row["CustomerID"] = this.Id;
        row["UserName"] = this.UserName;
        row["Email"] = this.Email;
        row["Password"] = this.Password;
        row["COrderHistory"] = this.Orders;
    }
}