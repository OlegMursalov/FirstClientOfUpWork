using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomActionForWix
{
    public class CustomAction
    {
        [CustomAction]
        public static ActionResult CustomAction1(Session session)
        {
            session["MSGVAR"] = "Some Message";
            return ActionResult.Success;
        }
    }
}