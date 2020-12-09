using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpToAzure.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpToAzureBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpToAzure";
    }
}
