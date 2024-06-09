using System.Data;
using System.Data.SqlClient;

namespace SQL_Tutorial_ConsoleApp
{
    public static class Customer
    {
        public const string conString = "Data Source=localhost\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=MYTESTDB;";

        public static void creteTable()
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
            string sqlStatement = "CREATE TABLE Customer(ID int primary key identity, name varchar(50), Balance money)";
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
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

        public static void dropTable()
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
            string sqlStatement = "DROP TABLE Customer;";
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Table Deleted Successfully !!");
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

        public static void GetAllCustomer()
        {
            string sqlStatement = "SELECT * FROM CUSTOMER";
            SqlConnection sqlConnection = new SqlConnection(conString);

            try
            {
                sqlConnection.Open();
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
            }
        }

        public static void GetSingleCustomer()
        {
            Console.WriteLine("\nUpdate Customer");
            Console.Write("Enter Customer ID : ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            string sqlStatement = "SELECT * FROM CUSTOMER WHERE ID = " + customerId + "";
            SqlConnection sqlConnection = new SqlConnection(conString);

            try
            {
                sqlConnection.Open();
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
            }
        }

        public static void AddCustomer()
        {
            Console.WriteLine("\nCreate Customer");
            Console.Write("Enter Customer Name : ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Customer Balance : ");
            int customerBalance = Convert.ToInt32(Console.ReadLine());

            string sqlStatement = "INSERT INTO Customer(NAME,BALANCE) values ('" + customerName + "', " + customerBalance + ")";
            SqlConnection sqlConnection = new SqlConnection(conString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("New Customer Added Successfully !!");
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

        public static void UpdateCustomer()
        {
            Console.WriteLine("\nUpdate Customer");
            Console.Write("Enter Customer ID to Update Customer : ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer Name : ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Customer Balance : ");
            int customerBalance = Convert.ToInt32(Console.ReadLine());

            string sqlStatement = "UPDATE CUSTOMER SET NAME='" + customerName + "', BALANCE = '" + customerBalance + "' WHERE ID= " + customerId + "";
            SqlConnection sqlConnection = new SqlConnection(conString);

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Customer Record Updated Successfully !!");
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

        public static void DeleteCustomer()
        {
            Console.WriteLine("\nDelete Customer");
            Console.Write("Enter Customer ID to Delete Customer Record : ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            string sqlStatement = "DELETE FROM CUSTOMER WHERE ID = " + customerId  + "";
            SqlConnection sqlConnection = new SqlConnection(conString);

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("Customer Record Deleted Successfully !!");
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
}
