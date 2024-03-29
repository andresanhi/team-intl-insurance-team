﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITP.WebApp.Pages.Customers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }
        public CustomerStore CustomerStore { get; set; }
        public DniStore DniStore { get; set; }
        public CityStore CityStore { get; set; }
        public List<DniType> DocTypes { get; set; }
        public List<City> Cities { get; set; }
        [BindProperty]
        public string BornDate { get; set; }
        public EditModel(CustomerStore customerStore, DniStore dniStore, CityStore cityStore)
        {
            this.CustomerStore = customerStore;
            this.DniStore = dniStore;
            this.CityStore = cityStore;
            Cities = CityStore.GetCities();
            DocTypes = DniStore.GetDniTypes();
        }
        public void OnGet(Guid id)
        {
            Customer = CustomerStore.GetCustomerById(id);
            BornDate = Customer.BornDate.ToString("dd/MM/yyyy");
        }

        public IActionResult OnPostAsync()
        {
            //Edit
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Customer.BornDate = Convert.ToDateTime(BornDate);
            CustomerStore.EditCustomer(Customer);
            return RedirectToPage("./Index");
        }
    }
}