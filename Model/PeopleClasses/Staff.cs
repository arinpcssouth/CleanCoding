using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PeopleClasses
{
    public abstract class Staff : Person
    {
        public override PersonRole Role { get; }
         
        public string GovernmentEmployeeId { get; set; }

    }
}
