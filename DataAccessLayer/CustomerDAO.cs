using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        public void GenerateSampleDataSet()
        {
            customers.Add(new Customer() { Id = 1, Name = "A", Phone = "123432345675" });
            customers.Add(new Customer() { Id = 2, Name = "B", Phone = "123657435467" });
            customers.Add(new Customer() { Id = 3, Name = "C", Phone = "678765678999" });
            customers.Add(new Customer() { Id = 4, Name = "D", Phone = "564567765789" });
            customers.Add(new Customer() { Id = 5, Name = "E", Phone = "283364789925" });
        }
        public List<Customer> GetCustomers() { 
            return customers;
        }
    }
}
