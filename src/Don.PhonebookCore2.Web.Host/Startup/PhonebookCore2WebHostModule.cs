using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Don.PhonebookCore2.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Don.PhonebookCore2.Web.Host.Startup
{
    [DependsOn(
       typeof(PhonebookCore2WebCoreModule))]
    public class PhonebookCore2WebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PhonebookCore2WebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhonebookCore2WebHostModule).GetAssembly());
        }
    }
}
