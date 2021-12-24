namespace UI;

public class MainMenu{

    private MBL _mbl;

    private string filePath = "../StoreDL/Customers.json";
    public MainMenu(){
        _mbl = new MBL();
    }

    public void Start(){
        bool exit = false;
        Console.WriteLine("Welcome to the Film Stores!");

        while(!exit){
            Console.WriteLine("1. Sign up");
            Console.WriteLine("2. Log in");
            Console.WriteLine("x. Exit");
            string input = Console.ReadLine();
            switch(input){
                case "1":
                   Console.WriteLine("Enter an ID number:");
                   int id = Convert.ToInt32(Console.ReadLine());
                   Console.WriteLine("Enter a username:");
                   string username = Console.ReadLine();
                   Console.WriteLine("Enter a password:");
                   string password = Console.ReadLine();
                   Console.WriteLine("Enter an email address:");
                   string email = Console.ReadLine();
                   Customer ncust = new Customer(id, username, password, email);
                   List<Customer> allCustomers = _mbl.GetAllCustomers();
                   allCustomers.Add(ncust);
                   string jsonString = JsonSerializer.Serialize(allCustomers);
                   File.WriteAllText(filePath, jsonString);
                break;
                case "2":
                    List<Customer> theCustomers = _mbl.GetAllCustomers();
                    Console.WriteLine("Enter ID number:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter email:");
                    string email = Console.ReadLine();
                    Customer ncustomer = new Customer(id, username, password, email);
                    foreach(Customer cust in theCustomers){
                        if(ncustomer.Id == cust.Id){
                            if(ncustomer.UserName == cust.UserName){
                                if(ncustomer.Password == cust.Password){
                                    if(ncustomer.Email == cust.Email){
                                        new CustomerMenu().Start();
                                    }
                                }
                            }
                        }
                    }
                    if(id == 0 && username == "storeManager"){
                        if(password == "allCinema" && email == "michaelcoffey1999@gmail.com"){
                            new ManagerMenu().Start();
                        }
                    }
                    else{
                        Console.WriteLine("Unknown");
                    }
                break;
                case "x":
                    exit = true;
                break;
                default:
                    Console.WriteLine("That's not an option!");
                break;
            }
        }
    }
}