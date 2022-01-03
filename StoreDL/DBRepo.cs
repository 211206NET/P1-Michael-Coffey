namespace DL;

using Microsoft.Data.SqlClinet;

public class DBRepo : IMRepo{ 

    private string _connectionString; 

    public DBRepo(string connectionString){
        _connectionString = connectionString;
        Console.WriteLine(_connectionString);
    }
    List<Storefront> GetAllStorefronts(){
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Open();
            string queryTxt = "SELECT * FROM Storefront";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection)){
                using(SqlDataReader reader = cmd.ExecuteReader()){
                    while(reader.Read()){
                        Console.WriteLine(reader.GetInt32(0));
                    }
                }
            }
            connection.Close();
        }  
        return new List<Storefront>();
    }

    List<Customer> GetAllCustomers(){
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

    void AddStorefront(Storefront storefrontToAdd){
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

    void ReplenishStock(int idOfItem, int idOfInventory, int numberToAdd){
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
    void PlaceAnOrder(int idOfItem, int idOfLineOrder, int numberOfItems){
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