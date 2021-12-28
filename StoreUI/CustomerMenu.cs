namespace UI;

public class CustomerMenu{

    public int cid;

    private MBL _bl;

    private string filePath = "../StoreDL/Customers.json";

    private string filePath2 = "../StoreDL/Storefronts.json";
    public CustomerMenu(int newId){
        cid = newId;
        _bl = new MBL();
    }

    public void Start(){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Hello and Welcome!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1. Place an order");
            Console.WriteLine("2. See your order history");
            Console.WriteLine("x. Exit");
            string input = Console.ReadLine();
            switch(input){
                case "1":
                break;
                case "2":
                  List<Customer> allCustomers = _bl.GetAllCustomers();
                  foreach(Customer cus in allCustomers){
                      if(cus.Id == cid){
                          cus.printOrderHistory();
                      }
                  }
                break;
                case "x":
                    Console.WriteLine("Have a nice day!");
                    exit = true;
                break;
                default:
                    Console.WriteLine("I'm sorry friend, I'm afraid I can't do that.");
                break;
            }
        }
    }
}