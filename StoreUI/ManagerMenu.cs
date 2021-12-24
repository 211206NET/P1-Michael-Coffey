namespace UI;

public class ManagerMenu{

    private MBL _bl;

    public ManagerMenu(){
        _bl = new MBL();
    }

    public void Start(){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Hello boss!");
            Console.WriteLine("1. Get the stores");
            Console.WriteLine("2. Get the customers");
            Console.WriteLine("3. Add a store");
            Console.WriteLine("4. Replenish stock");
            Console.WriteLine("x. Exit");
            string input = Console.ReadLine();
            switch(input){
                case "1":
                    List<Storefront> allStorefronts = _bl.GetAllStorefronts();
                    if(allStorefronts.Count == 0){
                        Console.WriteLine("No stores found");
                    }
                    else{
                        Console.WriteLine("Here are the stores");
                        foreach(Storefront sto in _bl.GetAllStorefronts()){
                            Console.WriteLine(sto.ToString());
                            sto.printInventories();
                            sto.printOrders();
                        }
                    }
                break;
                case "2":
                    List<Customer> allCustomers = _bl.GetAllCustomers();
                    if(allCustomers == 0){
                        Console.WriteLine("No customers fround");
                    }
                    else{
                        Console.WriteLine("Current Customers");
                        foreach(Customer cus in _bl.GetAllCustomers()){
                            Console.WriteLine(cus.ToString());
                            cus.printOrderHistory();
                        }
                    }
                break;
                case "3":
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Address:");
                    string address = Console.ReadLine();
                    allStorefronts newStore = new Storefront(address, name);
                    _bl.AddStorefront(newStore);
                break;
                case "4":
                    List<Storefront> allStores = _bl.GetAllStorefronts();
                    for(int i = 0; i < allStores.Count; i++){
                        Console.WriteLine($"[{i}] {allStores[i].ToString()}");
                    }
                break;
                case "x":
                    Console.WriteLine("Seeya boss!");
                    exit = true;
                break;
                default:
                    Console.WriteLine("This ain't it chief.");
                break;
            }
        }
    }
}