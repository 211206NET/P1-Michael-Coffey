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

    }

    void ReplenishStock(int indexOfItem, int inexOfInventory, int numberToAdd){

    }
    void PlaceAnOrder(int indexOfItem, int indexOfInvnetory, int numberOfItems){

    }
}