using Volo.Abp.Modularity;

namespace AbpToAzure
{
    [DependsOn(
        typeof(AbpToAzureApplicationModule),
        typeof(AbpToAzureDomainTestModule)
        )]
    public class AbpToAzureApplicationTestModule : AbpModule
    {

    }
}