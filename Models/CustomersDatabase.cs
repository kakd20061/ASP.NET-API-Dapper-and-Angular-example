using Dapper;

namespace CustomersApi.Models
{
    public class CustomersDatabase : Database<CustomersDatabase>
    {
        public Table<Customer> Customers { get; set; }
    }
}
