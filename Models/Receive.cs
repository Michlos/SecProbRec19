using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecProbRec19.Models
{
    public class Receive
    {
        public int Id { get; set; }
        public int MailId { get; set; }
        public DateTime RecDate { get; set; } = DateTime.Now;
        public string IpAddress { get; set; }

    }
}
