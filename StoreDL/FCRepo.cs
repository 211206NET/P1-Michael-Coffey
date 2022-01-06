namespace DL;

public class FCRepo : ICRepo {
    private string filePath = "../StoreDL/Customers.json";
    private string filePath2 = "../StoreDL/Storefronts.json";

    public void GetOrderHistory(){}

    public void PlaceAnOrder(Product newP, int nAmount){}

    public void AddCustomer(Customer customerToAdd){}
}