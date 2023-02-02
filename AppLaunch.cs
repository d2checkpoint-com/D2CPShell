using System;
using System.Diagnostics;
using System.Windows.Forms;
using D2CPShell.Properties;

namespace D2CPShell
{
    public static class AppLaunch
    {
        public static void LaunchSteam(bool d2Launch)
        {
            try
            {
                var steam = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "C:\\Program Files (x86)\\Steam\\steam.exe",
                        UseShellExecute = false
                    }
                };

                if (d2Launch)
                {
                    steam.StartInfo.Arguments = "-applaunch 1085660";
                }

                steam.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Resources.AppLaunch__0__1___2_, 
                        Resources.AppLaunch_An_error_occurred_while_trying_to_launch, 
                        Resources.AppLaunch_LaunchSteam_Steam, "\n" + ex.Message),
                    Resources.AppLaunch_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LaunchParsec()
        {
            try
            {
                var parsec = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "C:\\Program Files\\Parsec\\parsecd.exe",
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Minimized
                    }
                };
                parsec.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Resources.AppLaunch__0__1___2_, 
                        Resources.AppLaunch_An_error_occurred_while_trying_to_launch, 
                        "Parsec", "\n" + ex.Message),
                    Resources.AppLaunch_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static void LaunchAfkMacro()
        {
            try
            {
                var afkMacro = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "D2CPAFKMacro.exe",
                        UseShellExecute = false
                    }
                };
                afkMacro.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(Resources.AppLaunch__0__1___2_, 
                        Resources.AppLaunch_An_error_occurred_while_trying_to_launch, 
                        "D2CP AFK Macro", "\n" + ex.Message),
                    Resources.AppLaunch_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}