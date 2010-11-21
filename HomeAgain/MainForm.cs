using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;
using System.Globalization;


namespace HomeAgain
{
    public partial class MainForm : Form
    {
        // from wtsapi32.h
        private const int NotifyForThisSession = 0;

        // from winuser.h
        private const int SessionChangeMessage = 0x02B1;
        private const int SessionLockParam = 0x7;
        private const int SessionUnlockParam = 0x8;

        [DllImport("wtsapi32.dll")]
        private static extern bool WTSRegisterSessionNotification(IntPtr hWnd, int dwFlags);

        [DllImport("wtsapi32.dll")]
        private static extern bool WTSUnRegisterSessionNotification(IntPtr hWnd);

        private bool isLocked = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateMenu();
            WTSRegisterSessionNotification(this.Handle, NotifyForThisSession);
            Properties.Settings.Default.Reload();
            showNotificationsToolStripMenuItem.Checked = Properties.Settings.Default.ShowNotifications;
        }
        /// <summary>
        /// The windows session has been locked
        /// </summary>
        protected virtual void OnSessionLock()
        {
            TraceLine("Locked");
            isLocked = true;
            return;
        }
        private string notifyTitle = "";
        private string notifyText = "";
        private ToolTipIcon notifyIcon = ToolTipIcon.Info;
        /// <summary>
        /// The windows session has been unlocked
        /// </summary>
        protected virtual void OnSessionUnlock()
        {
            TraceLine("UnLocked");
            try
            {
                if (notifyTitle.Length > 0)
                {
                    TraceLine("Showing earlier stored balloon");
                    notifyIcon1.ShowBalloonTip(10 * 1000, notifyTitle, notifyTitle, notifyIcon);
                    notifyTitle = "";
                }
            }
            catch { }
            isLocked = false;

            return;
        }
        public Stream getHttpStream(string url, string uname, string pwd)
        {
            Stream resStream = null;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            string password = pwd;
            string username = uname;
            string autorization = username + ":" + password;
            byte[] binaryAuthorization = System.Text.Encoding.UTF8.GetBytes(autorization);
            autorization = Convert.ToBase64String(binaryAuthorization);
            autorization = "Basic " + autorization;
            request.Headers.Add("AUTHORIZATION", autorization);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // we will read data via the response stream
            resStream = response.GetResponseStream();
            return resStream;
        }
        private int testCounter = 0;
        private void randomException()
        {
            testCounter++;
            if ((testCounter % 10) < 5)
            {
                TraceLine(String.Format("Throwing exception [{0}]", testCounter));
                throw new Exception("Test");
            }
            else
            {
                TraceLine(String.Format("Not Throwing exception [{0}]", testCounter));
            }
        }
        private string getHttpData(string url,  string uname, string pwd)
        {
            //randomException();
            Stream mtlStream = getHttpStream(url, uname, pwd);
            string completeMtl = "";
            StreamReader sr = new StreamReader(mtlStream);
            int lineno = 1;
            int fsize = 4096 * 2;
            while (true)
            {
                char[] buf = new char[fsize];
                int readcount = sr.ReadBlock(buf, 0, fsize);
                if (0 == readcount)
                {
                    break;
                }
                string readline = new string(buf, 0, readcount);
                completeMtl += readline;
                lineno++;
            }
            return completeMtl;
        }
        private void showTip(int timeout, string title, string text, ToolTipIcon icon)
        {
            TraceLine(String.Format("showTip called"));
            if (!showNotificationsToolStripMenuItem.Checked)
            {
                TraceLine("Not showing tip, notifications disabled");
                return;
            }
            if (
                (notifyTitle != title) ||
                (forceNotification)
                )
            {
                notifyTitle = title;
                notifyText = text;
                notifyIcon = icon;

                if (!isLocked)
                {
                    TraceLine("Desktop not locked, showing the balloon");
                    notifyIcon1.ShowBalloonTip(timeout, title, text, icon);
                    notifyIcon1.Text = title;
                }
                else
                {
                    TraceLine("Desktop locked, storing notification for later");
                    notifyTitle = title;
                    notifyText = text;
                    notifyIcon = icon;
                }
            }
            else
            {
                TraceLine("Repeated message, ignoring");
            }
        }

