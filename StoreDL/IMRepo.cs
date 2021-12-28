namespace DL;

public interface IMRepo{
    List<Storefront> GetAllStorefronts();

    List<Customer> GetAllCustomers();

    void AddStorefront(Storefront storefrontToAdd);

    void ReplenishStock(int indexOfItem, int inexOfInventory, int numberToAdd);
    void PlaceAnOrder(int indexOfItem, int indexOfInvnetory, int numberOfItems);
}