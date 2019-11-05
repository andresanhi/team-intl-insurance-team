using ITP.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Data
{
    public class VehicleStore
    {
        public ITContext Context { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public VehicleStore(ITContext context)
        {
            this.Context = context;
        }

        public List<Vehicle> GetVehiclesByCustomer(Guid idCustomer)
        {
            return Context.Vehicle.Where(x => x.CustomerId == idCustomer).ToList();
        }
    }
}
