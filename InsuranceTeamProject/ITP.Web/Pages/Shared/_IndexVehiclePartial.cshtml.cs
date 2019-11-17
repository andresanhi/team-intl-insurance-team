using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITP.WebApp.Pages.Shared
{
    public class _IndexVehiclePartialModel : PageModel
    {
        public VehicleStore VehicleStore { get; set; }
        public _IndexVehiclePartialModel(VehicleStore vehicleStore)
        {
            VehicleStore = vehicleStore;
        }
        public void OnPostDelete()
        {
            RedirectToPage("../Customers/Index");
            
        }
            //VehicleStore.DeleteVehicle(id);
            //return RedirectToPage();
        public void OnGet()
        {

        }
    }
}