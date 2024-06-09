using SQL_Tutorial_ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        //Database.createDB();
        //DatabaseCRUD.creteTable();
        //DatabaseCRUD.dropTable();
        //Database.dropDB();


        Console.WriteLine("Welcome to the SQL Tutorial Console Application");
        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Show All Customers");
            Console.WriteLine("2. Show Single Customer");
            Console.WriteLine("3. Add New Customer");
            Console.WriteLine("4. Update Customer");
            Console.WriteLine("5. Delete Customer");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a valid option.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Customer.GetAllCustomer();
                    break;
                case 2:
                    Customer.GetSingleCustomer();
                    break;
                case 3:
                    Customer.AddCustomer();
                    break;
                case 4:
                    Customer.UpdateCustomer();
                    break;
                case 5:
                    Customer.DeleteCustomer();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }   
}