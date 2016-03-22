using SessionManagement.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SessionManagement.Client
{
    public partial class FormSessionManagement : Form
    {
        public FormSessionManagement()
        {
            InitializeComponent();
        }

        private void FormSessionManagement_Load(object sender, EventArgs e)
        {
            this.dataGridViewSessionList.AutoGenerateColumns = false;
            this.RegisterMouseMoveEvent(this);
        }

        private void RegisterMouseMoveEvent(Control control)
        {
            control.MouseHover += delegate
            {
                SessionUtility.LastActivityTime = DateTime.Now;
            };

            foreach (Control child in control.Controls)
            {
                this.RegisterMouseMoveEvent(child);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonStartSession_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddressList = Dns.GetHostEntry(hostName).AddressList;
            string ipAddress = string.Empty;
            foreach (IPAddress address in ipAddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress += address.ToString() + ";";
                }
            }
            ipAddress = ipAddress.TrimEnd(";".ToCharArray());

            string userName = this.textBoxUserName.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                return;
            }

            SessionClientInfo clientInfo = new SessionClientInfo() { IPAddress = ipAddress, HostName = hostName, UserName = userName };
            SessionUtility.StartSession(clientInfo);
            this.groupBox2.Enabled = false;
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            IList<SessionInfo> activeSessions = SessionUtility.GetActiveSessions();
            this.dataGridViewSessionList.DataSource = activeSessions;
            foreach (DataGridViewRow row in this.dataGridViewSessionList.Rows)
            {
                Guid sessionID = (Guid)row.Cells["SessionID"].Value;
                row.Cells["IPAddress"].Value = activeSessions.Where(session => session.SessionID == sessionID).ToList<SessionInfo>()[0].ClientInfo.IPAddress;
                row.Cells["Username"].Value = activeSessions.Where(session => session.SessionID == sessionID).ToList<SessionInfo>()[0].ClientInfo.UserName;

            }

        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            IList<Guid> sessionIDs = new List<Guid>();
            foreach (DataGridViewRow row in this.dataGridViewSessionList.Rows)
            {
                if ((string)row.Cells["Select"].Value == "1")
                {
                    Guid sessionID = new Guid(row.Cells["SessionID"].Value.ToString());
                    if (sessionID == SessionUtility.SessionID)
                    {
                        MessageBox.Show("You cannot kill your current session!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sessionIDs.Add(sessionID);
                }
            }

            SessionUtility.KillSessions(sessionIDs);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dataGridViewSessionList.DataSource = SessionUtility.GetActiveSessions();
        }
    }
}
