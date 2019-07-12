using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationTypesServices
    {
        public IEnumerable<AccomodationType> GetAllAccomodationTypes()
        {
            var context = new HMSContext();

            return context.AccomodationTypes.AsEnumerable();
        }
        public AccomodationType GetAccomodationTypesById(int id)
        {
            var context = new HMSContext();

            return context.AccomodationTypes.FirstOrDefault(x=> x.Id==id);
        }

        public bool SaveChangesAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();
            context.AccomodationTypes.Add(accomodationType);


            return context.SaveChanges() > 0;
        }
        public bool UpdateChangesAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Modified;


            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Deleted;


            return context.SaveChanges() > 0;
        }
    }
    
    
}
