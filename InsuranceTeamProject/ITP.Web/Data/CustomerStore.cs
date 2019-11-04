using ITP.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Data
{
    public class CustomerStore
    {
        public ITContext Context { get; set; }
        public CustomerStore(ITContext context)
        {
            this.Context = context;
        }

        public List<Customer> GetCustomers()
        {
            return Context.Customer.ToList();
        }

        internal void AddCustomer(Customer customer)
        {
            Context.Customer.Add(customer);
            Context.SaveChanges();
        }
    }
}
