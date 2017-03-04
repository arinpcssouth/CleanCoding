using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PeopleClasses
{
    public class Teacher : Person
    {
        public override PersonRole Role
        {
            get
            {
                return PersonRole.Teacher;
            }
        }

        public string FormalName { get; set; }

        public bool AcceptsEmails { get; set; }
        public Classroom TeachesIn { get; set; }

    }
}
