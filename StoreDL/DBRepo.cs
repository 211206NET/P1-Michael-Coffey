namespace DL;

using Microsoft.Data.SqlClinet;

public class DBRepo : IMRepo{ 

    private string _connectionString; 

    public DBRepo(string connectionString){
        _connectionString = connectionString;
        Console.WriteLine(_connectionString);
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
        DataTable? InventoryTable = FSSet.Table["Inventory"];
        if(StorefrontTable != null && InventoryTable != null){
            foreach(DataRow row in StorefrontTable.Rows){
                Storefront nsto = new Storefront();
                nsto.ID = (int) row["StoreID"];
                nsto.Name = row["Name"];
                nsto.Address = row["Address"];
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
        return new List<Customer>();
    }

    public void AddStorefront(Storefront storefrontToAdd){
        DataSet stoSet = new DataSet();
        string selectCmd = "SELECT * FROM Storefront WHERE StoreId = -1";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection)){
                dataAdapter.Fill(stoSet, "Storefront");
                DataTable stoTable = stoSet.Tables["Storefront"];
                DataRow nRow = stoTable.NewRow();
                newRow["Name"] = storefrontToAdd.Name;
                newRow["Address"] = storefrontToAdd.Address ?? "";
                newRow["InventoryID"] = storefrontToAdd.InventoryID;
                newRow["SOrderHistoryID"] = storefrontToAdd.OrderID;
                string insertCmd = $"INSERT INTO Storefront(Name, Address, InventoryID, SOrderHistoryID) VALUES ('{storefrontToAdd.Name}', '{storefrontToAdd.Address}', {storefrontToAdd.InventoryID}, {storefrontToAdd.OrderID})";
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
                dataAdapter.Update(stoTable);
            }
        }
    }

    public void ReplenishStock(int idOfItem, int idOfInventory, int numberToAdd){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string sqlCmd = "INSERT INTO Inventory (InventoryID, ProductID, Quantity) VALUES (@invID, @proID, @quan)";
            using(SqlComand cmd = new SqlCommand(sqlCmd, connection)){
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
            using(SqlComand cmd = new SqlCommand(sqlCmd, connection)){
                SqlParameter param = new SqlParameter("@linID", idOfLineOrder);
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
}