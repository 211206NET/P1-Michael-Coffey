namespace DL;
public interface ICRepo
{

    List<Order> GetOrderHistory();
    void PlaceAnOrder(Product p);
}
