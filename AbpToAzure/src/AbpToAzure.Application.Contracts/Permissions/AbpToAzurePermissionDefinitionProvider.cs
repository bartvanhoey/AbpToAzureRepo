﻿using AbpToAzure.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpToAzure.Permissions
{
    public class AbpToAzurePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpToAzurePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpToAzurePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpToAzureResource>(name);
        }
    }
}
