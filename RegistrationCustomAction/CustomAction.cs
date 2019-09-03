using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using Microsoft.Deployment.WindowsInstaller;

namespace RegistrationCustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult SaveUserInfo(Session session)
        {
            string name = session["FULLNAMEProperty"];
            string email = session["EMAILProperty"];

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email))
            {
                session["FILLProperty"] = "0";
                MessageBox.Show("Please input Name or Email");
                return ActionResult.Success;
            }

            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(appdataPath + "\\NetJapan Application"))
                Directory.CreateDirectory(appdataPath + "\\NetJapan Application");

            File.WriteAllText(appdataPath + "\\NetJapan Application\\registrationInfo.txt", name + "," + email);

            session["FILLProperty"] = "1";
            return ActionResult.Success;
        }
    }
}
