using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpToAzure.Data
{
    /* This is used if database provider does't define
     * IAbpToAzureDbSchemaMigrator implementation.
     */
    public class NullAbpToAzureDbSchemaMigrator : IAbpToAzureDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}