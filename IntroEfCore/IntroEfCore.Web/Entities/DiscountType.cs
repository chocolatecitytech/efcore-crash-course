using System;
using System.Collections.Generic;

#nullable disable

namespace IntroEfCore.Web.Entities
{
    public partial class DiscountType
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
    }
}
