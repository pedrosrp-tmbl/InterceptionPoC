using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterceptionPoC.Common;
using InterceptionPoC.Domain;

namespace InterceptionPoC.Services
{
    public interface IUserService
    {
        [Logging(logParametersAfterExecution: true)]
        User CreateUser(string firstName, string surname);

        [Logging]
        User GetUser(int userId);

        [Logging]
        IList<User> GetUsers(Predicate<User> userFilter);
    }
}
