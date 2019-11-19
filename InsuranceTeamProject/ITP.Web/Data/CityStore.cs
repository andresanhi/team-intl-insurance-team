using ITP.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Data
{
    public class CityStore
    {
        public List<City> Cities { get; set; } = new List<City>();
        public CityStore()
        {
            Cities.Add(new City
            {
                CityName = "Medellín",
                State = "Antioquia",
                Country =  "Colombia"
            });
            Cities.Add(new City
            {
                CityName = "Bogotá",
                State = "Bogotá",
                Country = "Colombia"
            });
            Cities.Add(new City
            {
                CityName = "Barranquilla",
                State = "Altántico",
                Country = "Colombia"
            });
            Cities.Add(new City
            {
                CityName = "Cartagena",
                State = "Bolivar",
                Country = "Colombia"
            });
            Cities.Add(new City
            {
                CityName = "Cali",
                State = "Valle del Cauca",
                Country = "Colombia"
            });
            Cities.Add(new City
            {
                CityName = "Bucaramanga",
                State = "Santander",
                Country = "Colombia"
            });
        }
        internal List<City> GetCities()
        {
            return Cities.OrderBy(x => x.CityName).ToList();
        }
    }
}
