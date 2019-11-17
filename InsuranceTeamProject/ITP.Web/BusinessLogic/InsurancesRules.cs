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
        public InsurancesRules(VehicleStore vehicleStore, CustomerStore customerStore, InsuranceStore insuranceStore)
        {
            VehicleStore = vehicleStore;
            CustomerStore = customerStore;
            InsuranceStore = insuranceStore;
        }
        public Insurance CalculatePrice(Insurance insurance)
        {
            double IncreaseByAge1 = 0.30;
            double IncreaseByAge2 = 0.10;
            double IncreaseByCity = 0.10;
            double IncreaseByCar = 0.05;
            Vehicle Vehicle = VehicleStore.GetVehiclesById(insurance.IdVehicle);
            Customer Customer = CustomerStore.GetCustomerById(insurance.IdCustomer);
            int Age = DateTime.Today.AddTicks(-Customer.BornDate.Ticks).Year - 1;
            if (insurance.City == "Medellín")
            {
                insurance.IncreaseByCity = insurance.Baseprice * IncreaseByCity;
            }
            if (Vehicle.Year < (DateTime.Today.Year-10))
            {
                insurance.IncreaseByCar = insurance.Baseprice * IncreaseByCar;
            }
            if(Age >= 16 && Age < 25)
            {
                insurance.IncreaseByAge = insurance.Baseprice * IncreaseByAge1;
            }
            else if (Age >= 25 && Age < 40)
            {
                insurance.IncreaseByAge = insurance.Baseprice * IncreaseByAge2;
            }
            insurance.Total = insurance.Baseprice + insurance.IncreaseByAge + insurance.IncreaseByCar + insurance.IncreaseByCity;
            return insurance;
        }
    }
}
