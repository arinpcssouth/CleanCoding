using Model.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAbstract
{
    public interface IRegistration
    {
        List<Person> WhoIsRegistered();



        bool RegisterTeacher(Teacher teacher);
        bool RegisterOfficeStaff(OfficeStaff officeStaff);

        List<Person> GetListOf(Type personType);
        



    }
}
