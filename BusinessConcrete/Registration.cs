using Model.PeopleClasses;
using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessConcrete
{
    public class Registration : BusinessAbstract.IRegistration
    {

        IRegistrationRepository<Staff> registrationRepository;

        public Registration(IRegistrationRepository<Staff> registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public List<Person> GetListOf(Type personType)
        {
            return ((IRegistrationReadRepository<Person>)registrationRepository).GetListOf(personType).ToList();
        }

        public bool RegisterOfficeStaff(OfficeStaff officeStaff)
        {
            //can apply some logic here later to work on the officeStaffobject before sending it to repo.

            return ((IRegistrationWriteRepository<OfficeStaff>)registrationRepository).Register(officeStaff);
        }

        public bool RegisterTeacher(Teacher teacher)
        {
            //can apply some logic here later to work on the teacher object before sending it to repo.
            return ((IRegistrationWriteRepository<Teacher>)registrationRepository).Register(teacher);
        }

        public List<Person> WhoIsRegistered()
        {
            return ((IRegistrationReadRepository<Person>)registrationRepository).GetEveryone().ToList();
        }
    }
}
