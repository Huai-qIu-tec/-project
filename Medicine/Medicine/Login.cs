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


namespace Medicine
{
    public partial class Login : Form
    {
        public static string user_phone;
        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string login_name = textBox_login_name.Text;
            string login_password = textBox_login_password.Text;
            string login_yanzhengma = textBox_login_yanzhengma.Text;
            if (login_name == "" || login_password == "" || login_yanzhengma == "")
            {
                MessageBox.Show("请输入完整信息！");
            }
            user_phone = login_name;
            DBConnection connection = new DBConnection();
            string sqlCmd = "select user_phone = " + login_name + ", user_password = " + login_password + " from user";
            MySqlCommand cmd = new MySqlCommand(sqlCmd, connection.connection);
            const string abcd = "ABCD";
            
            if (Convert.ToInt32(cmd.ExecuteScalar()) > 0 && (login_yanzhengma.ToUpper() == abcd))
            {
                MessageBox.Show("登录成功");
                mainForm mainorm = new mainForm();
                mainorm.Show();
                connection.connection.Close();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("用户名或密码错误！");
            }

        }

        private void label_register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
