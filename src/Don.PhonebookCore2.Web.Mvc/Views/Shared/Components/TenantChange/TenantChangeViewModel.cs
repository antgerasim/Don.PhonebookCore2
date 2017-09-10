using Abp.AutoMapper;
using Don.PhonebookCore2.Sessions.Dto;

namespace Don.PhonebookCore2.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}