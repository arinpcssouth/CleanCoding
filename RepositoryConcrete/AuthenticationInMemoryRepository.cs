using Model.Authentication;
using RepositoryAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryConcrete.InMemory
{
   

    public class AuthenticationInMemoryRepository : IAuthenticationRepository
    {
        List<Session> Sessions;
        List<Person> People;
        public AuthenticationInMemoryRepository()
        {
            Sessions = new List<Session>();
            People = new List<Person>();

            LoadDataIntoMemory();
        }

        

        public ActiveSession Login(UserCredentials credentials)
        {
            return CheckUser(credentials);
        }

        public bool ValidateSession(ActiveSession session)
        {
           
                return Sessions.FirstOrDefault(s => s.Id == session.Token) == null ? false : true;
           
        }

        public ActiveSession GetSessionByToken(Guid token)
        {
            
                var session = Sessions.FirstOrDefault(s => s.Id == token);
                if (session == null)
                    return new ActiveSession { Token = new Guid() };
                else
                    return new ActiveSession { Token = session.Id, DateLastUsed = session.DateTimeLastUsed, DateTimeInitiated = session.DateTimeFirstInitiated };
           
        }


        #region internals
        internal class Session
        {
            public System.Guid Id { get; set; }
            public System.Guid PersonId { get; set; }
            public Nullable<System.DateTime> DateTimeFirstInitiated { get; set; }
            public Nullable<System.DateTime> DateTimeLastUsed { get; set; }

            public virtual Person Person { get; set; }
        }
        internal class Person
        {
            public Person()
            {
                this.Sessions = new HashSet<Session>();
            }

            public System.Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

            public virtual ICollection<Session> Sessions { get; set; }

        }


        #endregion

        #region private 

        private void LoadDataIntoMemory()
        {
           
            Person myInMemoryPerson = new Person
            {
                FirstName = "Arin",
                Id = Guid.NewGuid(),
                LastName = "T.",
                Password = "test",
                Username = "arin"
            };

            Session session = new Session
            {
                DateTimeFirstInitiated = DateTime.UtcNow.AddHours(-3),
                DateTimeLastUsed = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                Person = myInMemoryPerson,
                PersonId = myInMemoryPerson.Id
            };

            Sessions.Add(session);

            myInMemoryPerson.Sessions = Sessions;
            People.Add(myInMemoryPerson);
        }
        private ActiveSession CheckUser(UserCredentials credentials)
        {
                var person = People.Where(p => p.Username.ToLower() == credentials.Username.ToLower() && p.Password == credentials.Password).FirstOrDefault();
                if (person == null)
                    return new ActiveSession { Token = new Guid() };

                ActiveSession session = GetExistingSession(person);

                if (session == null)
                    session = CreateNewSession(person);

                return session;
        }

        private ActiveSession CreateNewSession(Person person)
        {
            Session session = new Session { Id = Guid.NewGuid(), DateTimeFirstInitiated = DateTime.UtcNow, DateTimeLastUsed = DateTime.UtcNow, PersonId = person.Id };
            Sessions.Add(session);
            return new ActiveSession { DateTimeInitiated = session.DateTimeFirstInitiated, DateLastUsed = session.DateTimeLastUsed, Token = session.Id };
        }

        private ActiveSession GetExistingSession(Person person)
        {
            return Sessions.Where(s => s.PersonId == person.Id).Select(s => new ActiveSession { DateTimeInitiated = s.DateTimeFirstInitiated, Token = s.Id, DateLastUsed = s.DateTimeLastUsed }).FirstOrDefault();
        }



        #endregion


    }
    
}
