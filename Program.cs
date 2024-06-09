using System.Data.SqlClient;
using System.Data;

public class Program
{

    const string conString = "Data Source=localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=MYTESTDB;";


    public static void Main(string[] args)
    {
        // createDB();          //  Create Database
        // creteTable();        //  Create Table
        // AddCustomer();       //  Add Customer
        // GetCustomer();       //  Get table record
        // UpdateCustomer();    //  Update Table
        // DeleteCustomer();    //  Delete Record
        dropDB();            //  Drop Database
        Console.ReadLine();
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

    #region Create Table
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
    #endregion

    #region Add Data in Table
    public static void AddCustomer()
    {
        string sqlStatement = "INSERT INTO Customer(NAME,BALANCE) values ('ABC', 999)";
        SqlConnection sqlConnection = new SqlConnection(conString);
        try
        {
            sqlConnection.Open();
            Console.WriteLine("Connection Open");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Customer Added Into Table.");
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

    #endregion

    #region Get Record from table
    public static void GetCustomer()
    {
        string sqlStatement = "SELECT * FROM CUSTOMER";
        SqlConnection sqlConnection = new SqlConnection(conString);

        try
        {
            sqlConnection.Open();
            Console.WriteLine("Connection Open");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            Console.WriteLine($"| {"ID",-5} | {"NAME",-20} | {"BALANCE",-10} |");
            Console.WriteLine(new string('-', 45));

            while (sqlDataReader.Read())
            {
                Console.WriteLine($"| {sqlDataReader.GetInt32(0),-5} | {sqlDataReader.GetString(1),-20} | {sqlDataReader.GetDecimal(2),-10} |");
                Console.WriteLine(new string('-', 45));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            sqlConnection.Close();
            Console.WriteLine("Connection Close");
        }
    }

    #endregion

    #region Update Table
    public static void UpdateCustomer()
    {
        string sqlStatement = "UPDATE CUSTOMER SET NAME='PQRS' WHERE ID=1";
        SqlConnection sqlConnection = new SqlConnection(conString);

        try
        {
            sqlConnection.Open();
            Console.WriteLine("Connection Open");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Customer Updated");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            sqlConnection.Close();
            Console.WriteLine("Connection Close.");
        }
    }

    #endregion

    #region Delete Customer
    public static void DeleteCustomer()
    {
        string sqlStatement = "DELETE FROM CUSTOMER WHERE ID = 1";
        SqlConnection sqlConnection = new SqlConnection(conString);

        try
        {
            sqlConnection.Open();
            Console.WriteLine("Connection Open");
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Customer Deleted.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            sqlConnection.Close();
            Console.WriteLine("Connection Closed");
        }
    }

    #endregion

    #region Drop Database
    private static void dropDB()
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=master;";
        string cmdText = @"
            ALTER DATABASE MYTESTDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            DROP DATABASE MYTESTDB;";
        SqlConnection sqlconnection = new SqlConnection(connectionString);

        if (sqlconnection.State != ConnectionState.Open)
        {
            try
            {
                sqlconnection.Open();
                Console.WriteLine("Connection Open");
                SqlCommand sqlCommand = new SqlCommand(cmdText, sqlconnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Database Droped");
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
}