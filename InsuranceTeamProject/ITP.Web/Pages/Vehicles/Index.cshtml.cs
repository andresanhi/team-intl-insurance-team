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
    public class IndexModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        public Guid CustomerId { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public IndexModel(VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;
            Vehicles = VehicleStore.GetVehicles();
        }

        public void OnPostDelete(Guid id)
        {
            Vehicle cVehicle = VehicleStore.GetVehiclesById(id);
            CustomerId = cVehicle.CustomerId;
            VehicleStore.DeleteVehicle(id);
        }
        public void OnGet(Guid customerId)
        {
            Vehicles = VehicleStore.GetVehiclesByCustomer(customerId);
        }
    }
}