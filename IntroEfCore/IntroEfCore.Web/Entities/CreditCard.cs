using System;
using System.Collections.Generic;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class CreditCard
    {
        public Guid Key { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public DateTime Expires { get; set; }
        public Guid PassengerId { get; set; }

        public virtual Passenger Passenger { get; set; }
    }
}
