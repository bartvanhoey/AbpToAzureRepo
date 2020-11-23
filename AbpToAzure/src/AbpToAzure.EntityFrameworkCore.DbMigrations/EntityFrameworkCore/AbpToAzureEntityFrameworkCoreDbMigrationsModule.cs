using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpToAzure.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpToAzureEntityFrameworkCoreModule)
        )]
    public class AbpToAzureEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpToAzureMigrationsDbContext>();
        }
    }
}
