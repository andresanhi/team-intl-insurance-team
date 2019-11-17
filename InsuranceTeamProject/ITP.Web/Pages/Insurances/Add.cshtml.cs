using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.BusinessLogic;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITP.WebApp.Pages.Insurances
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Insurance Insurance { get; set; } = new Insurance();
        public Vehicle Vehicle{ get; set; }
        public Customer Customer { get; set; }
        public VehicleStore VehicleStore{ get; set; }
        public CustomerStore CustomerStore { get; set; }
        public InsuranceStore InsuranceStore { get; set; }
        public InsurancesRules InsurancesRules { get; set; }
        public AddModel(VehicleStore vehicleStore, CustomerStore customerStore, InsuranceStore insuranceStore, 
                        InsurancesRules insurancesRules)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;
            InsuranceStore = insuranceStore;
            InsurancesRules = insurancesRules;
        }
        public void OnGet(Guid vehicleid)
        {
            Vehicle = VehicleStore.GetVehiclesById(vehicleid);
            Customer = CustomerStore.GetCustomerById(Vehicle.CustomerId);
            Insurance.IdCustomer = Customer.Id;
            Insurance.IdVehicle = Vehicle.Id;
            Insurance.City = Customer.City;
            Insurance = InsurancesRules.GetPrice(Insurance);
        }


        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Insurance.IdCustomer = Customer.Id;
            Insurance.IdVehicle = Vehicle.Id;
            Insurance.City = Customer.City;
            //InsuranceStore.AddInsurance(Insurance);
            return RedirectToPage("../Customers/Index");
        }
    }
}