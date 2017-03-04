using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Authentication;

namespace RepositoryFake
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public ActiveSession Login(string username, string password)
        {
            ActiveSession fakeSession = new ActiveSession();
            fakeSession.Token = Guid.NewGuid();
            fakeSession.DateTimeInitiated = DateTime.UtcNow;

            return fakeSession;
        }

        public bool ValidateSession(ActiveSession session)
        {
            return true;
        }
    }
}
