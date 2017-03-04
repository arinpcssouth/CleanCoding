using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PeopleClasses
{
    public class Parent : Person
    {
        public override PersonRole Role
        {
            get
            {
                return PersonRole.Parent;
            }
        }

        public string Email { get; set; }
        public string EmergencyContact { get; set; }

    }
}
