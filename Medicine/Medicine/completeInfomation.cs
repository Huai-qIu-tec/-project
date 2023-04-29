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
    public partial class completeInfomation : Form
    {
        public string phone;
        public string password;
        public completeInfomation(string ph, string p)
        {
            phone = ph;
            password = p;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox_complete_name.Text;
            string id_type = comboBox_complete_idtype.Text;
            string id = textBox_complete_id.Text;
            string sex = radioButton_male.Checked ? "男" : "女";
            int birth_date_year = int.Parse(dateTimePicker.Value.ToString("yyyy"));
            int birth_date_month = int.Parse(dateTimePicker.Value.ToString("MM"));
            int birth_date_day = int.Parse(dateTimePicker.Value.ToString("dd"));
            string address = textbox_address.Text;
            if (name == "" || id_type == "" || id == "" || sex == "" || dateTimePicker.Value.ToString() == "")
            {
                MessageBox.Show("请输入完整内容！");
            }
            DBConnection connection = new DBConnection();
            string sql1 = "SELECT MAX(user_id) from user";
            MySqlCommand cmd = new MySqlCommand(sql1, connection.connection);
            object val = cmd.ExecuteScalar();
            int max_id = (int)val + 1;
            string sql2 = "insert into user(user_id, user_name, user_sex ,user_age ,user_password ,id_type ,id_no ,user_phone  ,user_address) values" +
                "('" + max_id + "','" + name + "','" + sex + "','" + (2022 - birth_date_year) + "','" + password + "','" + id_type + "','" + id + "','" + phone + "','" + address + "')";
            try
            {
                MySqlCommand cmd1 = new MySqlCommand(sql2, connection.connection);
                if (cmd1.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("注册失败");
                }
                else
                {
                    MessageBox.Show("注册成功");
                    mainForm mainform = new mainForm();
                    mainform.Show();
                    this.Hide();
                    this.Dispose();
                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
