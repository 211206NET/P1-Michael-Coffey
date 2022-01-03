namespace BL;

public class MBL{
    private DBRepo _fdl;

    public MBL(){
        string connectionString = "../StoreUI/ConnectionString";
        _fdl = new DBRepo(connectionString);
    }

    public List<Storefront> GetAllStorefronts(){
        return _fdl.GetAllStorefronts();
    }

    public List<Customer> GetAllCustomers(){
        return _fdl.GetAllCustomers();
    }

    public void AddStorefront(Storefront storefrontToAdd){
        _fdl.AddStorefront(storefrontToAdd);
    }

    public void ReplenishStock(int nId, int nInv, int nAmo){
        _fdl.ReplenishStock(nId, nInv, nAmo);
    }

    public void PlaceAnOrder(int sId, int sInv, int nBuy){
        _fdl.PlaceAnOrder(sId, sInv, nBuy);
    }
}