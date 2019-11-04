using System;
using System.Collections.Generic;
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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocType { get; set; }
        public int DocNumber { get; set; }
        public int BornDate { get; set; }
        public DateTime City { get; set; }
    }
}
