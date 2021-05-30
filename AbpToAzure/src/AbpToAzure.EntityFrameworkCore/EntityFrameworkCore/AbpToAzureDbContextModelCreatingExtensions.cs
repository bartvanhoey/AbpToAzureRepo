using Microsoft.EntityFrameworkCore;
using AbpToAzure.Books;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

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
            builder.Entity<Book>(b =>
            {
                b.ToTable(AbpToAzureConsts.DbTablePrefix + "Books", AbpToAzureConsts.DbSchema);
                b.ConfigureByConvention();
            
                b.Property(x => x.Name).IsRequired().HasMaxLength(128 );
                // b.HasIndex(x => x.Name);
            });
        }
    }
}