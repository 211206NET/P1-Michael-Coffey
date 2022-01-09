namespace BL;

public class MBL{
    private IMRepo _fdl;

    public MBL(IMRepo repo){
        _fdl = repo;
    }

    public List<Storefront> GetAllStorefronts(){
        return _fdl.GetAllStorefronts();
    }

    public List<Customer> GetAllCustomers(){
        return _fdl.GetAllCustomers();
    }

    public void AddStorefront(string _name, string _address, int _inventory){
        _fdl.AddStorefront(_name, _address, _inventory);
    }

    public void AddInventory(int idOfItem, int amount){
        _fdl.AddInventory(idOfItem, amount); 
    }

    public void ReplenishStock(int nId, int nInv, int nAmo){
        _fdl.ReplenishStock(nId, nInv, nAmo);
    }

    public void PlaceAnOrder(int sId, int nBuy, int nSto, string nUser){
        _fdl.PlaceAnOrder(sId, nBuy, nSto, nUser);
    }

    public void AddCustomer(string _username, string _email, string _password){
        _fdl.AddCustomer(_username, _email, _password);
    }

    public void AddProduct(int _ID, string _name, decimal _price, int _year, int _director, int _rating){
        _fdl.AddProduct(_ID, _name, _price, _year, _director, _rating);
    }

    public void DeleteCustomer(string _username){
        _fdl.DeleteCustomer(_username);
    }

    public void GetCustomerOrderHistory(string _username){
        _fdl.GetCustomerOrderHistory(_username);
    }

    // public List<Storefront> SearchStorefronts(string searchItem){
    //     _fdl.SearchStorefronts(searchItem);
    // }

    // public List<Product> SearchInventories(string searchItem){
    //     _fdl.SearchInventories(searchItem);
    // }
}