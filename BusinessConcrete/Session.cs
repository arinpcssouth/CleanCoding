using BusinessAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Authentication;
using RepositoryAbstract;

namespace BusinessConcrete
{
    public class Session : ISession
    {
        IAuthenticationRepository authenticationRepository;

        public Session(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }

        public ActiveSession Create(UserCredentials credentials)
        {
            //convert password to hash here. 
            //check to be sure username and password are not empty

            return authenticationRepository.Login(credentials);
        }

        public bool IsValid(ActiveSession session)
        {
            return authenticationRepository.ValidateSession(session);
        }

        public ActiveSession GetSessionByToken(string token)
        {
            Guid tokenGuid = new Guid();
            if (Guid.TryParse(token, out tokenGuid))
                return authenticationRepository.GetSessionByToken(tokenGuid);
            else
                return new ActiveSession { Token = tokenGuid };
        }

    }
}
