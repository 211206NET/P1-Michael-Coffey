namespace BL;

public interface IBL{
    Task<List<Storefront>> GetAllStorefrontsAsync();
    Task<List<Customer>> GetAllCustomersAsync();
    void AddStorefront(string _name, string _address, int _inventory);
    void AddInventory(int idOfItem, int amount);
    void ReplenishStock(int nId, int nInv, int nAmo);
    void PlaceAnOrder(int sId, int nBuy, int nSto, int nUser);
    void AddCustomer(string _username, string _email, string _password);
    void AddProduct(int _ID, string _name, decimal _price, int _year, int _director, int _rating);
    void DeleteCustomer(string _username);
    List<Product> GetInventory(int _storeid);
    List<Order> GetCustomerOrderHistoryDate(int _userid);
    List<Order> GetCustomerOrderHistoryCost(int _userid);
    List<Order> GetStorefrontOrderHistoryDate(int _storeid);
    List<Order> GetStorefrontOrderHistoryCost(int _storeid);
    bool IsStorefrontDuplicate(Storefront storefront);
    bool IsCustomerDuplicate(Customer cus);
}