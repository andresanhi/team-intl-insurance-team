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
        public Insurance Insurance { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public Guid idVehicle { get; set; }
        [BindProperty]
        public Guid idCustomer { get; set; }
        public Vehicle Vehicle{ get; set; }
        public Customer Customer { get; set; }
        public VehicleStore VehicleStore{ get; set; }
        public CustomerStore CustomerStore { get; set; }
        public InsuranceStore InsuranceStore { get; set; }
        public InsurancesRules InsurancesRules { get; set; }
        public int Age { get; set; }
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
            idCustomer = Customer.Id;
            idVehicle = Vehicle.Id;
            City = Customer.City;
            Insurance = InsurancesRules.GetPrice(idCustomer, idVehicle);
            Age = DateTime.Today.AddTicks(-Customer.BornDate.Ticks).Year - 1;
        }


        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            InsuranceStore.AddInsurance(Insurance);
            return RedirectToPage("../Customers/View", new { customerid = Insurance.CustomerId });
        }
    }
}