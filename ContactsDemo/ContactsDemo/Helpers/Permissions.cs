using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsDemo.Helpers
{
    static class Permissions
    {
        public static async Task<bool> RequestPermission(Plugin.Permissions.Abstractions.Permission permission)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
            if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                var requestpermissionresult = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Contacts);

                if (requestpermissionresult[Plugin.Permissions.Abstractions.Permission.Contacts] != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
