using Model.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAbstract.Factories
{
    public interface IRegistrationFactory
    {
        bool RegisterFamilyToAClass(List<Parent> parents, Student student, Classroom classroom);

    }
}
