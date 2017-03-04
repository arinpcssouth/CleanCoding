using Model.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAbstract.Factories
{
    public interface IClassroomFactory
    {

        List<Classroom> GenerateClassrooms();

    }
}
