using ITP.WebApp.Models;
using Microsoft.EntityFrameworkCore;
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
            return Context.Customer.OrderBy(x => x.Name).ToList();
        }
        internal void AddCustomer(Customer customer)
        {
            Context.Customer.Add(customer);
            Context.SaveChanges();
        }

        internal Customer GetCustomerById(Guid id)
        {
            return Context.Customer.FirstOrDefault(x => x.Id == id);
        }
        internal void DeleteCustomer(Guid id)
        {
            Customer customertoDelete = Context.Customer.FirstOrDefault(x => x.Id == id);
            Context.Customer.Remove(customertoDelete);
            Context.SaveChanges();
        }

        internal void EditCustomer(Customer customer)
        {
            Customer currentCustomer = Context.Customer.FirstOrDefault(x => x.Id == customer.Id);
            currentCustomer.DocType= customer.DocType;
            currentCustomer.DocNumber= customer.DocNumber;
            currentCustomer.Name = customer.Name;
            currentCustomer.LastName= customer.LastName;
            currentCustomer.BornDate= customer.BornDate;
            currentCustomer.City= customer.City;
            Context.Customer.Update(currentCustomer);
            Context.SaveChanges();
        }
    }
}
