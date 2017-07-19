using InterceptionPoC.Interceptor;
using InterceptionPoC.Services;
using InterceptionPoC.Services.Implementation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace InterceptionPoC.App_Start
{
    public static class Startup
    {
        public static void RegisterStartupRequirements(IUnityContainer container)
        {
            //Required members to handle the interception
            InjectionMember[] injectionMembers = { new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>() };

            container.AddNewExtension<Interception>();
            container.RegisterType<ILogService, LogService>();

            //Configure services with the injector
            container.RegisterType<IUserService, UserService>(injectionMembers);
            container.RegisterType<IIdentityVerificationService, IdentityVerificationService>(injectionMembers);
        }
    }
}
