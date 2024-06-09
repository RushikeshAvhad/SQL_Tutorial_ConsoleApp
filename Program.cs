using System.Data.SqlClient;
using System.Data;

public class Program
{

    const string conString = "Data Source=localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=MYTESTDB;";


    public static void Main(string[] args)
    {
        // createDB();  //  Create Database
        creteTable();   //  Create Table
        Console.WriteLine("Database Created Successfully!!");
    }

    #region Create Database
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
    #endregion

    private static void creteTable()
    {
        SqlConnection sqlConnection = new SqlConnection(conString);
        string sqlStatement = "CREATE TABLE Customer(ID int primary key identity, name varchar(50), Balance money)";
        try
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            Console.WriteLine("Connection Open");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Table Created Successfully !!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            sqlConnection.Close();
        }
    }

}