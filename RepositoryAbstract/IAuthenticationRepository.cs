using Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAbstract
{
    public interface IAuthenticationRepository
    {
        ActiveSession Login(UserCredentials credentials);

        bool ValidateSession(ActiveSession session);
        ActiveSession GetSessionByToken(Guid token);
    }
}
