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

    public void AddStorefront(Storefront nSto){
        List<Storefront> allStorefronts = GetAllStorefronts();
        allStorefronts.Add(nSto);
        string jsonString = JsonSerializer.Serialize(allStorefronts);
        File.WriteAllText(filePath, jsonString);
    }

    public void ReplenishStock(int nInd, int nInv, int nAmo){
        List<Storefront> allStorefronts = GetAllStorefronts();
        Storefront selectedStore = allStorefronts[nInd];
        Inventory selectedInventory = selectedStore.Inventories[nInv];
        if(selectedInventory.Quantity == 0){
            selectedInventory.Quantity = nAmo;
        }
        else{
            selectedInventory.Quantity += nAmo;
        }
        string jsonString = JsonSerializer.Serialize(allStorefronts);
        File.WriteAllText(filePath, jsonString);
    }
}