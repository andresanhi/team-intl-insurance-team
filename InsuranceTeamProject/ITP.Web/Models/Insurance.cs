﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Models
{
    public class Insurance
    {
        public Insurance()
        {
            this.Id = Guid.NewGuid();
            this.Baseprice = 1000000;
            this.IncreaseByCity = 0;
            this.IncreaseByCar = 0;
            this.IncreaseByAge = 0;
            this.Total = 0;
        } 
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public Guid VehicleId { get; set; }
        public string City { get; set; }
        public double Baseprice{ get; set; }
        public double IncreaseByAge { get; set; }
        public double IncreaseByCity { get; set; }
        public double IncreaseByCar { get; set; }
        public double Total { get; set; }
    }
}
