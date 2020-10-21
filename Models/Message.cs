using System;
using System.Collections.Generic;

namespace RentioAPI.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
