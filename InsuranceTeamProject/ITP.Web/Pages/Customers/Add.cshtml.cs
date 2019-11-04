using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Data;
using ITP.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITP.WebApp.Pages.Customers
{
    public class AddModel : PageModel
    {
        public CustomerStore CustomerStore { get; set; }
        public DniStore DniStore { get; set; }
        public CityStore CityStore { get; set; }
        public List<DniType> DocTypes { get; set; }
        public List<City> Cities { get; set; }
        public AddModel(CustomerStore customerStore, DniStore dniStore, CityStore cityStore)
        {
            this.CustomerStore = customerStore;
            this.DniStore = dniStore;
            this.CityStore = cityStore;
            DocTypes = DniStore.GetDniTypes();
            Cities = CityStore.GetCities();
        }
        [BindProperty]
        public Customer Customer{ get; set; }
        public IActionResult OnPostAsync()
        {
            //Add Customer
            if (!ModelState.IsValid) //Hace la validacion inversa... si no es valido el modelo
            {
                return Page(); //Permanece en la pagina
            }
            CustomerStore.AddCustomer(Customer);
            return RedirectToPage("./Index");
        }
        public void OnGet()
        {

        }
    }
}