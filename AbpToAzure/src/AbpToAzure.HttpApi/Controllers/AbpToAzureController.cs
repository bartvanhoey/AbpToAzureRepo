using AbpToAzure.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpToAzure.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpToAzureController : AbpController
    {
        protected AbpToAzureController()
        {
            LocalizationResource = typeof(AbpToAzureResource);
        }
    }
}