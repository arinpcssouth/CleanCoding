using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PeopleClasses
{
    public class Student : Person
    {
        public override PersonRole Role
        {
            get
            {
                return PersonRole.Student;
            }
        }

        public int StudentId { get; set; }

        public Classroom InClass { get; set; }

    }
}
