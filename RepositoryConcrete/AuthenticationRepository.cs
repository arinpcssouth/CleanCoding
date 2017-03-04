using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Authentication;
using DataAccess;

namespace RepositoryConcrete
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public ActiveSession Login(UserCredentials credentials)
        {
            return CheckUser(credentials);
        }

        public bool ValidateSession(ActiveSession session)
        {
            using (var dbcontext = new DataAccess.MyCleanSolutionDatabaseEntities())
            {
                return dbcontext.Sessions.FirstOrDefault(s => s.Id == session.Token) == null ? false : true;
            }
        }

        public ActiveSession GetSessionByToken(Guid token)
        {
            using (var dbcontext = new DataAccess.MyCleanSolutionDatabaseEntities())
            {
                var session = dbcontext.Sessions.FirstOrDefault(s => s.Id == token);
                if (session == null)
                    return new ActiveSession { Token = new Guid() };
                else
                    return new ActiveSession { Token = session.Id, DateLastUsed = session.DateTimeLastUsed, DateTimeInitiated = session.DateTimeFirstInitiated };
            }
        }

        #region private 
        private ActiveSession CheckUser(UserCredentials credentials)
        {
            using (var dbcontext = new DataAccess.MyCleanSolutionDatabaseEntities())
            {
                var person = dbcontext.People.Where(p => p.Username == credentials.Username && p.Password == credentials.Password).FirstOrDefault();
                if (person == null)
                    return new ActiveSession {Token = new Guid() };

                ActiveSession session = GetExistingSession(person, dbcontext);

                if (session == null)
                    session = CreateNewSession(person, dbcontext);

                return session;
            }
        }

        private ActiveSession CreateNewSession(Person person, MyCleanSolutionDatabaseEntities dbcontext)
        {
            Session session = new Session { Id = Guid.NewGuid(), DateTimeFirstInitiated = DateTime.UtcNow, DateTimeLastUsed = DateTime.UtcNow, PersonId = person.Id };
            dbcontext.Sessions.Add(session);
            dbcontext.SaveChanges();
            return new ActiveSession { DateTimeInitiated = session.DateTimeFirstInitiated, DateLastUsed = session.DateTimeLastUsed, Token = session.Id };
        }

        private ActiveSession GetExistingSession(Person person, MyCleanSolutionDatabaseEntities dbcontext)
        {
            return dbcontext.Sessions.Where(s => s.PersonId == person.Id).Select(s => new ActiveSession { DateTimeInitiated = s.DateTimeFirstInitiated, Token = s.Id , DateLastUsed = s.DateTimeLastUsed  }).FirstOrDefault();
        }



        #endregion


    }
}
