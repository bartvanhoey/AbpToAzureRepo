using AbpToAzure.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpToAzure
{
    [DependsOn(
        typeof(AbpToAzureEntityFrameworkCoreTestModule)
        )]
    public class AbpToAzureDomainTestModule : AbpModule
    {

    }
}