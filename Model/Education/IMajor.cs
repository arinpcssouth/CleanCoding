using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.Education
{

    public interface IMajor
    {
        string Name { get; set; }
        int Weight { get;  }

    }
}
