using AbpToAzure.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpToAzure.Blazor
{
    public class AbpToAzureComponentBase : AbpComponentBase
    {
        public AbpToAzureComponentBase()
        {
            LocalizationResource = typeof(AbpToAzureResource);
        }
    }
}
