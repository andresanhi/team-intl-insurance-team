using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Data
{
    public class DniStore
    {
        public List<DniType> DniTypes { get; set; } = new List<DniType>();
        public DniStore()
        {
            DniTypes.Add(new DniType
            {
                Type = "Cédula de Ciudadanía",
            });
            DniTypes.Add(new DniType
            {
                Type = "Pasaporte",
            });
            DniTypes.Add(new DniType
            {
                Type = "Cédula de Extranjería",
            });

        }

        internal List<DniType> GetDniTypes()
        {
            return DniTypes;
        }
    }
}
