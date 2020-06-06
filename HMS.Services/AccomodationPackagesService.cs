using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public  class AccomodationPackagesService
    {
        private HMSContext _Context;
        public AccomodationPackagesService()
        {
            _Context = new HMSContext();
        }
        public List<AccomodationPackage> GetAllAccomodationPackage(string searchTearm, int? pageNo, int pageSize = 10)
        {
            var data = _Context.AccomodationPackages.ToList();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                data = data.Where(x => x.NoOfRoom.ToLower().Contains(searchTearm.ToLower())).ToList();
            }

            return data.OrderByDescending(x => x.ID).Skip((pageNo.Value - 1) * pageSize).Take(pageSize).ToList();
        }
        public int TotalItemCount(string searchTearm)
        {
            var data = _Context.AccomodationPackages.ToList();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                data = data.Where(x => x.NoOfRoom.ToLower().Contains(searchTearm.ToLower())).ToList();
            }
            return data.Count;
        }
        public AccomodationPackage GetAccomodationById(int id)
        {
            return _Context.AccomodationPackages.Find(id);
        }
        public bool SaveAccomodationType(AccomodationPackage model)
        {
            _Context.AccomodationPackages.Add(model);
            return _Context.SaveChanges() > 0;
        }
        public bool UpdateAccomodationType(AccomodationPackage model)
        {
            _Context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return _Context.SaveChanges() > 0;
        }
        public bool DeleteAccomodationType(AccomodationPackage model)
        {
            _Context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            return _Context.SaveChanges() > 0;
        }

    }
}
