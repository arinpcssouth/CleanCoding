using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Authentication
{
    public class ActiveSession
    {
        public Guid Token { get; set; }
        public DateTime? DateTimeInitiated { get; set; }
        public DateTime? DateLastUsed { get; set; }


    }
}
