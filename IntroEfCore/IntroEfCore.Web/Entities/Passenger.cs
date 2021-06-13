using System;
using System.Collections.Generic;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class Passenger
    {
        public Passenger()
        {
            CreditCards = new HashSet<CreditCard>();
            Tickets = new HashSet<Ticket>();
        }

        public Guid Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
