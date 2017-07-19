using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterceptionPoC.Common;
using InterceptionPoC.Domain;

namespace InterceptionPoC.Services.Implementation
{
    public class UserService : IUserService
    {
        
        public User CreateUser(string firstName, string surname)
        {
            return new User(){FirstName = firstName, Surname = surname, VerificationStatus = VerificationStatus.VerificationPending};
        }

        
        public User GetUser(int userId)
        {
            throw new Exception("Invalid userId");
        }

        
        public IList<User> GetUsers(Predicate<User> userFilter)
        {
         
            return new List<User>()
            {
                new User(){Id=1, FirstName = "Pedro", Surname = "Teal", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=2, FirstName = "Zarar", Surname = "Trodden", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=3, FirstName = "Neil", Surname = "Pears", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=4, FirstName = "Andrew", Surname = "Simpson", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=5, FirstName = "Shaun", Surname = "Iqbal", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=6, FirstName = "Michael", Surname = "Dixon", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=7, FirstName = "Steven", Surname = "San Roman Pacheco", VerificationStatus=VerificationStatus.VerificationFailed}
            }; 
        }
    }
}
