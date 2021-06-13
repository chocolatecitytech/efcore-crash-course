using System;
using System.Collections.Generic;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class FlightDetail
    {
        public Guid Key { get; set; }
        public decimal Price { get; set; }
        public string ChiefPilot { get; set; }
        public string SecondaryPilot { get; set; }
        public int? AvailableSeats { get; set; }
        public long FlightId { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
