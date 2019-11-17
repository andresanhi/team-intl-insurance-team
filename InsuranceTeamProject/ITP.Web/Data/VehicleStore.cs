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

        public Vehicle GetVehiclesById(Guid Id)
        {
            return Context.Vehicle.FirstOrDefault(x => x.Id == Id);
        }

        internal void AddVehicle(Vehicle vehicle)
        {
            Context.Vehicle.Add(vehicle);
            Context.SaveChanges();
        }

        internal void DeleteVehicle(Guid id)
        {
            Vehicle currentVehicle = GetVehiclesById(id);
            Context.Vehicle.Remove(currentVehicle);
            Context.SaveChanges();
        }

        internal List<Vehicle> GetVehicles()
        {
            return Context.Vehicle.ToList();
        }
    }
}
