using System.Threading.Tasks;

namespace AbpToAzure.Data
{
    public interface IAbpToAzureDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
