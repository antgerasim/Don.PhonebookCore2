using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Don.PhonebookCore2.Configuration;
using Don.PhonebookCore2.EntityFrameworkCore;
using Don.PhonebookCore2.Migrator.DependencyInjection;

namespace Don.PhonebookCore2.Migrator
{
    [DependsOn(typeof(PhonebookCore2EntityFrameworkModule))]
    public class PhonebookCore2MigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PhonebookCore2MigratorModule(PhonebookCore2EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(PhonebookCore2MigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PhonebookCore2Consts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhonebookCore2MigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}