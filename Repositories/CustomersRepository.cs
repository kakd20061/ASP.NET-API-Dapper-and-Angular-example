using CustomersApi.Models;
using Dapper;
using System.Data;
using System.Data.Common;

namespace CustomersApi.Repositories
{
    public interface ICustomersRepository
    {
        public void Add(CustomerDto customer);
        public void Delete(int id);
        public void Update(int id, CustomerDto customer);
    }
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext _context;
        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }

        public void Add(CustomerDto customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var db = CustomersDatabase.Init((DbConnection)connection, commandTimeout: 2);
                var customers = db.Customers.Insert(customer);
            }
        }

        public void Delete(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var db = CustomersDatabase.Init((DbConnection)connection, commandTimeout: 2);
                var customers = db.Customers.Delete(id);
            }
        }

        public void Update(int id, CustomerDto customer)
        {
            using (var connection = _context.CreateConnection())
            {
                var db = CustomersDatabase.Init((DbConnection)connection, commandTimeout: 2);
                var customers = db.Customers.Update(id, customer);
            }
        }
    }
}
