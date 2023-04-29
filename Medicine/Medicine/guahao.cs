using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Medicine
{
    public partial class guahao : Form
    {

        public guahao()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm();
            mainForm.Show();
            this.Hide();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Sunny.UI.UIButton b = (Sunny.UI.UIButton)sender;
            DeptDoctorList deptDoctorList = new DeptDoctorList(b.Text.ToString());
            deptDoctorList.Show();
            this.Hide();
        }

        private void uiTabControlMenu1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiButton9_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            string sql = "SELECT COUNT(*) FROM dept where dept_name = '" + uiTextBox1.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connection.connection);
            if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                MessageBox.Show("不存在该科室");
            else
            {
                DeptDoctorList deptDoctorList = new DeptDoctorList(uiTextBox1.Text.ToString());
                deptDoctorList.Show();
                this.Hide();
            }
        }
    }
}
