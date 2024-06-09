using System.Data.SqlClient;
using System.Data;

public class Program
{
    public static void Main(string[] args)
    {
        createDB();
        Console.WriteLine("Database Created Successfully!!");
    }

    private static void createDB()
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=;";
        string cmdText = "CREATE DATABASE MYTESTDB";
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        if (sqlconnection.State != ConnectionState.Open)
        {
            try
            {
                sqlconnection.Open();
                Console.WriteLine("Connection Open");
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlconnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Database Created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlconnection.Close();
                Console.WriteLine("Connection Closed");
            }
        }
    }
}