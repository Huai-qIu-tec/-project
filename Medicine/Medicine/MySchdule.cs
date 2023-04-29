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
    public partial class MySchdule : Form
    {
        private List<Sunny.UI.UICheckBox> checkBoxes;
        private List<Label> worktime;
        private List<Label> name;
        public MySchdule()
        {
            InitializeComponent();
            uiPanel1.Visible = false;
            uiPanel2.Visible = false;
            uiPanel3.Visible = false;
            uiPanel4.Visible = false;
            uiPanel5.Visible = false;
            uiPanel6.Visible = false;
            checkBoxes = new List<Sunny.UI.UICheckBox>();
            checkBoxes.Add(CheckBox_deleteorder_1);
            checkBoxes.Add(CheckBox_deleteorder_2);
            checkBoxes.Add(CheckBox_deleteorder_3);
            checkBoxes.Add(CheckBox_deleteorder_4);
            checkBoxes.Add(CheckBox_deleteorder_5);
            checkBoxes.Add(CheckBox_deleteorder_6);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainForm form = new mainForm();
            form.Show();
            this.Hide();
            this.Dispose();
        }

        private void MySchdule_Load(object sender, EventArgs e)
        {
            List<Sunny.UI.UIPanel> panel = new List<Sunny.UI.UIPanel>();
            panel.Add(uiPanel1);
            panel.Add(uiPanel2);
            panel.Add(uiPanel3);
            panel.Add(uiPanel4);
            panel.Add(uiPanel5);
            panel.Add(uiPanel6);

            List<Label> name = new List<Label>();
            this.name = name;
            name.Add(label_name_1);
            name.Add(label_name_2);
            name.Add(label_name_3);
            name.Add(label_name_4);
            name.Add(label_name_5);
            name.Add(label_name_6);

            List<Label> title = new List<Label>();
            title.Add(label_title_1);
            title.Add(label_title_2);
            title.Add(label_title_3);
            title.Add(label_title_4);
            title.Add(label_title_5);
            title.Add(label_title_6);

            List<Label> speciality = new List<Label>();
            speciality.Add(label_speciality_1);
            speciality.Add(label_speciality_2);
            speciality.Add(label_speciality_3);
            speciality.Add(label_speciality_4);
            speciality.Add(label_speciality_5);
            speciality.Add(label_speciality_6);

            List<Label>  worktime = new List<Label>();
            this.worktime = worktime;
            worktime.Add(label_worktime_1);
            worktime.Add(label_worktime_2);
            worktime.Add(label_worktime_3);
            worktime.Add(label_worktime_4);
            worktime.Add(label_worktime_5);
            worktime.Add(label_worktime_6);

            List<Label> dept = new List<Label>();
            dept.Add(label_dept_1);
            dept.Add(label_dept_2);
            dept.Add(label_dept_3);
            dept.Add(label_dept_4);
            dept.Add(label_dept_5);
            dept.Add(label_dept_6);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("1", "心内科");
            hashtable.Add("2", "高血压科");
            hashtable.Add("3", "消化科");
            hashtable.Add("4", "内分泌科");
            hashtable.Add("5", "皮肤科");

            DBConnection connection = new DBConnection();
            string sql = "SELECT  * FROM (SELECT * FROM orderinfo INNER JOIN doctor USING(doctor_id)) as temp WHERE user_id in (SELECT user_id FROM user WHERE user_phone = '" + Login.user_phone + "')";
            MySqlCommand cmd = new MySqlCommand(sql, connection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<List<string>> list = new List<List<string>>();
            while(reader.Read())
            {
                List<string> temp = new List<string>();
                temp.Add(reader["doctor_name"].ToString());
                temp.Add(reader["doctor_title_level"].ToString());
                temp.Add(hashtable[reader["dept_id"].ToString()].ToString());
                temp.Add(reader["speciality_diease"].ToString());
                temp.Add(reader["order_time"].ToString());
                list.Add(temp);
            }
            connection.connection.Close();
            for(int i = 0; i < list.Count(); ++i)
            {
                panel[i].Visible = true;
                name[i].Text = list[i][0];
                title[i].Text = list[i][1];
                dept[i].Text = list[i][2];
                speciality[i].Text = list[i][3];
                worktime[i].Text = list[i][4];
            }
            connection.connection.Open();
            string sql_check = "SELECT * FROM physicalexamination WHERE user_id in (SELECT user_id FROM user where user_phone = '" + Login.user_phone + "')";
            MySqlCommand cmd_check = new MySqlCommand(sql_check, connection.connection);
            MySqlDataReader reader_check = cmd_check.ExecuteReader();
            List<List<string>> list_check = new List<List<string>>();
            while (reader_check.Read())
            {
                List<string> temp = new List<string>();
                temp.Add(reader_check[2].ToString());
                temp.Add(reader_check[3].ToString());
                list_check.Add(temp);
            }
            connection.connection.Close();
            int index = 0;
            for (int i = list.Count(); i < list.Count()+list_check.Count(); ++i, ++index)
            {
                panel[i].Visible = true;
                name[i].Text = "检查体检预约";
                name[i].AutoSize = true;
                title[i].Visible = false;
                dept[i].Visible = false;
                speciality[i].Text = list_check[index][1];
                worktime[i].Text = list_check[index][0];

            }

        }

        private void CheckBox_deleteorder_CheckedChanged(object sender, EventArgs e)
        {
            Sunny.UI.UICheckBox uICheckBox = (Sunny.UI.UICheckBox)sender;
            string check_name = uICheckBox.Name.Substring(21, 1);
            string work_time = worktime[int.Parse(check_name) - 1].Text;
            string doctor_name = name[int.Parse(check_name) - 1].Text;
            if(MessageBox.Show("是否确定取消预约？", "取消预约", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBConnection connection = new DBConnection();
                string sql = "DELETE FROM orderinfo WHERE  order_time = '" + work_time + "' AND user_id in ( SELECT user_id FROM user WHERE user_phone = '" + Login.user_phone + "')";
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection.connection);
                    int val = cmd.ExecuteNonQuery();
                    if(val == 1)
                    {
                        connection.connection.Close();
                        connection.connection.Open();
                        string sql1 = "UPDATE appointment SET num_of_appointment = num_of_appointment-1 WHERE date_of_work = '" + work_time + "' AND doctor_id in ( SELECT doctor_id FROM doctor WHERE doctor_name = '" + doctor_name + "')";
                        try
                        {
                            MySqlCommand cmd1 = new MySqlCommand(sql1, connection.connection);
                            int val1 = cmd1.ExecuteNonQuery();
                            if (val1 == 1)
                            {
                                MessageBox.Show("删除预约成功！");
                                MySchdule mySchdule = new MySchdule();
                                this.Hide();
                                mySchdule.Show();
                                this.Dispose();
                            }

                        }catch(MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        string sql2 = "DELETE FROM physicalexamination WHERE examination_time = '" + work_time + "'";
                        try
                        {
                            MySqlCommand cmd2 = new MySqlCommand(sql2, connection.connection);
                            int val2 = cmd2.ExecuteNonQuery();
                            MessageBox.Show("删除预约成功！");
                            MySchdule mySchdule = new MySchdule();
                            this.Hide();
                            mySchdule.Show();
                            this.Dispose();
                        }
                        catch(MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        
                    }
                }catch(MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                uICheckBox.Checked = false;
            }
        }
    }
}
