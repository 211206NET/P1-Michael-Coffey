namespace DL;

using Microsoft.Data.SqlClient;
using System.Data;

public class DBRepo : IMRepo{ 

    private string _connectionString; 

    public DBRepo(string connectionString){
        _connectionString = connectionString;
        //Console.WriteLine(_connectionString);
    }
    public List<Storefront> GetAllStorefronts(){
        List<Storefront> allStorefronts = new List<Storefront>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        string stoSelect = "SELECT * FROM Storefront";
        string invSelect = "SELECT * FROM Inventory";
        string histSelect = "SELECT * FROM StoreOrderHistory";
        string proSelect = "SELECT * FROM Product";
        string ordSelect = "SELECT * FROM ItemOrder";
        DataSet FSSet = new DataSet();
        using SqlDataAdapter stoAdapter = new SqlDataAdapter(stoSelect, connection);
        using SqlDataAdapter invAdapter = new SqlDataAdapter(invSelect, connection);
        using SqlDataAdapter hisAdapter = new SqlDataAdapter(histSelect, connection);
        using SqlDataAdapter proAdapter = new SqlDataAdapter(proSelect, connection);
        using SqlDataAdapter ordAdapter = new SqlDataAdapter(ordSelect, connection);
        stoAdapter.Fill(FSSet, "Storefront");
        invAdapter.Fill(FSSet, "Inventory");
        hisAdapter.Fill(FSSet, "StoreOrderHistory");
        proAdapter.Fill(FSSet, "Product");
        ordAdapter.Fill(FSSet, "ItemOrder");
        DataTable? StorefrontTable = FSSet.Tables["Storefront"];
        DataTable? InventoryTable = FSSet.Tables["Inventory"];
        DataTable? HistoryTable = FSSet.Tables["StoreOrderHistory"];
        DataTable? ProductTable = FSSet.Tables["Product"];
        DataTable? OrderTable = FSSet.Tables["ItemOrder"];
        if(StorefrontTable != null && InventoryTable != null){
            foreach(DataRow row in StorefrontTable.Rows){
                Storefront nsto = new Storefront(row);
                // nsto.InventoryID = InventoryTable.AsEnumerable().Where(r => (int) r["InventoryID"] == nsto.InvnetoryID).Select(
                //     r => 
                //         new Inventory{
                //             InventoryID = (int) r["InventoryID"],
                //             ProductID = (int) r["ProductID"],
                //             Quantity = (int) r["Quantity"]
                //         }
                // ).ToList();
                // nsto.SOrderHistoryID = HistoryTable.AsEnumerable().Where(r => (int) r["SOrderHistoryID"] == nsto.SOrderHistoryID).Select(
                //     r => 
                //          new Order{
                //             OrderID = (int) r["OrderID"],
                //             DateOfOrder = (Date) r["DateOfOrder"],
                //             CustomerID = (int) r["CustomerID"],
                //             StoreID = (int) r["StoreID"],
                //             Total = (decimal) r["Total"],
                //             LineItemID = (int) r["LineItemID"]
                //          }
                // ).ToList();
                allStorefronts.Add(nsto);
            }
        }
        return allStorefronts;
    }

    public List<Customer> GetAllCustomers(){
        List<Customer> allCustomers = new List<Customer>();
        using SqlConnection connection = new SqlConnection(_connectionString);
        string custCollect = "SELECT * FROM Customer";
        string histCollect = "SELECT * FROM CustomerOrderHistory";
        string ordCollect = "SELECT * FROM ItemOrder";
        string linorCollect = "SELECT * FROM LineOrder";
        string proCollect = "SELECT * FROM Product";
        DataSet cusSet = new DataSet();
        using SqlDataAdapter custAdapter = new SqlDataAdapter(custCollect, connection);
        using SqlDataAdapter histCollector = new SqlDataAdapter(histCollect, connection);
        using SqlDataAdapter ordCollector = new SqlDataAdapter(ordCollect, connection);
        using SqlDataAdapter linorCollector = new SqlDataAdapter(linorCollect, connection);
        using SqlDataAdapter proCollector = new SqlDataAdapter(proCollect, connection);
        custAdapter.Fill(cusSet, "Customer");
        histCollector.Fill(cusSet, "CustomerOrderHistory");
        ordCollector.Fill(cusSet, "ItemOrder");
        linorCollector.Fill(cusSet, "LineOrder");
        proCollector.Fill(cusSet, "Product");
        DataTable? CustomerTable = cusSet.Tables["Customer"];
        DataTable? HistoryTable = cusSet.Tables["CustomerOrderHistory"];
        DataTable? OrderTable = cusSet.Tables["ItemOrder"];
        DataTable? LineOrderTable = cusSet.Tables["LineOrder"];
        DataTable? ProductTable = cusSet.Tables["Product"];
        if(CustomerTable != null && HistoryTable != null){
            foreach(DataRow row in CustomerTable.Rows){
                Customer cus = new Customer(row);
                // cus.Orders = HistoryTable.AsEnumerable().Where(r => (int) r["COrderHistoryID"] = cus.Orders).Select(
                //     r => 
                //           new Order{
                //               OrderID = (int) row["OrderID"],
                //               DateOfOrder = (Date) row["DateOfOrder"],
                //               CustomerID = (int) row["CustomerID"],
                //               StoreID = (int) row["StoreID"],
                //               Total = (decimal) row["Total"],
                //               LineItemID = (int) row["LineItemID"]
                //           }
                // ).ToList();
                allCustomers.Add(cus);
            }
        }
        return allCustomers;
    }

