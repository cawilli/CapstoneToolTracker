using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatacenterToolTracking
{
    public partial class Dashboard : Form
    {
        List<Tool> tools = new List<Tool>();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            var tools = db.GetTools(ToolNameText.Text);

            ToolsFoundListBox.DataSource = tools;
            ToolsFoundListBox.DisplayMember = "FullInfo";

        }

        private void InsertRecordButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.InsertTool(Int32.Parse(ToolIdInsText.Text), ToolNameInsText.Text, ToolTypeInsText.Text, ToolLocationInsText.Text, ToolStatusInsText.Text);

            ToolIdInsText.Text = "";
            ToolNameInsText.Text = "";
            ToolTypeInsText.Text = "";
            ToolLocationInsText.Text = "";
            ToolStatusInsText.Text = "";
        }
    }
}
