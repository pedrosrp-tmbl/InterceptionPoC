using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterceptionPoC.Domain;

namespace InterceptionPoC.Services
{
    public interface IIdentityVerificationService
    {
        void RunVerificationProcess(int userId);
        bool GetVerificationStatusForData(string firstName, string surname);
        IList<User> GetPendingVerifiedUsers(); 
    }
}
