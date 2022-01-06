namespace UI;

using System.IO;
using System.Text.Json;

public class MainMenu : IMenu{

    private MBL _mbl;

    //private string filePath = "../StoreDL/Customers.json";
    // public MainMenu(){
    //     _mbl = new MBL();
    // }

    public MainMenu(MBL mbl){
        _mbl = mbl;
    }

    public void Start(){
        bool exit = false;
        int corders = 3;
        int cusID = 2;
        Console.WriteLine("Welcome to the Film Stores!");

        while(!exit){
            Console.WriteLine("1. Sign up");
            Console.WriteLine("2. Log in");
            Console.WriteLine("x. Exit");
            string input = Console.ReadLine();
            switch(input){
                case "1":
                //    Console.WriteLine("Enter an ID number:");
                //    int id = Convert.ToInt32(Console.ReadLine());
                   cusID++;
                   Console.WriteLine("Enter a username:");
                   string username = Console.ReadLine();
                   Console.WriteLine("Enter a password:");
                   string password = Console.ReadLine();
                   Console.WriteLine("Enter an email address:");
                   string email = Console.ReadLine();
                   Customer ncust = new Customer(cusID, username, password, email);
                   corders++;
                   _mbl.AddCustomer(username, email, password);
                break;
                case "2":
                    List<Customer> theCustomers = _mbl.GetAllCustomers();
                    Console.WriteLine("Enter ID number:");
                    int nid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter username:");
                    string nusername = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string npassword = Console.ReadLine();
                    Console.WriteLine("Enter email:");
                    string nemail = Console.ReadLine();
                    Customer ncustomer = new Customer(nid, nusername, npassword, nemail, corders);
                    foreach(Customer cust in theCustomers){
                        if(ncustomer.Id == cust.Id){
                            if(ncustomer.UserName == cust.UserName){
                                if(ncustomer.Password == cust.Password){
                                    if(ncustomer.Email == cust.Email){
                                        MenuFactory.GetMenu("customer").Start();
                                    }
                                }
                            }
                        }
                        if(nid == 0 && nusername == "storeManager"){
                            if(npassword == "allCinema" && nemail == "michaelcoffey1999@gmail.com"){
                                MenuFactory.GetMenu("manager").Start();
                            }
                        }
                    else{
                        Console.WriteLine("Unknown");
                    }
                }
                break;
                case "x":
                    exit = true;
                    Console.WriteLine("Goodbye!");
                break;
                default:
                    Console.WriteLine("That's not an option!");
                break;
            }
        }
    }
}