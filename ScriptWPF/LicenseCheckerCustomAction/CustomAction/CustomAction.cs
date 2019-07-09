using Microsoft.Deployment.WindowsInstaller;

namespace LicenseCheckerCustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            return ActionResult.Success;
        }
    }
}