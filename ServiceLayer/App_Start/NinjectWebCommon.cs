[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ServiceLayer.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ServiceLayer.App_Start.NinjectWebCommon), "Stop")]

namespace ServiceLayer.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Ninject.Web.WebApi;
    using RepositoryAbstract;
    using BusinessAbstract;
    using BusinessAbstract.Factories;
    using Controllers.ActionFilters;
    using Ninject.Web.WebApi.FilterBindingSyntax;
    using System.Web.Http.Filters;
    using Model.PeopleClasses;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            
            //Here you can easily switch between repository implementaitons. Thanks to Dependency inversion principle. 
            //kernel.Bind<IAuthenticationRepository>().To<RepositoryConcrete.AuthenticationRepository>();
            kernel.Bind<IAuthenticationRepository>().To<RepositoryConcreteInMemory.AuthenticationRepository>();


            kernel.Bind<IRegistrationRepository<Person>>().To<RepositoryConcreteInMemory.RegistrationRepository<Person>>();


            kernel.Bind<ISession>().To<BusinessConcrete.Session>();
            kernel.Bind<IClassroomFactory>().To<BusinessConcrete.Factories.ClassroomFactory>();

            //this is to enable DI in action filters. Basically we bind the filter to an empty attribute class. 
            kernel.BindHttpFilter<ValidateTokenFilter>(FilterScope.Action).WhenActionMethodHas<ValidateTokenAttribute>();

        }
    }
}
