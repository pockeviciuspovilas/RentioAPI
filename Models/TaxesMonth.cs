using System;
using System.Collections.Generic;

namespace RentioAPI.Models
{
    public partial class TaxesMonth
    {
        public TaxesMonth()
        {
            Tax = new HashSet<Tax>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Tax> Tax { get; set; }
    }
}
