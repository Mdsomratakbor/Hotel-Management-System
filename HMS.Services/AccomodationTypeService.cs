﻿using HMS.Data;
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

        public List<AccomodationType> GetAllAccomodationType(string searchTearm, int? pageNo, int pageSize = 10)
        {
            var data = _Context.AccomodationTypes.ToList();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                data = data.Where(x => x.Name.ToLower().Contains(searchTearm.ToLower())).ToList();
            }
           
            return data.OrderByDescending(x => x.ID).Skip((pageNo.Value - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<AccomodationType> GetAllAccomodationType()
        {
            return _Context.AccomodationTypes.ToList();
        }
        public int TotalItemCount(string searchTearm)
        {
            var data = _Context.AccomodationTypes.ToList();
            if (string.IsNullOrEmpty(searchTearm) == false)
            {
                data = data.Where(x => x.Name.ToLower().Contains(searchTearm.ToLower())).ToList();
            }
            return data.Count;
        }
        public AccomodationType GetAccomodationById(int id)
        {
            return _Context.AccomodationTypes.Find(id);
        }
        public bool SaveAccomodationType(AccomodationType model)
        {
            _Context.AccomodationTypes.Add(model);
            return _Context.SaveChanges() > 0;
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
