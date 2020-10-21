using System;
using System.Collections.Generic;

namespace RentioAPI.Models
{
    public partial class TypeEnum
    {
        public TypeEnum()
        {
            Tax = new HashSet<Tax>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tax> Tax { get; set; }
    }
}
