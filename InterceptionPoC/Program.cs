using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterceptionPoC.App_Start;
using InterceptionPoC.Services;
using Microsoft.Practices.Unity;

namespace InterceptionPoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // Initialize unity container: Here is where we will apply our interceptor to desired Interfaces
            Startup.RegisterStartupRequirements(container);
            
            var userService = container.Resolve<IUserService>();
            try
            {
                userService.GetUser(123654);
            }
            catch (Exception ex)
            {
                
                
            }
            
            userService.CreateUser("Juan", "Lopez Alarcon");
            var userList = userService.GetUsers(user => user.FirstName != string.Empty);

        }
    }
}
