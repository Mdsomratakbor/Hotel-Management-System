using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class SharedService
    {
        private HMSContext _Context;
        public SharedService()
        {
            _Context = new HMSContext();
        }
        public int SavePicture(Picture picture)
        {
            _Context.Pictures.Add(picture);
            _Context.SaveChanges();
             return picture.ID;        
        }
        public List<Picture> GetPicturesByIDs(List<int> pictureIDs)
        {
            return pictureIDs.Select(x => _Context.Pictures.Find(x)).ToList();
        }
    }
}
