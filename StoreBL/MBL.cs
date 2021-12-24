namespace BL;

public class MBL{
    private FMRepo _fdl;

    public MBL(){
        _fdl = new FMRepo();
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

    public void ReplenishStock(int nInd, int nInv, int nAmo){
        _fdl.ReplenishStock(nInd, nInv, nAmo);
    }
}