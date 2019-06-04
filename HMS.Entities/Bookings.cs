using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class Bookings
    {
        public int Id { get; set; }

        public Accomodation AccomodationId  { get; set; }
        public Accomodation Accomodation { get; set; }

        public DateTime FromDate { get; set; }

        /// <summary>
        /// Number of Stay nights
        /// </summary>
        public int Duration { get; set; }


    }
}
