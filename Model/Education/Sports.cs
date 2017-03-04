using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Education
{
    public class Sports:IMajor
    {

        public string Name { get; set; }

        public int Weight { get { return 15; } }

        public string TypeOfSport { get; set; }

    }
}
