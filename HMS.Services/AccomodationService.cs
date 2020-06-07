using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationService
    {
 
            private HMSContext _Context;
            public AccomodationService()
            {
                _Context = new HMSContext();
            }
            public List<Accomodation> GetAllAccomodation(string searchTearm, int AccomodationPackageId, int? pageNo, int pageSize = 10)
            {
                var data = _Context.Accomodations.Include(x => x.AccomodationPackage).ToList();
                if (string.IsNullOrEmpty(searchTearm) == false)
                {
                    data = data.Where(x => x.AccomodationPackage.Name.ToLower().Contains(searchTearm.ToLower()) || x.Name.ToLower().Contains(searchTearm.ToLower())).ToList();
                }

                return data.OrderByDescending(x => x.ID).Skip((pageNo.Value - 1) * pageSize).Take(pageSize).ToList();
            }
            public List<Accomodation> GetAllAccomodation()
            {
                return _Context.Accomodations.ToList();
            }
            public int TotalItemCount(string searchTearm)
            {
                var data = _Context.Accomodations.ToList();
                if (string.IsNullOrEmpty(searchTearm) == false)
                {
                    data = data.Where(x => x.AccomodationPackage.Name.ToLower().Contains(searchTearm.ToLower())).ToList();
                }
                return data.Count;
            }
            public Accomodation GetAccomodationById(int id)
            {
                return _Context.Accomodations.Find(id);
            }
            public bool SaveAccomodation(Accomodation model)
            {
                _Context.Accomodations.Add(model);
                return _Context.SaveChanges() > 0;
            }
            public bool UpdateAccomodation(Accomodation model)
            {
                _Context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return _Context.SaveChanges() > 0;
            }
            public bool DeleteAccomodation(Accomodation model)
            {
                _Context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                return _Context.SaveChanges() > 0;
            }

        }
    }



