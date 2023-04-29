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
    public partial class DeptDoctorList : Form
    {
        private string keshi;
        private DateTime date_order;
        private DateTime date;
        public Hashtable hashtable = new Hashtable();
        public Hashtable hashtable_ordertime = new Hashtable();
        public Hashtable hashtable_time = new Hashtable();
        public Hashtable hashtable_time_ordertime = new Hashtable();
        public DeptDoctorList(string str)
        {
            InitializeComponent();
            keshi = str;
            label1.Text = str;
            List<List<string>> list = new List<List<string>>();
            List<List<string>> list2 = new List<List<string>>();
            List<Sunny.UI.UIPanel> panel = new List<Sunny.UI.UIPanel>();
            panel.Add(uiPanel2);
            panel.Add(uiPanel3);
            panel.Add(uiPanel4);
            panel.Add(uiPanel5);
            panel.Add(uiPanel6);
            panel.Add(uiPanel7);

            List<Label> label_name = new List<Label>();
            label_name.Add(label_name_2);
            label_name.Add(label_name_3);
            label_name.Add(label_name_4);
            label_name.Add(label_name_5);
            label_name.Add(label_name_6);
            label_name.Add(label_name_7);

            List<Label> label_title = new List<Label>();
            label_title.Add(label_title_2);
            label_title.Add(label_title_3);
            label_title.Add(label_title_4);
            label_title.Add(label_title_5);
            label_title.Add(label_title_6);
            label_title.Add(label_title_7);

            List<Label> label_speciality = new List<Label>();
            label_speciality.Add(label_speciality_2);
            label_speciality.Add(label_speciality_3);
            label_speciality.Add(label_speciality_4);
            label_speciality.Add(label_speciality_5);
            label_speciality.Add(label_speciality_6);
            label_speciality.Add(label_speciality_7);

            List<Label> label_order = new List<Label>();
            label_order.Add(label_ordernum_2);
            label_order.Add(label_ordernum_3);
            label_order.Add(label_ordernum_4);
            label_order.Add(label_ordernum_5);
            label_order.Add(label_ordernum_6);
            label_order.Add(label_ordernum_7);

            List<Label> dateTimes = new List<Label>();
            dateTimes.Add(label_worktime_2);
            dateTimes.Add(label_worktime_3);
            dateTimes.Add(label_worktime_4);
            dateTimes.Add(label_worktime_5);
            dateTimes.Add(label_worktime_6);
            dateTimes.Add(label_worktime_7);

            List<Sunny.UI.UIButton> uiButton = new List<Sunny.UI.UIButton>();
            uiButton.Add(uiButton2);
            uiButton.Add(uiButton3);
            uiButton.Add(uiButton4);
            uiButton.Add(uiButton5);
            uiButton.Add(uiButton6);
            uiButton.Add(uiButton_7);

            /*
             * 这一段表示按医生科室查询医生，能跑，不再动了
             */
            try
            {
                // 查询医生的基本信息
                DBConnection connection = new DBConnection();
                string sql1 = "SELECT doctor_id, doctor_name, doctor_title_level, speciality_diease from doctor where dept_code in (SELECT dept_id from dept where dept_name = '" + str + "') ORDER BY doctor_id";
                MySqlCommand cmd = new MySqlCommand(sql1, connection.connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    List<string> ls = new List<string>();
                    for (int i = 0; i <= 3; ++i)
                    {
                        ls.Add(reader[i].ToString());
                    }
                    list.Add(ls);
                }
                connection.connection.Close();

                // 查询时间、预约情况
                DBConnection connection1 = new DBConnection();
                string sql2 = "SELECT doctor_id, date_of_work, max_of_appointment, num_of_appointment, doctor_status from appointment where doctor_id in (SELECT doctor_id from doctor where dept_code in (SELECT dept_id from dept where dept_name = '" + str + "')) ORDER BY doctor_id";
                MySqlCommand cmd2 = new MySqlCommand(sql2, connection1.connection);
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                int count2 = 0;
                while (reader2.Read())
                {
                    count2++;
                    List<string> ls = new List<string>();
                    for (int i = 0; i <= 3; ++i)
                    {
                        ls.Add(reader2[i].ToString());
                    }
                    list2.Add(ls);
                }
                connection.connection.Close();

                for (int i = 0; i < count2; i++)
                {
                    dateTimes[i].Text = list2[i][1].ToString();
                    label_order[i].Text = "剩" + ((int.Parse(list2[i][2].ToString()) - int.Parse(list2[i][3].ToString())) > 0 ? (int.Parse(list2[i][2].ToString()) - int.Parse(list2[i][3].ToString())) : 0).ToString() + "名";
                    if (int.Parse(list2[i][2].ToString()) - int.Parse(list2[i][3].ToString()) <= 0)
                    {
                        uiButton[i].Text = "已满";
                        uiButton[i].FillColor = Color.FromArgb(109, 109, 103);
                        uiButton[i].RectColor = Color.FromArgb(109, 109, 103);
                        hashtable.Add(uiButton[i].Name.ToString(), list2[i][0].ToString());
                        hashtable_ordertime.Add(uiButton[i].Name.ToString(), list2[i][1].ToString());
                    }
                    else
                    {
                        hashtable.Add(uiButton[i].Name.ToString(), list2[i][0].ToString());
                        hashtable_ordertime.Add(uiButton[i].Name.ToString(), list2[i][1].ToString());
                    }
                    panel[i].Visible = true;
                }
                for (int i = 0, j = 0; i < count2 && j < count; i++, j++)
                {
                    if (i > 0)
                    {
                        if (list2[i][0] == list[j - 1][0])
                        {
                            label_name[i].Text = list[j - 1][1].ToString();
                            label_title[i].Text = list[j - 1][2].ToString();
                            label_speciality[i].Text = list[j - 1][3].ToString();
                            
                            j--;
                        }
                        else
                        {
                            label_name[i].Text = list[j][1].ToString();
                            label_title[i].Text = list[j][2].ToString();
                            label_speciality[i].Text = list[j][3].ToString();
                            
                        }
                    }
                    else
                    {
                        label_name[i].Text = list[i][1].ToString();
                        label_title[i].Text = list[i][2].ToString();
                        label_speciality[i].Text = list[i][3].ToString();
                        
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


            /*
             * 用来按照时间查询、挂号医生
             * 能跑了， 不再动它
             */
            date = new DateTime(2022, 5, 8);
            List<List<string>> list_time = new List<List<string>>();
            List<List<string>> list_time2 = new List<List<string>>();
            List<Sunny.UI.UIPanel> panel_time = new List<Sunny.UI.UIPanel>();
            panel_time.Add(uiPaneltime1);
            panel_time.Add(uiPaneltime2);
            panel_time.Add(uiPaneltime3);
            panel_time.Add(uiPaneltime4);
            panel_time.Add(uiPaneltime5);

            List<Label> label_name_time = new List<Label>();
            label_name_time.Add(label_name_time1);
            label_name_time.Add(label_name_time2);
            label_name_time.Add(label_name_time3);
            label_name_time.Add(label_name_time4);
            label_name_time.Add(label_name_time5);

            List<Label> label_title_time = new List<Label>();
            label_title_time.Add(label_title_time1);
            label_title_time.Add(label_title_time2);
            label_title_time.Add(label_title_time3);
            label_title_time.Add(label_title_time4);
            label_title_time.Add(label_title_time5);

            List<Label> label_speciality_time = new List<Label>();
            label_speciality_time.Add(label_speciality_time1);
            label_speciality_time.Add(label_speciality_time2);
            label_speciality_time.Add(label_speciality_time3);
            label_speciality_time.Add(label_speciality_time4);
            label_speciality_time.Add(label_speciality_time5);

            List<Label> label_order_time = new List<Label>();
            label_order_time.Add(label_ordernum_time1);
            label_order_time.Add(label_ordernum_time2);
            label_order_time.Add(label_ordernum_time3);
            label_order_time.Add(label_ordernum_time4);
            label_order_time.Add(label_ordernum_time5);

            List<Label> dateTimes_time = new List<Label>();
            dateTimes_time.Add(label_time1);
            dateTimes_time.Add(label_time2);
            dateTimes_time.Add(label_time3);
            dateTimes_time.Add(label_time4);
            dateTimes_time.Add(label_time5);

            List<Sunny.UI.UIButton> uIButtons_time = new List<Sunny.UI.UIButton>();
            uIButtons_time.Add(uiButton_time1);
            uIButtons_time.Add(uiButton_time2);
            uIButtons_time.Add(uiButton_time3);
            uIButtons_time.Add(uiButton_time4);
            uIButtons_time.Add(uiButton_time5);

            try
            {
                // 查询医生的基本信息
                DBConnection connection_time1 = new DBConnection();
                string sql_time1 = "SELECT * FROM doctor WHERE doctor_id in (SELECT doctor_id from appointment WHERE appointment.date_of_work BETWEEN '"+ date.ToString() + "' and '" + date.AddDays(1).ToString() +"') AND doctor_id in (SELECT doctor_id FROM doctor WHERE dept_code in (SELECT dept_id from dept where dept_name = '" + str + "'))";
                MySqlCommand cmd_time1 = new MySqlCommand(sql_time1, connection_time1.connection);
                MySqlDataReader reader_time = cmd_time1.ExecuteReader();
                int count_time1 = 0;
                while (reader_time.Read())
                {
                    count_time1++;
                    List<string> ls = new List<string>();
                    ls.Add(reader_time[0].ToString());
                    ls.Add(reader_time[2].ToString());
                    ls.Add(reader_time[8].ToString());
                    ls.Add(reader_time[10].ToString());
                    list_time.Add(ls);
                }
                connection_time1.connection.Close();


                DBConnection connection_time2 = new DBConnection();
                string sql_time2 = "SELECT * FROM(SELECT * FROM appointment WHERE doctor_id in (SELECT doctor_id from appointment WHERE appointment.date_of_work BETWEEN '"+ date.ToString() + "' and '" + date.AddDays(1).ToString() + "')   AND appointment.date_of_work BETWEEN '"+ date.ToString()  + "' and '" + date.AddDays(1).ToString() + "') as temp WHERE doctor_id in (SELECT doctor_id FROM doctor WHERE dept_code in (SELECT dept_id from dept where dept_name ='" + str + "'))";
                MySqlCommand cmd_time2 = new MySqlCommand(sql_time2, connection_time2.connection);
                MySqlDataReader reader_time2 = cmd_time2.ExecuteReader();
                int count_time2 = 0;
                while (reader_time2.Read())
                {
                    count_time2++;
                    List<string> ls = new List<string>();
                    ls.Add(reader_time2[1].ToString());
                    ls.Add(reader_time2[2].ToString());
                    ls.Add(reader_time2[3].ToString());
                    ls.Add(reader_time2[4].ToString());
                    
                    list_time2.Add(ls);
                }
                connection_time2.connection.Close();

                for (int i = 0; i < count_time2; i++)
                {
                    dateTimes_time[i].Text = list_time2[i][1].ToString();
                    label_order_time[i].Text = "剩" + ((int.Parse(list_time2[i][2].ToString()) - int.Parse(list_time2[i][3].ToString())) > 0 ? (int.Parse(list_time2[i][2].ToString()) - int.Parse(list_time2[i][3].ToString())) : 0).ToString() + "名";
                    if (int.Parse(list_time2[i][2].ToString()) - int.Parse(list_time2[i][3].ToString()) <= 0)
                    {
                        uIButtons_time[i].Text = "已满";
                        uIButtons_time[i].FillColor = Color.FromArgb(109, 109, 103);
                        uIButtons_time[i].RectColor = Color.FromArgb(109, 109, 103);
                        hashtable_time.Add(uIButtons_time[i].Name.ToString(), list_time2[i][0].ToString());
                        hashtable_time_ordertime.Add(uIButtons_time[i].Name.ToString(), list_time2[i][1].ToString());
                    }
                    else
                    {
                        hashtable_time.Add(uIButtons_time[i].Name.ToString(), list_time2[i][0].ToString());
                        hashtable_time_ordertime.Add(uIButtons_time[i].Name.ToString(), list_time2[i][1].ToString());
                    }
                    panel_time[i].Visible = true;
                }
                for (int i = 0, j = 0; i < count_time2 && j < count_time1; i++, j++)
                {
                    if (i > 0)
                    {
                        if (list_time2[i][0] == list_time[j - 1][0])
                        {
                            label_name_time[i].Text = list_time[j - 1][1].ToString();
                            label_title_time[i].Text = list_time[j - 1][2].ToString();
                            label_speciality_time[i].Text = list_time[j - 1][3].ToString();
                            j--;
                        }
                        else
                        {
                            label_name_time[i].Text = list_time[j][1].ToString();
                            label_title_time[i].Text = list_time[j][2].ToString();
                            label_speciality_time[i].Text = list_time[j][3].ToString();
                        }
                    }
                    else
                    {
                        label_name_time[i].Text = list_time[i][1].ToString();
                        label_title_time[i].Text = list_time[i][2].ToString();
                        label_speciality_time[i].Text = list_time[i][3].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeptDoctorList_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            guahao guahao = new guahao();
            guahao.Show();
            this.Hide();
            this.Dispose();
        }

        private void uiDatePicker1_ValueChanged(object sender, DateTime value)
        {
            date = uiDatePicker1.Value.Date;
            hashtable.Clear();
            uiPaneltime1.Visible = false;
            uiPaneltime2.Visible = false;
            uiPaneltime3.Visible = false;
            uiPaneltime4.Visible = false;
            uiPaneltime5.Visible = false;
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {
            List<List<string>> list_time = new List<List<string>>();
            List<List<string>> list_time2 = new List<List<string>>();
            List<Sunny.UI.UIPanel> panel_time = new List<Sunny.UI.UIPanel>();
            Hashtable hashtable_time2 = new Hashtable();
            Hashtable hashtable_time_ordertime = new Hashtable();
            panel_time.Add(uiPaneltime1);
            panel_time.Add(uiPaneltime2);
            panel_time.Add(uiPaneltime3);
            panel_time.Add(uiPaneltime4);
            panel_time.Add(uiPaneltime5);

            List<Label> label_name_time = new List<Label>();
            label_name_time.Add(label_name_time1);
            label_name_time.Add(label_name_time2);
            label_name_time.Add(label_name_time3);
            label_name_time.Add(label_name_time4);
            label_name_time.Add(label_name_time5);

            List<Label> label_title_time = new List<Label>();
            label_title_time.Add(label_title_time1);
            label_title_time.Add(label_title_time2);
            label_title_time.Add(label_title_time3);
            label_title_time.Add(label_title_time4);
            label_title_time.Add(label_title_time5);

            List<Label> label_speciality_time = new List<Label>();
            label_speciality_time.Add(label_speciality_time1);
            label_speciality_time.Add(label_speciality_time2);
            label_speciality_time.Add(label_speciality_time3);
            label_speciality_time.Add(label_speciality_time4);
            label_speciality_time.Add(label_speciality_time5);

            List<Label> label_order_time = new List<Label>();
            label_order_time.Add(label_ordernum_time1);
            label_order_time.Add(label_ordernum_time2);
            label_order_time.Add(label_ordernum_time3);
            label_order_time.Add(label_ordernum_time4);
            label_order_time.Add(label_ordernum_time5);

            List<Label> dateTimes_time = new List<Label>();
            dateTimes_time.Add(label_time1);
            dateTimes_time.Add(label_time2);
            dateTimes_time.Add(label_time3);
            dateTimes_time.Add(label_time4);
            dateTimes_time.Add(label_time5);

            List<Sunny.UI.UIButton> uIButtons_time = new List<Sunny.UI.UIButton>();
            uIButtons_time.Add(uiButton_time1);
            uIButtons_time.Add(uiButton_time2);
            uIButtons_time.Add(uiButton_time3);
            uIButtons_time.Add(uiButton_time4);
            uIButtons_time.Add(uiButton_time5);

            try
            {
                // 查询医生的基本信息
                DBConnection connection_time1 = new DBConnection();
                string sql_time1 = "SELECT * FROM doctor WHERE doctor_id in (SELECT doctor_id from appointment WHERE appointment.date_of_work BETWEEN '" + date.ToString() + "' and '" + date.AddDays(1).ToString() + "') AND doctor_id in (SELECT doctor_id FROM doctor WHERE dept_code in (SELECT dept_id from dept where dept_name = '" + keshi + "'))";
                MySqlCommand cmd_time1 = new MySqlCommand(sql_time1, connection_time1.connection);
                MySqlDataReader reader_time = cmd_time1.ExecuteReader();
                int count_time1 = 0;
                while (reader_time.Read())
                {
                    count_time1++;
                    List<string> ls = new List<string>();
                    ls.Add(reader_time[1].ToString());
                    ls.Add(reader_time[2].ToString());
                    ls.Add(reader_time[8].ToString());
                    ls.Add(reader_time[10].ToString());
                    list_time.Add(ls);
                }
                connection_time1.connection.Close();


                DBConnection connection_time2 = new DBConnection();
                string sql_time2 = "SELECT * FROM(SELECT * FROM appointment WHERE doctor_id in (SELECT doctor_id from appointment WHERE appointment.date_of_work BETWEEN '" + date.ToString() + "' and '" + date.AddDays(1).ToString() + "')   AND appointment.date_of_work BETWEEN '" + date.ToString() + "' and '" + date.AddDays(1).ToString() + "') as temp WHERE doctor_id in (SELECT doctor_id FROM doctor WHERE dept_code in (SELECT dept_id from dept where dept_name ='" + keshi + "'))";
                MySqlCommand cmd_time2 = new MySqlCommand(sql_time2, connection_time2.connection);
                MySqlDataReader reader_time2 = cmd_time2.ExecuteReader();
                int count_time2 = 0;
                while (reader_time2.Read())
                {
                    count_time2++;
                    List<string> ls = new List<string>();
                    ls.Add(reader_time2[1].ToString());
                    ls.Add(reader_time2[2].ToString());
                    ls.Add(reader_time2[3].ToString());
                    ls.Add(reader_time2[4].ToString());

                    list_time2.Add(ls);
                }
                connection_time2.connection.Close();
                for (int i = 0; i < count_time2; i++)
                {
                    dateTimes_time[i].Text = list_time2[i][1].ToString();
                    label_order_time[i].Text = "剩" + ((int.Parse(list_time2[i][2].ToString()) - int.Parse(list_time2[i][3].ToString())) > 0 ? (int.Parse(list_time2[i][2].ToString()) - int.Parse(list_time2[i][3].ToString())) : 0).ToString() + "名";
                    if (int.Parse(list_time2[i][2].ToString()) - int.Parse(list_time2[i][3].ToString()) <= 0)
                    {
                        uIButtons_time[i].Text = "已满";
                        uIButtons_time[i].FillColor = Color.FromArgb(109, 109, 103);
                        uIButtons_time[i].RectColor = Color.FromArgb(109, 109, 103);
                        hashtable_time2.Add(uIButtons_time[i].Name.ToString(), list_time2[i][0].ToString());
                        hashtable_time_ordertime.Add(uIButtons_time[i].Name.ToString(), list_time2[i][1].ToString());

                    }
                    else
                    {
                        hashtable_time2.Add(uIButtons_time[i].Name.ToString(), list_time2[i][0].ToString());
                        hashtable_time_ordertime.Add(uIButtons_time[i].Name.ToString(), list_time2[i][1].ToString());
                    }
                    panel_time[i].Visible = true;
                }
                for (int i = 0, j = 0; i < count_time2 && j < count_time1; i++, j++)
                {
                    if (i > 0)
                    {
                        if (list_time2[i][0] == list_time[j - 1][0])
                        {
                            label_name_time[i].Text = list_time[j - 1][1].ToString();
                            label_title_time[i].Text = list_time[j - 1][2].ToString();
                            label_speciality_time[i].Text = list_time[j - 1][3].ToString();
                        }
                        else
                        {
                            label_name_time[i].Text = list_time[j - 1][1].ToString();
                            label_title_time[i].Text = list_time[j - 1][2].ToString();
                            label_speciality_time[i].Text = list_time[j - 1][3].ToString();
                        }
                    }
                    else
                    {
                        label_name_time[i].Text = list_time[i][1].ToString();
                        label_title_time[i].Text = list_time[i][1].ToString();
                        label_speciality_time[i].Text = list_time[i][2].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Button_click(object sender, EventArgs e)
        {
            Sunny.UI.UIButton b = (Sunny.UI.UIButton)sender;
            if (b.Text == "已满")
                MessageBox.Show("预约已满");
            else
            {
                string doctor_id = (string)hashtable[b.Name.ToString()];
                date_order = Convert.ToDateTime((string)hashtable_ordertime[b.Name.ToString()]);
                DoctorInfo doctorInfo = new DoctorInfo(doctor_id, keshi, date_order);
                doctorInfo.Show();
                this.Hide();
            }
        }
        private void Button_click2(object sender, EventArgs e)
        {
            Sunny.UI.UIButton b = (Sunny.UI.UIButton)sender;
            if (b.Text == "已满")
                MessageBox.Show("预约已满");
            else
            {
                string doctor_id = (string)hashtable_time[b.Name.ToString()];
                date_order = Convert.ToDateTime((string)hashtable_time_ordertime[b.Name.ToString()]);
                DoctorInfo doctorInfo = new DoctorInfo(doctor_id, keshi, date_order);
                doctorInfo.Show();
                this.Hide();
            }
        }
    }
}
