using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ITP.WebApp.Pages.Vehicles
{
    public class AddModel : PageModel
    {
        public CustomerStore CustomerStore { get; set; }
        public Customer Customer { get; set; }
        public VehicleStore VehicleStore { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        [BindProperty]
        public Vehicle Vehicle { get; set; }
        public int Age { get; set; }
        public int MaxYear { get; set; }
        [BindProperty]
        public Guid CustomerId { get; set; }
        public AddModel(CustomerStore customerStore, VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;
            
        }
        public void OnGet(Guid customerid)
        {
            CustomerId = customerid;
            Customer = CustomerStore.GetCustomerById(CustomerId);
            Age = DateTime.Today.AddTicks(-Customer.BornDate.Ticks).Year - 1;
            MaxYear = DateTime.Today.Year + 1;
            Vehicles = VehicleStore.GetVehiclesByCustomer(CustomerId);
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) //Hace la validacion inversa... si no es valido el modelo
            {
                return Page(); //Permanece en la pagina
            }
           
            VehicleStore.AddVehicle(Vehicle);
            return RedirectToPage("../Customers/View", new { customerid = Vehicle.CustomerId });
        }
    }
}