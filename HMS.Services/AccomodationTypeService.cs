using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationTypeService
    {
        private HMSContext _Context;
        public AccomodationTypeService()
        {
            _Context = new HMSContext();
        }

        public List<AccomodationType> GetAllAccomodationType(string searchTearm)
        {
          var data = _Context.AccomodationTypes.ToList();
            if (string.IsNullOrEmpty(searchTearm)==false)
            {
                data = data.Where(x => x.Name.ToLower().Contains(searchTearm.ToLower())).ToList();
            }
            return data;
        }
        public AccomodationType GetAccomodationById(int id)
        {
            return _Context.AccomodationTypes.Find(id);
        }
        public bool SaveAccomodationType(AccomodationType model)
        {
            _Context.AccomodationTypes.Add(model);
            return _Context.SaveChanges()>0;
        }
        public bool UpdateAccomodationType(AccomodationType model)
        {
            _Context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            return _Context.SaveChanges() > 0;
        }
        public bool DeleteAccomodationType(AccomodationType model)
        {
            _Context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            return _Context.SaveChanges() > 0;
        }
    }
}
