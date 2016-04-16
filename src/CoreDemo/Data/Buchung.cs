using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class Buchung
    {
        public int BuchungId { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }
    }
}
