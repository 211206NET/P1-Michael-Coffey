namespace BL;

public class CBL {
    private FCRepo _cdl;

    public CBL(){
        _cdl = new FCRepo();
    }

    public void GetOrderHistory(){
        _cdl.GetOrderHistory();
    }

    public void PlaceAnOrder(Product newPro){
        _cdl.PlaceAnOrder();
    }
}