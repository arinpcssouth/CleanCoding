using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Education
{
    public class Arts : IMajor
    {
        public string Name { get; set; }

        public int Weight { get { return 20; } }

        public string ArtCategory { get; set; }   

    }
}
