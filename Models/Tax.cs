using System;
using System.Collections.Generic;

namespace RentioAPI.Models
{
    public partial class Tax
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public double Cost { get; set; }
        public double? Counter { get; set; }
        public string UserId { get; set; }
        public string ImageName { get; set; }
        public bool IsPaid { get; set; }
        public int TaxesMonthId { get; set; }

        public virtual TaxesMonth TaxesMonth { get; set; }
        public virtual TypeEnum Type { get; set; }
    }
}