    public void AddStorefront(string _name, string _address, int _inventoryid){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string cmdForSql = "INSERT INTO Storefront (Name, Address, InventoryID) VALUES (@nam, @addr, @invid)";
            string sOrderSql = "INSERT INTO StoreOrderHistory DEFAULT VALUES";
            using(SqlCommand cmd0 = new SqlCommand(sOrderSql, connection)){
                cmd0.ExecuteNonQuery();
            }
            using(SqlCommand cmd = new SqlCommand(cmdForSql, connection)){
                SqlParameter param = new SqlParameter("@nam", _name);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@addr", _address);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@invid", _inventoryid);
                cmd.Parameters.Add(param);
                // param = new SqlParameter("@soh", _sorderhistoryid);
                // cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void AddInventory(int idOfItem, int amount){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlCmd = "INSERT INTO Inventory (ProductID, Quantity) VALUES (@proID, @quan)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection)){
                // SqlParameter param = new SqlParameter("@invID", idOfInventory);
                // cmd.Parameters.Add(param);
                SqlParameter param = new SqlParameter("@proID", idOfItem);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@quan", amount);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public void ReplenishStock(int idOfItem, int idOfInventory, int numberToAdd){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlCmd = "UPDATE Inventory SET Quantity += @quan WHERE InventoryID = @invID AND ProductID = @proID";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection)){
                SqlParameter param = new SqlParameter("@invID", idOfInventory);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@proID", idOfItem);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@quan", numberToAdd);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public void PlaceAnOrder(int idOfItem, int numberOfItems, int nStore, int cusid){
        List<Customer> allCustomers = GetAllCustomers();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlCmd = "INSERT INTO LineOrder (ProductID, Quantity) VALUES (@proID, @quan)";
            string sqlCmd2 = "UPDATE Inventory SET Quantity -= @quan WHERE ProductID = @proID";
            string orderCmd = "INSERT INTO ItemOrder (DateOfOrder, CustomerID, StoreID) VALUES (GETDATE(), @cusID, @stoID)";
            //string cusSelect = "SELECT * FROM Customer WHERE UserName = @cusNam";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection)){
                // SqlParameter param = new SqlParameter("@linID", idOfLineOrder);
                // cmd.Parameters.Add(param);
                SqlParameter param = new SqlParameter("@proID", idOfItem);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@quan", numberOfItems);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            using(SqlCommand cmd2 = new SqlCommand(sqlCmd2, connection)){
                SqlParameter param2 = new SqlParameter("@quan", numberOfItems);
                cmd2.Parameters.Add(param2);
                param2 = new SqlParameter("@proID", idOfItem);
                cmd2.Parameters.Add(param2);
                cmd2.ExecuteNonQuery();
            }
            using(SqlCommand cmd3 = new SqlCommand(orderCmd, connection)){
                SqlParameter param3 = new SqlParameter("@cusID", cusid);
                cmd3.Parameters.Add(param3);
                param3 = new SqlParameter("@stoID", nStore);
                cmd3.Parameters.Add(param3);
                cmd3.ExecuteNonQuery();
                // param3 = new SqlParameter("@liorID", idOfLineOrder);
                // cmd3.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public void AddCustomer(string _username, string _email, string _password){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string cmdSql = "INSERT INTO Customer (UserName, Email, Password) VALUES (@usna, @emai, @paswor)";
            string histCmd = "INSERT INTO CustomerOrderHistory DEFAULT VALUES";
            using(SqlCommand cmd0 = new SqlCommand(histCmd, connection)){
                cmd0.ExecuteNonQuery();
            }
            using(SqlCommand cmd = new SqlCommand(cmdSql, connection)){
                SqlParameter param = new SqlParameter("@usna", _username);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@emai", _email);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@paswor", _password);
                cmd.Parameters.Add(param);
                // param = new SqlParameter("@coh", _corderhistoryid);
                // cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void AddProduct(int _ID, string _name, decimal _price, int _year, int _director, int _rating){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlPro = "INSERT INTO Product (ProductID, Title, Price, YearID, DirectorID, RatingID) VALUES (@proid, @tle, @pri, @yea, @dir, @rat)";
            using(SqlCommand cmd = new SqlCommand(sqlPro, connection)){
                SqlParameter param = new SqlParameter("@proid", _ID);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@tle", _name);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@pri", _price);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@yea", _year);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@dir", _director);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@rat", _rating);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DeleteCustomer(string _userName){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string delCmd = "DELETE FROM Customer WHERE UserName = @usnam";
            using(SqlCommand cmd = new SqlCommand(delCmd, connection)){
                // SqlParameter param = new SqlParameter("@cusid", _cusID);
                // cmd.Parameters.Add(param);
                SqlParameter param = new SqlParameter("@usnam", _userName);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void GetCustomerOrderHistoryDate(string _username){
        List<Order> ordHistory = new List<Order>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string selectOrHis = "SELECT ItemOrder.OrderID, ItemOrder.DateOfOrder, Customer.UserName, Storefront.Name, LineOrder.Quantity*Product.Price AS Total FROM CustomerOrderHistory INNER JOIN ItemOrder ON CustomerOrderHistory.OrderID = ItemOrder.OrderID INNER JOIN Customer ON ItemOrder.CustomerID = Customer.CustomerID INNER JOIN LineOrder ON ItemOrder.LineItemID = LineOrder.LineItemID INNER JOIN Product ON LineOrder.ProductID = Product.ProductID INNER JOIN Storefront ON ItemOrder.StoreID = Storefront.StoreID WHERE Customer.UserName = @usnam ORDER BY DateOfOrder";
            using(SqlCommand cmd = new SqlCommand(selectOrHis, connection)){
                SqlParameter param = new SqlParameter("@usnam", _username);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void GetCustomerOrderHistoryCost(string _username){
        List<Order> ordHistory = new List<Order>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string selectOrHis = "SELECT ItemOrder.OrderID, ItemOrder.DateOfOrder, Customer.UserName, Storefront.Name, LineOrder.Quantity*Product.Price AS Total FROM CustomerOrderHistory INNER JOIN ItemOrder ON CustomerOrderHistory.OrderID = ItemOrder.OrderID INNER JOIN Customer ON ItemOrder.CustomerID = Customer.CustomerID INNER JOIN LineOrder ON ItemOrder.LineItemID = LineOrder.LineItemID INNER JOIN Product ON LineOrder.ProductID = Product.ProductID INNER JOIN Storefront ON ItemOrder.StoreID = Storefront.StoreID WHERE Customer.UserName = @usnam ORDER BY Total";
            using(SqlCommand cmd = new SqlCommand(selectOrHis, connection)){
                SqlParameter param = new SqlParameter("@usnam", _username);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void GetStorefrontOrderHistoryDate(string _storename){
        List<Order> ordHistory = new List<Order>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string selectOrHis = "SELECT * ItemOrder WHERE CustomerID = (SELECT Customer.CustomerID FROM Customer WHERE UserName = @usnam) ORDER BY DateOfOrder";
            using(SqlCommand cmd = new SqlCommand(selectOrHis, connection)){
                SqlParameter param = new SqlParameter("@usnam", _storename);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void GetStorefrontOrderHistoryCost(string _storename){
        List<Order> ordHistory = new List<Order>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string selectOrHis = "SELECT * ItemOrder WHERE CustomerID = (SELECT Customer.CustomerID FROM Customer WHERE UserName = @usnam)";
            using(SqlCommand cmd = new SqlCommand(selectOrHis, connection)){
                SqlParameter param = new SqlParameter("@usnam", _storename);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    // public List<Storefront> SearchStorefronts(string searchItem){
    //     string searchStatement = $"SELECT * FROM Storefront WHERE Name LIKE '%{searchItem}%' OR Address LIKE '%{searchItem}%'";
    //     using SqlConnection connection = new SqlConnection(_connectionString);
    //     using SqlCommand cmd = new SqlCommand(searchStatement, connection);
    //     using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //     DataSet StorefrontSets = new DataSet();
    //     adapter.Fill(StorefrontSets, "Storefront");
    //     DataTable storefrontTable = StorefrontSets.Tables["Storefront"];
    //     List<Storefront> searchResults = new List<Storefront>();
    //     foreach(DataRow row in storefrontTable.Row){
    //         Storefront sto = new Storefront(row);
    //         searchResults.Add(sto);
    //     }
    //     return searchResults;
    // }

    // public List<Product> SearchInventories(string searchItem){
    //     string searchTerms = $"SELECT Inventory.InventoryID, Product.Title, Product.Price, Director.DirectorName, ReleaseYear.Year, MPARating.Rating FROM Invenotry INNER JOIN Product ON Inventory.ProductID=Product.ProductID INNER JOIN Director ON Product.DirectorID = Director.DirectorID INNER JOIN ReleaseYear ON Product.YearID = ReleaseYear.YearID INNER JOIN MPARating ON MPARating.RatingID = Product.RatingID WHERE Product.Title LIKE '%{searchItem}%' OR Director.DirectorName LIKE '%{searchItem}%'";
    //     using SqlConnection connection = new SqlConnection(_connectionString);
    //     using SqlCommand cmd = new SqlCommand(searchTerms, connection);
    //     using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //     DataSet InventorySets = new DataSet();
    //     adapter.Fill(InventorySets, "Inventory");
    //     DataTable inventoryTable = InventorySets.Tables["Inventory"];
    //     List<Product> searchResults = new List<Product>();
    //     foreach(DataRow row in inventoryTable.Row){
    //         Product pro = new Product(row);
    //         searchResults.Add(pro);
    //     }
    //     return searchResults;
    // }
}