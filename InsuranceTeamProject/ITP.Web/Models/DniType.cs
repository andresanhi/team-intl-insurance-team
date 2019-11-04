using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Data
{
    public class DniType
    {
        public DniType()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
}
