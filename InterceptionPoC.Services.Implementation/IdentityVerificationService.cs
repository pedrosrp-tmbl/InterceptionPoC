using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterceptionPoC.Domain;

namespace InterceptionPoC.Services.Implementation
{
    public class IdentityVerificationService : IIdentityVerificationService
    {
        public void RunVerificationProcess(int userId)
        {
            //Do nothing
        }

        public bool GetVerificationStatusForData(string firstName, string surname)
        {
            return true;
        }

        public IList<User> GetPendingVerifiedUsers()
        {
            return new List<User>()
            {
                new User(){Id=1, FirstName = "Steven", Surname = "Teal", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=2, FirstName = "Neil", Surname = "Trodden", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=3, FirstName = "Andrew", Surname = "Pears", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=4, FirstName = "Michael", Surname = "Simpson", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=5, FirstName = "Zarar", Surname = "Iqbal", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=6, FirstName = "Shaun", Surname = "Dixon", VerificationStatus=VerificationStatus.VerificationFailed},
                new User(){Id=7, FirstName = "Pedro", Surname = "San Roman Pacheco", VerificationStatus=VerificationStatus.VerificationFailed}
            };
        }
    }
}
