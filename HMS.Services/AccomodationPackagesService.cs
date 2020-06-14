using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var data = _Context.AccomodationPackages.Include(x=>x.AccomodationType).ToList();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                data = data.Where(x => x.AccomodationType.Name.ToLower().Contains(searchTearm.ToLower())|| x.Name.ToLower().Contains(searchTearm.ToLower())).ToList();
            }

            return data.OrderByDescending(x => x.ID).Skip((pageNo.Value - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<AccomodationPackage> GetAllAccomodationPackage()
        {
            return _Context.AccomodationPackages.ToList();
        }
        public int TotalItemCount(string searchTearm)
        {
            var data = _Context.AccomodationPackages.ToList();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                data = data.Where(x => x.AccomodationType.Name.ToLower().Contains(searchTearm.ToLower())).ToList();
            }
            return data.Count;
        }
        public AccomodationPackage GetAccomodationPackagesById(int id)
        {
            return _Context.AccomodationPackages.Find(id);
        }
        public List<AccomodationPackagePictures> GetAccomodationPackagesPictureById(int id)
        {
            return _Context.AccomodationPackages.Find(id).AccomodationPackagePictures.ToList();
        }
        public List<AccomodationPackage> GetAccomodationPackageByAccomodationTypeId(int id)
        {
            return _Context.AccomodationPackages.Where(x => x.AccomodationTypeID == id).ToList();
        }
        public bool SaveAccomodationPackages(AccomodationPackage model)
        {
            _Context.AccomodationPackages.Add(model);
            return _Context.SaveChanges() > 0;
        }
        public bool UpdateAccomodationPackages(AccomodationPackage model)
        {
            _Context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return _Context.SaveChanges() > 0;
        }
        public bool DeleteAccomodationPackages(AccomodationPackage model)
        {
            _Context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            return _Context.SaveChanges() > 0;
        }

    }
}
