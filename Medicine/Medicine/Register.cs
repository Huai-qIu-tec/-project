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
    public partial class Register : Form
    {
        public string phone;
        public string password;
        public Register()
        {
            InitializeComponent();
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            phone = textBox_register_phone.Text;
            if (phone == "" || textBox_register_password.Text == "" || textBox_register_again_password.Text == "")
            {
                MessageBox.Show("请输入完整内容！");
            }

            Login.user_phone = phone;
            if(textBox_register_password.Text == textBox_register_again_password.Text)
            {
                password = textBox_register_again_password.Text;
            }
            else
            {
                MessageBox.Show("再次输入密码与原始密码不同！");
                textBox_register_password.Text = "";
                textBox_register_again_password.Text = "";
            }
            completeInfomation completeInfomation = new completeInfomation(phone, password);
            completeInfomation.Show();
            this.Hide();
        }
    }
}
