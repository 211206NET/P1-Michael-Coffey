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
        DataSet FSSet = new DataSet();
        using SqlDataAdapter stoAdapter = new SqlDataAdapter(stoSelect, _connectionString);
        using SqlDataAdapter invAdapter = new SqlDataAdapter(invSelect, _connectionString);
        stoAdapter.Fill(FSSet, "Storefront");
        invAdapter.Fill(FSSet, "Inventory");
        DataTable? StorefrontTable = FSSet.Tables["Storefront"];
        DataTable? InventoryTable = FSSet.Tables["Inventory"];
        if(StorefrontTable != null && InventoryTable != null){
            foreach(DataRow row in StorefrontTable.Rows){
                Storefront nsto = new Storefront();
                nsto.ID = (int) row["StoreID"];
                nsto.Name = (string) row["Name"];
                nsto.Address = (string) row["Address"];
                nsto.InventoryID = (int) row["InventoryID"];
                nsto.OrderID = (int) row["SOrderHistoryID"];
                allStorefronts.Add(nsto);
            }
        }
        return allStorefronts;
    }

    public List<Customer> GetAllCustomers(){
        List<Customer> allCustomers = new List<Customer>();
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string quereyTxt = "SELECT * FROM Customer";
            using(SqlCommand cmd = new SqlCommand(quereyTxt, connection)){
                using(SqlDataReader reader = cmd.ExecuteReader()){
                    while(reader.Read()){
                        Console.WriteLine(reader.GetInt32(0));
                    }
                }
            }
            connection.Close();
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

    public void ReplenishStock(int idOfItem, int idOfInventory, int numberToAdd){
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
    public void PlaceAnOrder(int idOfItem, int idOfLineOrder, int numberOfItems){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlCmd = "INSERT INTO LineOrder (LineItemID, ProductID, Quantity) VALUES (@linID, @proID, @quan)";
            using(SqlCommand cmd = new SqlCommand(sqlCmd, connection)){
                SqlParameter param = new SqlParameter("@linID", idOfLineOrder);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@proID", idOfItem);
                cmd.Parameters.Add(param);
                param = new SqlParameter("@quan", numberOfItems);
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    public void AddCustomer(string _username, string _email, string _password){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string cmdSql = "INSERT INTO Customer (UserName, Email, Password) VALUES (@usna, @emai, @paswor)";
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