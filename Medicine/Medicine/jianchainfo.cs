using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Medicine
{
    public partial class jianchainfo : Form
    {

        public jianchainfo()
        {
            InitializeComponent();
            
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach(var item in jiancha_Transfer.ItemsRight)
            {
                list.Add(item.ToString());
            }
            DateTime dateTime = new DateTime();
            dateTime = uiDatetimePicker1.Value;
            ExamiationCheck examiationCheck = new ExamiationCheck(list, 1, dateTime);
            examiationCheck.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainForm form = new mainForm();
            form.Show();
            this.Hide();
        }
    }
}
