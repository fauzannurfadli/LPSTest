using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPSTest.Core.Entities
{
    public class Event
    {
        public Guid ID { get; set; }
        public string? Nama { get; set; }
        public string? Desc { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
