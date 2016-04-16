using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class Hotel
    {
        public int HotelId { get; set; }

        public string Bezeichnung { get; set; }

        public int RegionId { get; set; }

        public int Sterne { get; set; }

        public List<Buchung> Buchungen { get; set; } = new List<Buchung>();
    }
}
