using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace Screenshot__
{
    // http://www.simple-talk.com/dotnet/.net-framework/creating-tray-applications-in-.net-a-practical-guide/#ninth

    class NotifyApplicationContext : ApplicationContext
    {
        private NotifyIcon m_notifyIcon;
        private System.ComponentModel.IContainer m_components;

        
        public NotifyApplicationContext()
        {
            InitializeContext();
            
        }

        private void InitializeContext()
        {
            m_components = new System.ComponentModel.Container();
            m_notifyIcon = new NotifyIcon(m_components);
            m_notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            m_notifyIcon.Icon = Screenshot__.Properties.Resources.camera_photo_2;
            m_notifyIcon.Text = Assembly.GetExecutingAssembly().GetName().Name; // Redundant, but explicit in case of changes later.
            m_notifyIcon.Visible = true;
            m_notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            m_notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;

            m_notifyIcon.ContextMenuStrip.Items.Clear();
            m_notifyIcon.ContextMenuStrip.Items.Add(this.ToolStripMenuItemWithHandler("&Options", OptionsItem_Click));
            m_notifyIcon.ContextMenuStrip.Items.Add(this.ToolStripMenuItemWithHandler("&About", AboutItem_Click));
            m_notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            m_notifyIcon.ContextMenuStrip.Items.Add(this.ToolStripMenuItemWithHandler("E&xit", ExitItem_Click));
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // Do nothing for now.
        }

        private void OptionsItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void AboutItem_Click(object sender, EventArgs e)
        {
            // Replace this with a proper form later.
            MessageBox.Show(string.Format("{0} v{1} by {2}", Assembly.GetExecutingAssembly().GetName().Name, Assembly.GetExecutingAssembly().GetName().Version, "Jason Hutton"));
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            ExitThread();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && m_components != null) { m_components.Dispose(); }
            base.Dispose(disposing);
        }

        protected override void ExitThreadCore()
        {
            // Close any mainform if it's open. // if (mainForm != null) { mainForm.Close(); }
            m_notifyIcon.Visible = false;
            base.ExitThreadCore();
        }

        private ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, EventHandler eventHandler)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(displayText);
            if (eventHandler != null) { item.Click += eventHandler; }
            return item;
        }
    }
}
