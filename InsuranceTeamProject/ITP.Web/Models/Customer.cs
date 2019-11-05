using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Id = Guid.NewGuid();
        }
        [Required]
        public Guid Id { get; set; }
        public string DocType { get; set; }
        [Required]
        public int DocNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, Column(TypeName ="Date")]
        public DateTime BornDate { get; set; }
        [Required]
        public string City { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
