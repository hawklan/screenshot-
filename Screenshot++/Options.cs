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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            pbLogo.Image = GetBitmap(Screenshot__.Properties.Resources.camera_photo_2);
            //lblAbout.Text = string.Format("{0} v{1}", Settings.ProgramName, Assembly.GetExecutingAssembly().GetName().Version);
            lblAbout.Text = Assembly.GetExecutingAssembly().GetName().Name; // Redundant, but explicit in case of changes later.
            txtSavePath.Text = Settings.SavePath;
            cmbFormat.DataSource = Settings.ImageFormats;
            cmbFormat.SelectedItem = Settings.SelectedImageFormat;
            txtSavePrefix.Text = Settings.FilePrefix;
        }

        private Bitmap GetBitmap(Icon icon)
        {
            Bitmap bmp = new Bitmap(icon.Width, icon.Height);
            Graphics gxMem = Graphics.FromImage(bmp);
            gxMem.DrawIcon(icon, 0, 0);
            gxMem.Dispose();

            return bmp;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
