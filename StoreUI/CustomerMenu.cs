namespace UI;

public class CustomerMenu{

    public int cid;

    private MBL _bl;

    public int numberorder;

    private string filePath = "../StoreDL/Customers.json";

    private string filePath2 = "../StoreDL/Storefronts.json";
    public CustomerMenu(int newId){
        cid = newId;
        _bl = new MBL();
    }

    public void Start(){
        bool exit = false;
        while(!exit){
            numberorder = 0;
            Console.WriteLine("Hello and Welcome!");
            Console.WriteLine("What would you like to do today?");
            Console.WriteLine("1. Place an order");
            Console.WriteLine("2. See your order history");
            Console.WriteLine("x. Exit");
            string input = Console.ReadLine();
            switch(input){
                case "1":
                    List<Storefront> allStorefronts = _bl.GetAllStorefronts();
                    List<Customer> allCustomers = _bl.GetAllCustomers();
                    for(int i = 0; i < allStorefronts.Count; i++){
                        Console.WriteLine($"[{i}] {allStorefronts[i].ToString()}");
                    }
                    Console.WriteLine("Select a store:");
                    int storeSelection = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Select an item:");
                    int inventorySelection = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("How many do you want to buy?");
                    int buyAmount = Int32.Parse(Console.ReadLine());
                    _bl.PlaceAnOrder(storeSelection, inventorySelection, buyAmount);
                    Order nOrder = new Order(cid, numberorder++, storeSelection);
                    allStorefronts[storeSelection].Orders.Add(nOrder);
                    string jsonString = JsonSerializer.Serialize(allStorefronts);
                    File.WriteAllText(filePath2, jsonString);
                    foreach(Customer cusItem in allCustomers){
                        if(cusItem.Id = cid){
                            cusItem.Orders.Add(nOrder);
                        }
                    }
                    string jsonString2 = JsonSerializer.Serialize(allCustomers);
                    file.WriteAllText(filePath, jsonString2);
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