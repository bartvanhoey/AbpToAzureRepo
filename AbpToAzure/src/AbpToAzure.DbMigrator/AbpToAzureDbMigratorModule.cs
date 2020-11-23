using AbpToAzure.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpToAzure.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpToAzureEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpToAzureApplicationContractsModule)
        )]
    public class AbpToAzureDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
