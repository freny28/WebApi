using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1A.Models;

namespace Lab1A.Data
{
    public class DealershipMgr
    {
        private static List<Dealership> _dealerships = new List<Dealership>
        {
            new Dealership { ID = 1, Name = "Arav", Email = "arav1@gmail.com", PhoneNumber = "209-758-1988" },
            new Dealership { ID = 2, Name = "John", Email = "john2@hotmail.com", PhoneNumber = "657-748-7788" },
            new Dealership { ID = 3, Name = "Alex", Email = "alex3@gmail.com", PhoneNumber = "547-788-4444" },
            new Dealership { ID = 4, Name = "Jessica", Email = "jessics4@hotmail.com", PhoneNumber = "209-707-7188" }
        };

        public Dealership Get(int? id)
        {
            return _dealerships.SingleOrDefault(adealer => adealer.ID == id);
        }

        public List<Dealership> Get()
        {
            return _dealerships;
        }

        public void Post(Dealership dealership)
        {
            Dealership d = null;

            if (dealership.ID != 0)
            {
                d = _dealerships.SingleOrDefault(adealer => adealer.ID == dealership.ID);
            }
            else
            {
                dealership.ID = _dealerships.Max(adealer => adealer.ID) + 1;  
            }

            if (d == null)
            {
                _dealerships.Add(dealership);
            }
        }

        public void Delete(int? id)
        {
            var d = _dealerships.SingleOrDefault(adealer => adealer.ID == id);
            if (d != null)
            {
                _dealerships.Remove(d);
            }
        }

        public void Put(int id, Dealership dealership)
        {
            var d = _dealerships.SingleOrDefault(adealer => adealer.ID == id);
            if (d != null)
            {
                d.Name = dealership.Name;
                d.Email = dealership.Email;
                d.PhoneNumber = dealership.PhoneNumber;
            }
        }
    
}
}
