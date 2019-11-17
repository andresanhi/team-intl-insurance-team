using ITP.WebApp.Data;
using ITP.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.BusinessLogic
{
    public class InsurancesRules
    {
        public VehicleStore VehicleStore { get; set; }
        public CustomerStore CustomerStore{ get; set; }
        public InsuranceStore InsuranceStore { get; set; }
        public Insurance Insurance{ get; set; }
        public InsurancesRules(VehicleStore vehicleStore, CustomerStore customerStore, InsuranceStore insuranceStore)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;
            InsuranceStore = insuranceStore;
        }
        public Insurance GetPrice(Guid idCustomer, Guid idVehicle)
        {
            double IncreaseByAge1 = 0.30;
            double IncreaseByAge2 = 0.10;
            double IncreaseByCity = 0.10;
            double IncreaseByCar = 0.05;
            Vehicle Vehicle = VehicleStore.GetVehiclesById(idVehicle);
            Customer Customer = CustomerStore.GetCustomerById(idCustomer);
            Insurance = new Insurance();
            Insurance.CustomerId = idCustomer;
            Insurance.VehicleId = idVehicle;
            Insurance.City = Customer.City;
            int Age = DateTime.Today.AddTicks(-Customer.BornDate.Ticks).Year - 1;
            if (Customer.City == "Medellín")
            {
                Insurance.IncreaseByCity = Insurance.Baseprice * IncreaseByCity;
            }
            if (Vehicle.Year < (DateTime.Today.Year-10))
            {
                Insurance.IncreaseByCar = Insurance.Baseprice * IncreaseByCar;
            }
            if(Age >= 16 && Age < 25)
            {
                Insurance.IncreaseByAge = Insurance.Baseprice * IncreaseByAge1;
            }
            else if (Age >= 25 && Age < 40)
            {
                Insurance.IncreaseByAge = Insurance.Baseprice * IncreaseByAge2;
            }
            Insurance.Total = Insurance.Baseprice + Insurance.IncreaseByAge + Insurance.IncreaseByCar + Insurance.IncreaseByCity;
            return Insurance;
        }
    }
}
