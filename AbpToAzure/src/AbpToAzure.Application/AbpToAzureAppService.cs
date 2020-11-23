using System;
using System.Collections.Generic;
using System.Text;
using AbpToAzure.Localization;
using Volo.Abp.Application.Services;

namespace AbpToAzure
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpToAzureAppService : ApplicationService
    {
        protected AbpToAzureAppService()
        {
            LocalizationResource = typeof(AbpToAzureResource);
        }
    }
}
