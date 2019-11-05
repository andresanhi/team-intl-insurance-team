using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITP.WebApp.Pages.Vehicles
{
    public class AddModel : PageModel
    {
        public CustomerStore CustomerStore { get; set; }
        public Customer Customer { get; set; }
        public VehicleStore VehicleStore { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public int Age { get; set; }
        public int MaxYear { get; set; }
        public AddModel(CustomerStore customerStore, VehicleStore vehicleStore)
        {
            this.VehicleStore = vehicleStore;
            this.CustomerStore = customerStore;

        }
        public void OnGet(Guid customerid)
        {
            Customer = CustomerStore.GetCustomerById(customerid);
            Age = DateTime.Today.AddTicks(-Customer.BornDate.Ticks).Year - 1;
            MaxYear = DateTime.Today.Year+1;
            //Vehicles = VehicleStore.GetVehiclesByCustomer(customerid);
        }
    }
}