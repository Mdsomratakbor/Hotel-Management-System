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

        public List<AccomodationType> GetAllAccomodationType()
        {
            return _Context.AccomodationTypes.ToList();
        }
        public bool SaveAccomodationType(AccomodationType model)
        {
            _Context.AccomodationTypes.Add(model);
            return _Context.SaveChanges()>0;
        }
    }
}
