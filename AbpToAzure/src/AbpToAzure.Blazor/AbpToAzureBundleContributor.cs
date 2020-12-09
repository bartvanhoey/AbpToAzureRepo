using Volo.Abp.Bundling;

namespace AbpToAzure.Blazor
{
    public class AbpToAzureBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}
