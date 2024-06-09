using System.Data.SqlClient;
using System.Data;

namespace SQL_Tutorial_ConsoleApp
{
    public static class Database
    {
        public static void createDB()
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

        public static void dropDB()
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
    }
}
