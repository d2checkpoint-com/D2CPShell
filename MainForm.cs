using System;
using System.Windows.Forms;

namespace D2CPShell
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SteamButton_Click(object sender, EventArgs e)
        {
            AppLaunch.LaunchSteam(false);
        }

        private void ParsecButton_Click(object sender, EventArgs e)
        {
            AppLaunch.LaunchParsec();
        }

        private void DestinyButton_Click(object sender, EventArgs e)
        {
            AppLaunch.LaunchSteam(true);
        }

        private void MacroButton_Click(object sender, EventArgs e)
        {
            AppLaunch.LaunchAfkMacro();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            NativeMethods.LogOffUser();
        }

        private void RebootButton_Click(object sender, EventArgs e)
        {
            NativeMethods.RebootMachine();
        }

        private void ShutdownButton_Click(object sender, EventArgs e)
        {
            NativeMethods.ShutDownMachine();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AppLaunch.LaunchSteam(true);
            AppLaunch.LaunchAfkMacro();
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            NativeMethods.LogOffUser();
        }
    }
}