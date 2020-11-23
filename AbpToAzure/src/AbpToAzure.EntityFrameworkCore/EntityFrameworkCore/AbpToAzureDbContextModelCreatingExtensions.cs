using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpToAzure.EntityFrameworkCore
{
    public static class AbpToAzureDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpToAzure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpToAzureConsts.DbTablePrefix + "YourEntities", AbpToAzureConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}