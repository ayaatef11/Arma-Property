﻿using MyBookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyBookStore.Permissions;

public class ArmaPropertyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ArmaPropertyPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MyBookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ArmaPropertyResource>(name);
    }
}
