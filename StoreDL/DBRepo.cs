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
        DataSet FSSet = new DataSet();
        using SqlDataAdapter stoAdapter = new SqlDataAdapter(stoSelect, connection);
        using SqlDataAdapter invAdapter = new SqlDataAdapter(invSelect, connection);
        using SqlDataAdapter hisAdapter = new SqlDataAdapter(histSelect);
        stoAdapter.Fill(FSSet, "Storefront");
        invAdapter.Fill(FSSet, "Inventory");
        hisAdapter.Fill(FSSet, "StoreOrderHistory");
        DataTable? StorefrontTable = FSSet.Tables["Storefront"];
        DataTable? InventoryTable = FSSet.Tables["Inventory"];
        DataTable? HistoryTable = FSSet.Tables["StoreOrderHistory"];
        if(StorefrontTable != null && InventoryTable != null){
            foreach(DataRow row in StorefrontTable.Rows){
                Storefront nsto = new Storefront(row);
                nsto.InventoryID = InventoryTable.AsEnumerable().Where(r => (int) r["InventoryID"] == nsto.InvnetoryID).Select(
                    r => 
                        new Inventory{
                            InventoryID = (int) r["InventoryID"],
                            ProductID = (int) r["ProductID"],
                            Quantity = (int) r["Quantity"]
                        }
                ).ToList();
                nsto.SOrderHistoryID = HistoryTable.AsEnumerable().Where(r => (int) r["SOrderHistoryID"] == nsto.SOrderHistoryID).Select(
                    r => 
                         new Order{
                            OrderID = (int) r["OrderID"],
                            DateOfOrder = (Date) r["DateOfOrder"],
                            CustomerID = (int) r["CustomerID"],
                            StoreID = (int) r["StoreID"],
                            Total = (decimal) r["Total"],
                            LineItemID = (int) r["LineItemID"]
                         }
                ).ToList();
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
        DataSet cusSet = new DataSet();
        using SqlDataAdapter custAdapter = new SqlDataAdapter(custCollect, connection);
        using SqlDataAdapter histCollector = new SqlDataAdapter(histCollect, connection);
        custAdapter.Fill(cusSet, "Customer");
        histCollector.Fill(cusSet, "CustomerOrderHistory");
        DataTable? CustomerTable = cusSet.Tables["Customer"];
        DataTable? HistoryTable = cusSet.Tables["CustomerOrderHistory"];
        if(CustomerTable != null && HistoryTable != null){
            foreach(DataRow row in CustomerTable.Rows){
                Customer cus = new Customer(row);
                cus.Orders = HistoryTable.AsEnumerable().Where(r => (int) r["COrderHistoryID"] = cus.Orders).Select(
                    r => 
                          new Order{
                              OrderID = (int) row["OrderID"],
                              DateOfOrder = (Date) row["DateOfOrder"],
                              CustomerID = (int) row["CustomerID"],
                              StoreID = (int) row["StoreID"],
                              Total = (decimal) row["Total"],
                              LineItemID = (int) row["LineItemID"]
                          }
                ).ToList();

                allCustomers.Add(cus);
            }
        }
        return allCustomers;
    }

    public void AddStorefront(string _name, string _address){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string cmdForSql = "INSERT INTO Storefront (Name, Address) VALUES (@nam, @addr)";
            using(SqlCommand cmd = new SqlCommand(cmdForSql, connection)){
                SqlParameter param = new SqlParameter("@nam", _name);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@addr", _address);
                cmd.Parameters.Add(param);
                // param = new SqlParameter("@invid", _inventoryid);
                // cmd.Parameters.Add(param);
                // param = new SqlParameter("@soh", _sorderhistoryid);
                // cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void AddInventory(int idOfItem, int idOfInventory, int amount){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlCmd = "INSERT INTO Inventory (InventoryID, ProductID, Quantity) VALUES (@invID, @proID, @quan)";
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
    public void PlaceAnOrder(int idOfItem, int idOfLineOrder, int numberOfItems){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlCmd = "INSERT INTO LineOrder (LineItemID, ProductID, Quantity) VALUES (@linID, @proID, @quan)";
            string sqlCmd2 = "UPDATE Inventory SET Quantity -= @quan WHERE ProductID = @proID";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection)){
                SqlParameter param = new SqlParameter("@linID", idOfLineOrder);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@proID", idOfItem);
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