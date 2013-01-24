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
            m_notifyIcon = new NotifyIcon(m_components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = Icon.ExtractAssociatedIcon("C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe"), // new Icon()
                Text = "Default tooltip",
                Visible = true,
            };
            m_notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            m_notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;

            m_notifyIcon.ContextMenuStrip.Items.Clear();
            m_notifyIcon.ContextMenuStrip.Items.Add(this.ToolStripMenuItemWithHandler("&Options", OptionsItem_Click));
            m_notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            m_notifyIcon.ContextMenuStrip.Items.Add(this.ToolStripMenuItemWithHandler("E&xit", ExitItem_Click));
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // Do nothing for now.
        }

        private void OptionsItem_Click(object sender, EventArgs e)
        {
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
