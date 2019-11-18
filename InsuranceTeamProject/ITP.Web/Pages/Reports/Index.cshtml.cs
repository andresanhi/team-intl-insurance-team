using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITP.WebApp.Pages.Reports
{
    public class IndexModel : PageModel
    {
        public VehicleStore VehicleStore{ get; set; }
        public CustomerStore CustomerStore { get; set; }
        public InsuranceStore InsuranceStore { get; set; }
        public List<Vehicle> Vehicles{ get; set; }
        public List<Customer> Customers { get; set; }
        public List<Insurance> Insurances { get; set; }
        [BindProperty]
        public List<Sales> Sales { get; set; }
        public IndexModel(VehicleStore vehicleStore, CustomerStore customerStore, InsuranceStore insuranceStore)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;
            InsuranceStore = insuranceStore;
            Vehicles = VehicleStore.GetVehicles();
            Customers = CustomerStore.GetCustomers();
            Insurances = InsuranceStore.GetInsurances();
        }
        public void OnGet()
        {
            var d = from i in Insurances
                    join v in Vehicles
                    on i.VehicleId equals v.Id
                    join c in Customers
                    on i.CustomerId equals c.Id
                     select new Sales
                     {
                         Id = Guid.NewGuid(),
                         InsuranceId = i.Id,
                         DocNumber = c.DocNumber,
                         Name = c.Name,
                         LastName = c.LastName,
                         Brand = v.Brand,
                         Year = v.Year,
                         City = i.City,
                         Baseprice = i.Baseprice,
                         IncreaseByAge = i.IncreaseByAge,
                         IncreaseByCity = i.IncreaseByCity,
                         IncreaseByCar = i.IncreaseByCar,
                         Total = i.Total
                      };
            Sales = d.OrderBy(x => x.Name)
                .ToList();
        }

        public IActionResult OnPostDelete(Guid id)
        {
            InsuranceStore.DeteleInsurance(id);
            return RedirectToPage();
        }
    }
}

/*                
                
                from c in Customers
                     join v in Vehicles
                     on c.Id equals v.CustomerId
                     join i in Insurances
                     on v.CustomerId equals i.CustomerId*/
