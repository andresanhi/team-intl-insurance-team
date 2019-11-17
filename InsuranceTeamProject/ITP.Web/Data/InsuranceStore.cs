using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITP.WebApp.Models;

namespace ITP.WebApp.Data
{
    public class InsuranceStore
    {
        public ITContext Context { get; set; }
        public InsuranceStore(ITContext context)
        {
            this.Context = context;
        }

        internal void AddInsurance(Insurance insurance)
        {
            Context.Insurance.Add(insurance);
            Context.SaveChanges();
        }
    }
}
