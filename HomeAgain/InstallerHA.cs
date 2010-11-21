using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Windows.Forms;

namespace HomeAgain
{
    [RunInstaller(true)]
    public partial class InstallerHA : Installer
    {
        public InstallerHA()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            foreach (string s in stateSaver.Keys)
            {
                MessageBox.Show(s);
            }

        }
    }
}
