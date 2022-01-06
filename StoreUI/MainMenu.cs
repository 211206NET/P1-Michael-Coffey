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
            Console.WriteLine("2. Customer Log in");
            Console.WriteLine("3. Manager Log in");
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
                   Customer ncust = new Customer(cusID, username, password, email, corders);
                   corders++;
                   _mbl.AddCustomer(username, email, password);
                break;
                case "2":
                    MenuFactory.GetMenu("customer").Start();
                break;
                case "3":
                    MenuFactory.GetMenu("manager").Start();
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