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
    public partial class guahaoInfo : Form
    {
        private string doctorid;
        private string doctorname;
        private string keshi;
        private DateTime datetime;
        private string doctortitle;
        private string doctoredu;
        private double dexper;
        public guahaoInfo(string doc_id, string name, string k, DateTime date, string title, string edu, double d)
        {
            doctorid = doc_id;
            doctorname = name;
            keshi = k;
            datetime = date;
            doctortitle = title;
            doctoredu = edu;
            dexper = d;
            InitializeComponent();
            uiLabel_name.Text = doctorname;
            uiLabel_title.Text = doctortitle;
            uiLabel_edu.Text = doctoredu;
            uiLabel_dept.Text = "就诊科室：" + keshi;
            uiLabel_dexper.Text = "挂号费：" + String.Format("{0:F}", dexper);
            uiLabel_dexper.ForeColor = Color.FromArgb(255, 255, 0, 0);
            uiLabel_title2.Text = "门诊类型：" + doctortitle;
            uiLabel_date.Text = "门诊时间：" + datetime.ToString();
            if(就诊人信息.userName == null)
            {
                uiLabel_username.Text = "选择就诊人";
            }
            else
            {
                uiLabel_username.Text = 就诊人信息.userName;
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {


            DBConnection connection = new DBConnection();
            string sql1 = "SELECT MAX(order_id) from orderinfo";
            MySqlCommand cmd1 = new MySqlCommand(sql1, connection.connection);
            object val1 = cmd1.ExecuteScalar();
            int max_id = (int)val1 + 1;

            string sql2 = "SELECT dept_id FROM dept WHERE dept_name = '" + keshi + "'";
            MySqlCommand cmd2 = new MySqlCommand(sql2, connection.connection);
            object val2 = cmd2.ExecuteScalar();
            int dept_id = (int)val2;

            string sql3 = "SELECT user_id FROM user WHERE user_phone = '" + Login.user_phone + "'";
            MySqlCommand cmd3 = new MySqlCommand(sql3, connection.connection);
            object val3 = cmd3.ExecuteScalar();
            int user_id = (int)val3;

            string sql_hasorder = "SELECT 1 FROM orderinfo WHERE user_id = '" + user_id + "' AND order_time = '" + datetime + "' limit 1;";
            try
            {
                MySqlCommand cmd_hasorder = new MySqlCommand(sql_hasorder, connection.connection);
                
                if (cmd_hasorder.ExecuteScalar() != null)
                {
                    MessageBox.Show("已预约该时间段, 请取消该时间段预约");
                }
                else
                {
                    string sql = "INSERT INTO orderinfo(order_id, dept_id, doctor_id, user_id, order_time, order_status) VALUES ('" + max_id + "','" + dept_id + "','" + doctorid + "','" + user_id + "','" + datetime + "', 1)";
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(sql, connection.connection);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("预约失败");
                        }
                        else
                        {
                            string sql_update = "UPDATE appointment SET num_of_appointment = num_of_appointment+1 WHERE doctor_id = '" + doctorid + "' AND date_of_work ='" + datetime + "'";
                            try
                            {
                                MySqlCommand cmd_update = new MySqlCommand(sql_update, connection.connection);
                                if (cmd_update.ExecuteNonQuery() == 0)
                                    MessageBox.Show("失败");
                                else
                                {
                                    Congrations congrations = new Congrations();
                                    congrations.Show();
                                    this.Hide();
                                }
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DoctorInfo doctorInfo = new DoctorInfo(doctorid, keshi, datetime);
            doctorInfo.Show();
            this.Hide();
        }

        private void uiLabel11_Click(object sender, EventArgs e)
        {
            就诊人信息 userinfo = new 就诊人信息(doctorid, doctorname, keshi, datetime, doctortitle, doctoredu, dexper);
            userinfo.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DoctorInfo doctorInfo = new DoctorInfo(doctorid, keshi, datetime);
            doctorInfo.Show();
            this.Hide();
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (uiCheckBox1.Checked)
                uiCheckBox2.Checked = false;
            else
                uiCheckBox2.Checked = true;
        }

        private void uiCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (uiCheckBox2.Checked)
                uiCheckBox1.Checked = false;
            else
                uiCheckBox1.Checked = true;
        }

        private void uiCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(uiCheckBox4.Checked)
            {
                uiCheckBox3.Checked = false;
                uiCheckBox5.Checked = false;
            }
        }

        private void uiCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (uiCheckBox3.Checked)
            {
                uiCheckBox4.Checked = false;
                uiCheckBox5.Checked = false;
            }
        }

        private void uiCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (uiCheckBox5.Checked)
            {
                uiCheckBox3.Checked = false;
                uiCheckBox4.Checked = false;
            }
        }
    }
}
