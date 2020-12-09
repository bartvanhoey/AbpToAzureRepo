using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpToAzure.Data;
using Volo.Abp.DependencyInjection;

namespace AbpToAzure.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpToAzureDbSchemaMigrator
        : IAbpToAzureDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpToAzureDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpToAzureMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpToAzureMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}