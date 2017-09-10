using System.Threading.Tasks;
using Abp.Application.Services;
using Don.PhonebookCore2.Authorization.Accounts.Dto;

namespace Don.PhonebookCore2.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
