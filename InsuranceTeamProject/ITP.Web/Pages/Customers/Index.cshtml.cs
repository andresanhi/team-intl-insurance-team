using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITP.WebApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public List<Customer> Customers{ get; set; }
        public CustomerStore CustomerStore { get; set; }
        public IndexModel(CustomerStore customerStore )
        {
            this.CustomerStore = customerStore;
            Customers = customerStore.GetCustomers();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            CustomerStore.DeleteCustomer(id);
            return RedirectToPage();
        }
        public void OnGet()
        {

        }
    }
}