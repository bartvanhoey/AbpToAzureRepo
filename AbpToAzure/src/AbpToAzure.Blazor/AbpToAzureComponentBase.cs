using AbpToAzure.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpToAzure.Blazor
{
    public abstract class AbpToAzureComponentBase : AbpComponentBase
    {
        protected AbpToAzureComponentBase()
        {
            LocalizationResource = typeof(AbpToAzureResource);
        }
    }
}
