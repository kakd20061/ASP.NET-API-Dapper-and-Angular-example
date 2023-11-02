using CustomersApi.Models;
using Dapper;
using System.Data;
using System.Data.Common;

namespace CustomersApi.Repositories
{
    public interface ICustomersProvider
    {
        public IEnumerable<Customer> Get();
        public Customer GetById( int id);
    }
    public class CustomersProvider : ICustomersProvider
    {
        private readonly DapperContext _context;
        public CustomersProvider(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> Get()
        {
            using (var connection = _context.CreateConnection())
            {
                var db = CustomersDatabase.Init((DbConnection)connection, commandTimeout: 2);
                var customers = db.Customers.All();
                return customers;
            }
        }

        public Customer GetById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var db = CustomersDatabase.Init((DbConnection)connection, commandTimeout: 2);
                var customers = db.Customers.Get(id);
                return customers;
            }
        }
    }
}
