using BusinessAbstract.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.PeopleClasses;

namespace BusinessConcrete
{
    public class RegistrationFactory : IRegistrationFactory
    {
        public bool RegisterFamilyToAClass(List<Parent> parents, Student student, Classroom classroom)
        {
            throw new NotImplementedException();
        }
    }
}
