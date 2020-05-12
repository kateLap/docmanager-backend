using System;
using System.Web;
using System.Web.Http;
using DocManager.Web;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;

[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace DocManager.Web
{
    using static DependencyResolver.RegisterServices;

    public static class NinjectWebCommon
    {
        public static IKernel ApplicationKernel;

        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static HttpConfiguration config;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start(HttpConfiguration config)
        {
            NinjectWebCommon.config = config;
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
                config.DependencyResolver = new NinjectDependencyResolver(kernel);

                ApplicationKernel = kernel;
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
            Register(kernel);
        }
    }
}