        private bool isInHomeNetwork()
        {
            bool ret = false;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface n in interfaces)
            {
                TraceLine("Interfaces found");
                if (n.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    TraceLine(String.Format("Up interface found [{0}]",n.Name));
                    IPInterfaceProperties ipi = n.GetIPProperties();
                    foreach (IPAddressInformation o in ipi.UnicastAddresses)
                    {
                        TraceLine(String.Format("Ip address found [{0}] [{1}]", n.Name, o.Address.ToString()));
                        if (o.Address.ToString().StartsWith("192.168."))
                        {
                            TraceLine("In Home Network");
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }
        private bool isHomeModemUp()
        {
            bool ret = false;
            try
            {
                getHttpData(Properties.Settings.Default.Url, Properties.Settings.Default.User,
                    Properties.Settings.Default.Password);
                ret = true;
            }
            catch { }
            TraceLine(String.Format("Modem Status [{0}]",ret));
            return ret;
        }
        private bool isConnectedToNw()
        {
            bool ret = false;
            try
            {
                getHttpData(Properties.Settings.Default.Google, "", "");
                ret = true;
            }
            catch { }
            TraceLine(String.Format("Network Status [{0}]", ret));
            return ret;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TraceLine("Timer expired");
            Hide();
            timer1.Interval = Properties.Settings.Default.UpdateInterval * 1000;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        protected override void WndProc(ref Message m)
        {
            // check for session change notifications
            if (m.Msg == SessionChangeMessage)
            {
                if (m.WParam.ToInt32() == SessionLockParam)
                    OnSessionLock();
                else if (m.WParam.ToInt32() == SessionUnlockParam)
                    OnSessionUnlock();
            }

            base.WndProc(ref m);
            return;
        }

        private void checkStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forceNotification = true;
            timer1_Tick(sender, e);
        }
        private bool forceNotification = false;

        private void showNotificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowNotifications = showNotificationsToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void updateIntervalStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = (ToolStripDropDownItem)sender;
            int interval = Convert.ToInt32((string)item.Tag);
            timer1.Interval = interval * 1000;
            Properties.Settings.Default.UpdateInterval = interval;
            Properties.Settings.Default.Save();
            TraceLine(String.Format("Interval changed {0}", Properties.Settings.Default.UpdateInterval)
                );
            updateMenu();
        }
        void TraceLine(string msg)
        {
            msg = DateTime.Now + " " + msg;
            Trace.WriteLine(msg);
        }
        private void updateMenu()
        {
            foreach (ToolStripMenuItem item in checkIntervalToolStripMenuItem.DropDownItems)
            {
                string interval = Convert.ToString(Properties.Settings.Default.UpdateInterval);
                if ((string)item.Tag == interval)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = new bool[] { isConnectedToNw(), isInHomeNetwork(), isHomeModemUp() };
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool[] res = (bool[])(e.Result);
            if (res[0])
            {
                if (res[1])
                {
                    showTip(5000, "In Home Network",
                        "You are now in home network and automatic power-supply status notifications are disabled",
                        ToolTipIcon.Info);
                }
                else if (res[2])
                {
                    showTip(10000, "Home Power Supply Available",
                        "Power supply available at your residence", ToolTipIcon.Info);
                }
                else
                {
                    showTip(10000, "Home Power Supply Interrupted",
                        "Power interruption at your residence", ToolTipIcon.Warning);
                }
            }
            else
            {
                showTip(5000, "No Network Connection",
                    "You are not connected to internet to determine the power supply status",
                    ToolTipIcon.Error);
            }
            forceNotification = false;
        }
    }
}
