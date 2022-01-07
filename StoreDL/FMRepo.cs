namespace DL;

using System.IO;
using System.Text.Json;

public class FMRepo : IMRepo {
    private string filePath = "../StoreDL/Storefronts.json";
    private string filePath2 = "../StoreDL/Customers.json";

    public List<Storefront> GetAllStorefronts(){
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Storefront>>(jsonString);
    }

    public List<Customer> GetAllCustomers(){
        string jsonString = File.ReadAllText(filePath2);
        return JsonSerializer.Deserialize<List<Customer>>(jsonString);
    }

    public void AddStorefront(string name, string address){
        // List<Storefront> allStorefronts = GetAllStorefronts();
        // allStorefronts.Add(nSto);
        // string jsonString = JsonSerializer.Serialize(allStorefronts);
        // File.WriteAllText(filePath, jsonString);
    }

    public void AddInventory(int idOfItem, int idOfInventory, int amount){    
    }

    public void ReplenishStock(int nInd, int nInv, int nAmo){
        // List<Storefront> allStorefronts = GetAllStorefronts();
        // Storefront selectedStore = allStorefronts[nInd];
        // Inventory selectedInventory = selectedStore.Inventories[nInv];
        // if(selectedInventory.Quantity == 0){
        //     selectedInventory.Quantity = nAmo;
        // }
        // else{
        //     selectedInventory.Quantity += nAmo;
        // }
        // string jsonString = JsonSerializer.Serialize(allStorefronts);
        // File.WriteAllText(filePath, jsonString);
    }

    public void PlaceAnOrder(int sInd, int sInv, int nBuy, int nSto, string nUser){
        // List<Storefront> allStorefronts = GetAllStorefronts();
        // Storefront selectedStore = allStorefronts[sInd];
        // Inventory selectedInventory = selectedStore.Inventories[sInv];
        // if(selectedInventory.Quantity > 0){
        //     selectedInventory.Quantity -= nBuy;
        // }
        // string jsonString = JsonSerializer.Serialize(allStorefronts);
        // File.WriteAllText(filePath, jsonString);
    }

    public void AddCustomer(string username, string email, string password){
    }

    public void AddProduct(int _ID, string _name, decimal _price, int _year, int _director, int _rating){
    }

    public void DeleteCustomer(string usname){}
}