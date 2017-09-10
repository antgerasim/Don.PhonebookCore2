using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Don.PhonebookCore2.Authorization;

namespace Don.PhonebookCore2
{
    [DependsOn(
        typeof(PhonebookCore2CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PhonebookCore2ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PhonebookCore2AuthorizationProvider>();
        }

        public override void Initialize()
        {
            Assembly thisAssembly = typeof(PhonebookCore2ApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                //Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(thisAssembly);
            });
        }
    }
}