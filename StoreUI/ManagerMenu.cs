namespace UI;

using System.IO;
using System.Text.Json;

public class ManagerMenu : IMenu{

    private MBL _bl;
    //private string filePath = "../StoreDL/Storefronts.json";

    // public ManagerMenu(){
    //     _bl = new MBL();
    // }

    public ManagerMenu(MBL mbl){
        _bl = mbl;
    }

    public void Start(){
        bool exit = false;
        while(!exit){
            Console.WriteLine("Hello boss!");
            Console.WriteLine("1. Get the stores");
            Console.WriteLine("2. Get the customers");
            Console.WriteLine("3. Add a store");
            Console.WriteLine("4. Replenish stock");
            Console.WriteLine("5. Add an inventory");
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
                            //sto.printInventories();
                            //sto.printOrders();
                        }
                    }
                break;
                case "2":
                    List<Customer> allCustomers = _bl.GetAllCustomers();
                    if(allCustomers.Count == 0){
                        Console.WriteLine("No customers fround");
                    }
                    else{
                        Console.WriteLine("Current Customers");
                        foreach(Customer cus in _bl.GetAllCustomers()){
                            Console.WriteLine(cus.ToString());
                            //cus.printOrderHistory();
                        }
                    }
                break;
                case "3":
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Address:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Inventory:");
                    int inventoryid = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("History:");
                    int shid = Int32.Parse(Console.ReadLine());
                    Storefront newStore = new Storefront(address, name, inventoryid, shid);
                    _bl.AddStorefront(name, address, inventoryid, shid);
                break;
                case "4":
                    List<Storefront> allStores = _bl.GetAllStorefronts();
                    Console.WriteLine("Select a store");
                    for(int i = 0; i < allStores.Count; i++){
                        Console.WriteLine($"[{i}] {allStores[i].ToString()}");
                    }
                    Console.WriteLine("Select a store");
                    int storeSelection = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Select an inventory");
                    int inventorySelection = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Select a new amount");
                    int newStock = Int32.Parse(Console.ReadLine());
                    _bl.ReplenishStock(storeSelection, inventorySelection, newStock);
                break;
                case "5":
                    Console.WriteLine("Enter a store");
                    int nStoreSelection = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter a store ID");
                    int nStoreID = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter a quantity");
                    int nQuantity = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the film's title");
                    string nTitle = Console.ReadLine();
                    Console.WriteLine("Enter the film's director");
                    int nDirector = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter a film's rating");
                    int nRating = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter a film's release year");
                    int nYear = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the price");
                    decimal nPrice = Decimal.Parse(Console.ReadLine());
                    Product nProduct = new Product(nTitle, nDirector, nRating, nYear, nPrice);
                    //Inventory nInventory = new Inventory(nStoreID, nQuantity, nProduct);
                    List<Storefront> allStorefrontItems = _bl.GetAllStorefronts();
                    // allStorefrontItems[nStoreSelection].Inventories.Add(nInventory);
                    // string jsonString = JsonSerializer.Serialize(allStorefrontItems);
                    // File.WriteAllText(filePath, jsonString);
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