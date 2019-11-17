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
    public class ViewModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        public CustomerStore CustomerStore { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        [BindProperty]
        public Vehicle Vehicle { get; set; }
        [BindProperty]
        public Guid CustomerId { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        public int Age { get; set; }
        public int MaxYear { get; set; }
        public ViewModel(VehicleStore vehicleStore, CustomerStore customerStore)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;
        }
        public void OnGet(Guid customerid)
        {
            CustomerId = customerid;
            Vehicles = VehicleStore.GetVehiclesByCustomer(customerid);
            Customer = CustomerStore.GetCustomerById(customerid);
            Age = DateTime.Today.AddTicks(-Customer.BornDate.Ticks).Year - 1;
            MaxYear = DateTime.Today.Year + 1;
        }
        public IActionResult Delete(Guid id)
        {
            Vehicle = VehicleStore.GetVehiclesById(id);
            //VehicleStore.DeleteVehicle(id);
            CustomerId = Vehicle.CustomerId;
            Vehicles = VehicleStore.GetVehiclesByCustomer(CustomerId);
            return RedirectToPage();
        }
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid) //Hace la validacion inversa... si no es valido el modelo
            {
                return Page(); //Permanece en la pagina
            }

            VehicleStore.AddVehicle(Vehicle);
            return Page();
        }
    }
}