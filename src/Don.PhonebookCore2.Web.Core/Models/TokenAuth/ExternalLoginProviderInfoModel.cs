using Abp.AutoMapper;
using Don.PhonebookCore2.Authentication.External;

namespace Don.PhonebookCore2.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
