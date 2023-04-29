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
    public partial class DoctorInfo : Form
    {
        private string doctor_id;
        private string keshi;
        private DateTime date;
        private string doctorname;
        private string doctor_title;
        private string doctor_education;
        private double dexper;
        private string speciality_diease;
        private string speciality;
        public DoctorInfo(string Name, string k, DateTime d)
        {
            InitializeComponent();
            doctor_id = Name;
            keshi = k;
            date = d;
            
            DBConnection connection = new DBConnection();
            string sql = "SELECT doctor.doctor_name, doctor.doctor_title_level, doctor.doctor_education, doctor.dexper, doctor.speciality_diease, doctor.speciality FROM doctor WHERE doctor_id ='" + doctor_id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, connection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                doctorname = reader[0].ToString();
                doctor_title = reader[1].ToString();
                doctor_education = reader[2].ToString();
                dexper = (double)reader[3];
                speciality_diease = reader[4].ToString();
                speciality = reader[5].ToString();
            }
            uiLabel_name.Text = doctorname;
            uiLabel_title.Text = doctor_title;
            uiLabel_edu.Text = doctor_education;
            uiLabel_dexper.Text = String.Format("{0:F}", dexper);
            uiLabel_dexper.ForeColor = Color.FromArgb(255, 255, 0, 0);
            uiLabel_describe.Text = speciality;
            uiLabel_speciality.Text = speciality_diease;
            uiLabel_describe.TextAlign = ContentAlignment.TopLeft;
            uiLabel_speciality.TextAlign = ContentAlignment.TopLeft;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DeptDoctorList deptDoctorList = new DeptDoctorList(keshi);
            deptDoctorList.Show();
            this.Hide();
            this.Dispose();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            guahaoInfo guahaoInfo = new guahaoInfo(doctor_id, doctorname, keshi, date, uiLabel_title.Text.ToString(), uiLabel_edu.Text.ToString(), dexper);
            guahaoInfo.Show();
            this.Hide();
        }
    }
}
