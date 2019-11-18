using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Models
{
    public class Sales
    {
        public Guid Id { get; set; }
        public Guid InsuranceId { get; set; }
        public string DocNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public double Baseprice { get; set; }
        public double IncreaseByAge { get; set; }
        public double IncreaseByCity { get; set; }
        public double IncreaseByCar { get; set; }
        public double Total { get; set; }
    }
}
