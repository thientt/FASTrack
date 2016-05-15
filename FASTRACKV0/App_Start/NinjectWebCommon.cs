[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FASTrack.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FASTrack.App_Start.NinjectWebCommon), "Stop")]

namespace FASTrack.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using FASTrack.Model.Abstracts;
    using FASTrack.Model.Concretes;
    using FASTrack.Utilities;

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
            kernel.Bind<ILogService>().To<LogService>();
            var logService = kernel.Get<ILogService>();

            kernel.Bind<IMSTAssembliesSiteRepository>().To<MSTAssembliesSiteRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTBuRepository>().To<MSTBuRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IHSTReasonRepository>().To<HSTReasonRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReasonINIRepository>().To<MSTReasonINIRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReasonFINRepository>().To<MSTReasonFINRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReasonChangingFINTargetRepository>().To<MSTReasonChangingFINTargetRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReasonChangingINITargetRepository>().To<MSTReasonChangingINITargetRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReasonChangingPriorityRepository>().To<MSTReasonChangingPriorityRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReasonFAROnHoldRepository>().To<MSTReasonFAROnHoldRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReasonFARCloseRepository>().To<MSTReasonFARCloseRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTDepartmentRepository>().To<MSTDepartmentRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFabSiteRepository>().To<FabSiteRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARAnalystReassignLogRepository>().To<FARAnalystReassignLogRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARDeviceDetailsRepository>().To<FARDeviceDetailsRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTFailureOriginRepository>().To<MSTFailureOriginRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTFailureTypeRepository>().To<MSTFailureTypeRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARFinalTargetLogRepository>().To<FARFinalTargetLogRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARPriorityLogRepository>().To<FARPriorityLogRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ILOGHistoryRepository>().To<FARHistoryRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARInitialTargetLogRepository>().To<FARInitialTargetLogRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARMasterRepository>().To<FARMasterRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTOriginRepository>().To<MSTOriginRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTPriorityRepository>().To<MSTPriorityRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARProcessHistoryRepository>().To<FARProcessHistoryRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ILOGProcessHistoryRepository>().To<LOGProcessHistoryRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTProductRepository>().To<MSTProductRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTServiceRepository>().To<MSTServiceRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTStatusRepository>().To<MSTStatusRespository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTPackageTypesRepository>().To<MSTPackageTypesRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTProcessTypesRepository>().To<MSTProcessTypesRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTProcessResultRepository>().To<MSTProcessResultRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTReportTypesRepository>().To<MSTReportTypesRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ISYSRolesRepository>().To<SYSRolesRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTSitesRepository>().To<MSTSitesRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTCustomerRepository>().To<MSTCustomerRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<ISYSUsersRepository>().To<SYSUsersRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTProcessProductRepository>().To<MSTProcessProductRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARUploadRepository>().To<FARUploadRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTFarReportRepository>().To<MSTFarReportRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IFARMechanismRepository>().To<FARMechanismRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTLabSiteRepository>().To<MSTLabSiteRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTRatingRepository>().To<MSTRatingRepository>().WithConstructorArgument<ILogService>(logService);
            kernel.Bind<IMSTTechnogolyRepository>().To<MSTTechnogolyRepository>().WithConstructorArgument<ILogService>(logService);
        }
    }
}
