using System;
using System.Collections.Generic;

namespace RentioAPI.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Message = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
