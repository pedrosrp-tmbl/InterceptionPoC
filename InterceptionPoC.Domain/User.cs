using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptionPoC.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public VerificationStatus VerificationStatus { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, FirstName: {1}, Surname: {2}, VerificationStatus: {3}", Id, FirstName, Surname, VerificationStatus);
        }
    }
}
