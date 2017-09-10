using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Don.PhonebookCore2.Configuration.Dto;

namespace Don.PhonebookCore2.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PhonebookCore2AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
