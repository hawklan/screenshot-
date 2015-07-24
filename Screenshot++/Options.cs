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
            pbLogo.Image = Utils.GetBitmap(Screenshot__.Properties.Resources.camera_photo_2);
            //lblAbout.Text = string.Format("{0} v{1}", Settings.ProgramName, Assembly.GetExecutingAssembly().GetName().Version);
            lblAbout.Text = Assembly.GetExecutingAssembly().GetName().Name; // Redundant, but explicit in case of changes later.
            txtSavePath.Text = Settings.SavePath;
            cmbFormat.DataSource = Settings.ImageFormats;
            cmbFormat.SelectedItem = Settings.SelectedImageFormat;
            txtSavePrefix.Text = Settings.SavePrefix;

            lblQualityCurrent.Text = trackQuality.Value.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool bChanges = false;
            if (!txtSavePath.Text.Equals(Settings.SavePath))
            {
                if(txtSavePath.Text.IndexOfAny(System.IO.Path.GetInvalidPathChars()) == -1)
                {
                    Settings.SavePath = txtSavePath.Text;
                    bChanges = true;
                }
            }
            if (!txtSavePrefix.Text.Equals(Settings.SavePrefix))
            {
                if (txtSavePrefix.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1)
                {
                    Settings.SavePrefix = txtSavePrefix.Text;
                    bChanges = true;
                }
            }
            Settings.ImageFormat imgFrmt = cmbFormat.SelectedItem as Settings.ImageFormat;
            if(imgFrmt != null)
            {
                for (int i = 0; i < Settings.ImageFormats.Count; i++)
                {
                    if (Settings.ImageFormats[i].InternalFormat == imgFrmt.InternalFormat)
                    {
                        if(!Settings.ImageFormats[i].Quality.Equals(trackQuality.Value))
                        {
                            Settings.ImageFormats[i].Quality = trackQuality.Value;

                            bChanges = true;
                        }
                        break; // Only match one.
                    }
                }
            }
            //if(!trackQuality.Value.Equals(Settings.Save
            if (bChanges)
            {

                Settings.SaveSettings();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
            
            if (txtSavePath.Text.IndexOfAny(System.IO.Path.GetInvalidPathChars()) == -1)
            {
                if (System.IO.Directory.Exists(txtSavePath.Text))
                {
                    folderBrowse.SelectedPath = txtSavePath.Text;
                }
            }

            if (folderBrowse.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (folderBrowse.SelectedPath.IndexOfAny(System.IO.Path.GetInvalidPathChars()) == -1)
                {
                    txtSavePath.Text = folderBrowse.SelectedPath;
                }
            }
        }

        private void trackQuality_ValueChanged(object sender, EventArgs e)
        {
            lblQualityCurrent.Text = trackQuality.Value.ToString();
        }

        private void cmbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
