using System.Threading.Tasks;
using Abp.Application.Services;
using Don.PhonebookCore2.Sessions.Dto;

namespace Don.PhonebookCore2.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
