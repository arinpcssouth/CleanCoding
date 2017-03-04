using Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAbstract
{
    public interface ISession
    {
        ActiveSession Create(UserCredentials credentials);

        bool IsValid(ActiveSession session);
        ActiveSession GetSessionByToken(string token);
    }
}
