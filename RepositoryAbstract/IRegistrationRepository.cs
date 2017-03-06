using Model.PeopleClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAbstract
{
    //in
    public interface IRegistrationWriteRepository<in T> 
    {
        bool Register(T person);
    }

    public interface IRegistrationReadRepository<out T> 
    {
        IEnumerable<T> GetListOf(Type personType);
        IEnumerable<T> GetEveryone();
    }



    public interface IRegistrationRepository<T> :IRegistrationReadRepository<T>, IRegistrationWriteRepository<T> 
    {

    }
}
