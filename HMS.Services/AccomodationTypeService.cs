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
        public AccomodationTypeService(HMSContext _HMSContext)
        {
            this._Context = _HMSContext;
        }

        public List<AccomodationType> GetAllAccomodationType()
        {
            return _Context.AccomodationTypes.ToList();
        }
    }
}
