using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicine
{
    public partial class myhome : Form
    {
        public myhome()
        {
            InitializeComponent();
        }

        private void uiLabel_username_Click(object sender, EventArgs e)
        {

        }

        private void myhome_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            mainForm form = new mainForm();
            form.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            information info = new information();
            info.Show();
            this.Hide();
        }

        private void uiLabel4_Click(object sender, EventArgs e)
        {
            MySchdule mySchdule = new MySchdule();
            mySchdule.Show();
            this.Hide();
        }

        private void uiLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
