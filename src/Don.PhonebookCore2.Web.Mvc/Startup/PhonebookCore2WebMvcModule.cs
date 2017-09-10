using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Don.PhonebookCore2.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Don.PhonebookCore2.Web.Startup
{
    [DependsOn(typeof(PhonebookCore2WebCoreModule))]
    public class PhonebookCore2WebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PhonebookCore2WebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<PhonebookCore2NavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhonebookCore2WebMvcModule).GetAssembly());
        }
    }
}