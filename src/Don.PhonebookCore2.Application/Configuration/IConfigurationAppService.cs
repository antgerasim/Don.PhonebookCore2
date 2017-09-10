using System.Threading.Tasks;
using Don.PhonebookCore2.Configuration.Dto;

namespace Don.PhonebookCore2.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}