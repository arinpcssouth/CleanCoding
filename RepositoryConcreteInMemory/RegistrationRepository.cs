using Model.PeopleClasses;
using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryConcreteInMemory
{
    public class RegistrationRepository<T> : IRegistrationRepository<T> 
    {
        List<T> RegisteredMembers;

        public RegistrationRepository()
        {
            RegisteredMembers = new List<T>();
        }


        public IEnumerable<T> GetEveryone()
        {
            return RegisteredMembers;
        }

        public IEnumerable<T> GetListOf(Type personType)
        {
            return RegisteredMembers.Where(r => r.GetType() == personType);
        }

        public bool Register(T person)
        {
            RegisteredMembers.Add(person);
            //we can do some more logic here and return the true or false accordingly. Say if transaction fails or something. 
            return true;
        }
    }
}
