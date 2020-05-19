using Android.App;
using Android.Widget;
using Java.Util;
using System.Collections.Generic;
using System.Linq;

namespace Download
{
    public class PermissionHandler
    {
        public static Activity Activity { get; set; }
        public PermissionHandler(string[] essentialPermissions, params string[] permissions)
        {
            EssentialPermissions = essentialPermissions;
            Permissions = permissions;
            CheckPermissions();
        }
        public PermissionHandler(params string[] essentialPermissions)
        {
            EssentialPermissions = essentialPermissions;
            CheckPermissions();
        }
        public PermissionHandler(Activity activity, string[] essentialPermissions, params string[] permissions)
        {
            Activity = activity;
            EssentialPermissions = essentialPermissions;
            Permissions = permissions;
            CheckPermissions();
        }
        public PermissionHandler(Activity activity, params string[] essentialPermissions)
        {
            Activity = activity;
            EssentialPermissions = essentialPermissions;
            CheckPermissions();
        }
        private void CheckPermissions()
        {
            if (EssentialPermissions != null)
                foreach (var p in Permissions)
                    if (Activity.CheckSelfPermission(p) == Android.Content.PM.Permission.Granted && !grantedPermissions.Contains(p))
                        grantedPermissions.Add(p);
            if (Permissions != null)
                foreach (var p in Permissions)
                    if (Activity.CheckSelfPermission(p) == Android.Content.PM.Permission.Granted && !grantedPermissions.Contains(p))
                        grantedPermissions.Add(p);
        }
        public void AddPermission(string permission)
        {
            var tmp = Permissions.ToList();
            if (tmp != null)
            {
                tmp.Add(permission);
                Permissions = tmp.ToArray();
                CheckPermissions();
            }
            CheckPermissions();
        }
        public void RemovePermission(string permission)
        {
            var tmp = Permissions.ToList();
            if (tmp != null)
            {
                tmp.Remove(permission);
                Permissions = tmp.ToArray();
                CheckPermissions();
            }
        }
        public bool HasEssentialPermissions()
        {
            if (EssentialPermissions == null)
                return false;
            foreach (var p in EssentialPermissions)
                if (!HasPermission(p))
                    return false;
            return true;
        }
        public void RequestEssentialPermissions()
        {
            if (!(EssentialPermissions != null))
                foreach (var p in EssentialPermissions)
                    RequestPermission(p);
        }
        public bool HasAllPermissions()
        {
            if (EssentialPermissions != null)
                if (!HasEssentialPermissions())
                    return false;
            if (Permissions != null)
                foreach (var p in Permissions)
                    if (!HasPermission(p))
                        return false;
            return true;
        }
        public void RequestAllPermissions()
        {
            if (!(EssentialPermissions != null))
                foreach (var p in EssentialPermissions)
                    RequestPermission(p);
            if (!(Permissions != null))
                foreach (var p in Permissions)
                    RequestPermission(p);
        }
        private readonly List<string> grantedPermissions = new List<string>();

        public void RequestPermission(string permission)
        {
            if (!HasPermission(permission))
            {
                var id = new Random().NextInt(int.MaxValue / 2);
                if (Activity.ShouldShowRequestPermissionRationale(permission))
                {
                    //set alert for executing the task
                    AlertDialog.Builder alert = new AlertDialog.Builder(Activity);
                    alert.SetTitle("Permissions Needed");
                    alert.SetMessage("The application need special permissions to continue");
                    alert.SetPositiveButton("Request Permissions", (senderAlert, args) =>
                    {
                        Activity.RequestPermissions(new string[] { permission }, id);
                    });

                    alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                    {
                        Toast.MakeText(Activity, "Cancelled!", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();


                    return;
                }

                Activity.RequestPermissions(new string[] { permission }, id);
            }
        }
        public void RequestPermissionResult(int requestCode, string[] permissions, [Android.Runtime.GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            for (int i = 0; i < permissions.Length; i++)
                if (grantResults[i] == Android.Content.PM.Permission.Granted)
                    grantedPermissions.Add(permissions[i]);
            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool HasPermission(string permission)
        {
            return grantedPermissions.Contains(permission);
        }

        public string[] EssentialPermissions { get; private set; }
        public string[] Permissions { get; private set; }
    }
}