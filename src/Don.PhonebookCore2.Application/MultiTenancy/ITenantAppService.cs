using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Don.PhonebookCore2.MultiTenancy.Dto;

namespace Don.PhonebookCore2.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
