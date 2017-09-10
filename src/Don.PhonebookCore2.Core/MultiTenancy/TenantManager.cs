using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Don.PhonebookCore2.Authorization.Users;
using Don.PhonebookCore2.Editions;

namespace Don.PhonebookCore2.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}