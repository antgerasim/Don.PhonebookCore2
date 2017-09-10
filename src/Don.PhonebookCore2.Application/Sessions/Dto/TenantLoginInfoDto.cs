using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Don.PhonebookCore2.MultiTenancy;

namespace Don.PhonebookCore2.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}