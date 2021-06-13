using System;
using System.Collections.Generic;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class Flight
    {
        public Flight()
        {
            FlightDetails = new HashSet<FlightDetail>();
            Tickets = new HashSet<Ticket>();
        }

        public long Id { get; set; }
        public string FlightName { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int TotalSeat { get; set; }

        public virtual ICollection<FlightDetail> FlightDetails { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
