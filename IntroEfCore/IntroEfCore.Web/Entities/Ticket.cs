using System;
using System.Collections.Generic;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class Ticket
    {
        public Guid Key { get; set; }
        public string Status { get; set; }
        public long FlightId { get; set; }
        public Guid PassengerId { get; set; }
        public decimal? Price { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
