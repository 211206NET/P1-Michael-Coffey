namespace DL;

public interface IMRepo{
    List<Storefront> GetAllStorefronts();

    List<Customer> GetAllCustomers();

    void AddStorefront(string _name, string _address, int _inventoryid, int _sorderhistoryid);

    void ReplenishStock(int idOfItem, int idOfInventory, int numberToAdd);
    void PlaceAnOrder(int idOfItem, int idOfInvnetory, int numberOfItems);
    void AddCustomer(string _username, string _email, string _password, string _customerorderhistoryid);
}