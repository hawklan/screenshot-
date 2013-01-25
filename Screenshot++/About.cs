using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Screenshot__
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            pbLogo.Image = Utils.GetBitmap(Screenshot__.Properties.Resources.camera_photo_2);
            lblAbout.Text = Assembly.GetExecutingAssembly().GetName().Name; // Redundant, but explicit in case of changes later.
            lblVersion.Text = string.Format("Version {0}", Assembly.GetExecutingAssembly().GetName().Version);
            lblAuthor.Text = string.Format("By {0}", Settings.Author);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
