using System;
using System.Collections.Generic;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class Discount
    {
        public Guid Key { get; set; }
        public Guid DiscountTypeId { get; set; }
        public int? DiscountAmount { get; set; }
    }
}
