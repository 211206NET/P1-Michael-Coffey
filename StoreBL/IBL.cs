namespace BL;

public interface IBL{
    Task<List<Storefront>> GetAllStorefrontsAsync();
    Task<List<Customer>> GetAllCustomersAsync();
    Task<List<Inventory>> GetAllInventoriesAsync();
    void AddStorefront(string _name, string _address, int _inventory);
    void AddInventory(int idOfItem, int amount);
    void ReplenishStock(int nId, int nInv, int nAmo);
    void PlaceAnOrder(int sId, int nBuy, int nSto, int nUser);
    void AddCustomer(string _username, string _email, string _password);
    void PutCOHIDIntoCustomer(int cid, int id);
    void PutSOHIDIntoStorefront(int sid, int id);
    void PutOHInCOrderHistory(int ohId, int id);
    void PutOHInSOrderHistory(int ohId, int id);
    Customer GetCustomerByID(int id);
    Storefront GetStorefrontByID(int id);
    Product GetProductByID(int id);
    bool Login(string username, string email, string password);
    void AddProduct(int _ID, string _name, decimal _price, int _year, int _director, int _rating);
    void AddDirectorToProduct(int pid, string ndirector);
    void AddReleaseYearToProduct(int pid, int nyear);
    void AddRatingToProduct(int pid, string nrating);
    void DeleteCustomer(string _username);
    void DeleteStorefront(string _storename);
    void DeleteProduct(string _productname);
    void DeleteInventory(int iId);
    void DeleteOrder(int oid);
    List<Product> GetInventory(int _storeid);
    List<Order> GetOrdersDate();
    List<Order> GetOrdersCost();
    List<Order> GetCustomerOrderHistoryDate(int _userid);
    List<Order> GetCustomerOrderHistoryCost(int _userid);
    List<Order> GetStorefrontOrderHistoryDate(int _storeid);
    List<Order> GetStorefrontOrderHistoryCost(int _storeid);
    bool IsStorefrontDuplicate(Storefront storefront);
    bool IsCustomerDuplicate(Customer cus);
}