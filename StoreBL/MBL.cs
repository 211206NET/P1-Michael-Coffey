namespace BL;

using CustomExceptions;

public class MBL : IBL{
    private IMRepo _fdl;

    public MBL(IMRepo repo){
        _fdl = repo;
    }

    public async Task<List<Storefront>> GetAllStorefrontsAsync(){
        return await _fdl.GetAllStorefrontsAsync();
    }

    public async Task<List<Customer>> GetAllCustomersAsync(){
        return await _fdl.GetAllCustomersAsync();
    }

    public async Task<List<Inventory>> GetAllInventoriesAsync(){
        return await _fdl.GetAllInventoriesAsync();
    }

    public void AddStorefront(string _name, string _address, int _inventory){
        if(!_fdl.IsStorefrontDuplicate(new Storefront(_address, _name, _inventory))){ 
            _fdl.AddStorefront(_name, _address, _inventory);
        }
        else throw new DuplicateException("This store already exists");
    }

    public void AddInventory(int idOfItem, int amount){
        _fdl.AddInventory(idOfItem, amount); 
    }

    public void ReplenishStock(int nId, int nInv, int nAmo){
        _fdl.ReplenishStock(nId, nInv, nAmo);
    }

    public void PlaceAnOrder(int sId, int nBuy, int nSto, int nUser){
        _fdl.PlaceAnOrder(sId, nBuy, nSto, nUser);
    }

    public void AddCustomer(string _username, string _email, string _password){
        if(!_fdl.IsCustomerDuplicate(new Customer(_username, _password, _email))){
            _fdl.AddCustomer(_username, _email, _password);
        }
        else throw new DuplicateException("This customer already has an account!");
    }

    public Customer GetCustomerByID(int id){
        return _fdl.GetCustomerByID(id);
    }

    public Storefront GetStorefrontByID(int id){
        return _fdl.GetStorefrontByID(id);
    }

    public void AddProduct(int _ID, string _name, decimal _price, int _year, int _director, int _rating){
        _fdl.AddProduct(_ID, _name, _price, _year, _director, _rating);
    }

    public void DeleteCustomer(string _username){
        _fdl.DeleteCustomer(_username);
    }

    public void DeleteStorefront(string _storename){
        _fdl.DeleteStorefront(_storename);
    }

    public List<Product> GetInventory(int _storeid){
        return _fdl.GetInventory(_storeid);
    }

    public List<Order> GetOrdersDate(){
        return _fdl.GetOrdersDate();
    }

    public List<Order> GetOrdersCost(){
        return _fdl.GetOrdersCost();
    }

    public List<Order> GetCustomerOrderHistoryDate(int _userid){
        return _fdl.GetCustomerOrderHistoryDate(_userid);
    }

    public List<Order> GetCustomerOrderHistoryCost(int _userid){
        return _fdl.GetCustomerOrderHistoryCost(_userid);
    }

    public List<Order> GetStorefrontOrderHistoryDate(int _storeid){
       return  _fdl.GetStorefrontOrderHistoryDate(_storeid);
    }

    public List<Order> GetStorefrontOrderHistoryCost(int _storeid){
        return _fdl.GetStorefrontOrderHistoryCost(_storeid);
    }

    public bool IsStorefrontDuplicate(Storefront storefront){
        return _fdl.IsStorefrontDuplicate(storefront);
    }
    public bool IsCustomerDuplicate(Customer cus){
        return _fdl.IsCustomerDuplicate(cus);
    }

    // public List<Storefront> SearchStorefronts(string searchItem){
    //     _fdl.SearchStorefronts(searchItem);
    // }

    // public List<Product> SearchInventories(string searchItem){
    //     _fdl.SearchInventories(searchItem);
    // }
}