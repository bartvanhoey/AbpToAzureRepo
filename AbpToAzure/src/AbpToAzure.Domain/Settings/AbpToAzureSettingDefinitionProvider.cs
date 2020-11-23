using Volo.Abp.Settings;

namespace AbpToAzure.Settings
{
    public class AbpToAzureSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpToAzureSettings.MySetting1));
        }
    }
}
