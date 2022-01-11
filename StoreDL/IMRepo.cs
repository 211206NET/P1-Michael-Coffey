namespace DL;

public interface IMRepo{
    List<Storefront> GetAllStorefronts();

    List<Customer> GetAllCustomers();

    void AddStorefront(string _name, string _address, int _inventory);

    void AddInventory(int idOfItem, int amount);

    void ReplenishStock(int idOfItem, int idOfInventory, int numberToAdd);
    void PlaceAnOrder(int idOfItem, int numberOfItems, int stoId, int cusId);
    void AddCustomer(string _username, string _email, string _password);

    void AddProduct(int proID, string proTitle, decimal proPrice, int proYear, int proDirector, int proRating);

    void DeleteCustomer(string username);
    List<Order> GetCustomerOrderHistoryDate(int _userid);
    List<Order> GetCustomerOrderHistoryCost(int _userid);
    List<Order> GetStorefrontOrderHistoryDate(int _storeid);
    List<Order> GetStorefrontOrderHistoryCost(int _storeid);
    bool IsStorefrontDuplicate(Storefront newStorefront);
    bool IsCustomerDuplicate(Customer newCustomer);
}