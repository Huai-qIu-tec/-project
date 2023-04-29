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
    
    public partial class 就诊人信息 : Form
    {
        public static string userName;
        private string doctorid;
        private string doctorname;
        private string keshi;
        private DateTime datetime;
        private string user_name;
        private string user_id;
        private string user_address;
        private string doctortitle;
        private string doctoredu;
        private double dexper;
        public 就诊人信息(string id, string name, string k, DateTime date, string title, string edu, double d)
        {
            doctorid = id;
            doctorname = name;
            keshi = k;
            datetime = date;
            doctortitle = title;
            doctoredu = edu;
            dexper = d;
            InitializeComponent();
            DBConnection connection = new DBConnection();
            string sql = "SELECT * FROM user WHERE user_phone ='" + Login.user_phone +"'";
            MySqlCommand cmd = new MySqlCommand(sql, connection.connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                user_name = reader["user_name"].ToString();
                user_id = reader["id_no"].ToString();
                user_address = reader["user_address"].ToString();
            }
            connection.connection.Close();

            uiLabel_name.Text = user_name;
            uiLabel_id.Text = user_id;
            uiLabel_address.Text = user_address;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            guahaoInfo guahaoInfo = new guahaoInfo(doctorid, doctorname, keshi, datetime, doctortitle, doctoredu, dexper);
            guahaoInfo.Show();
            this.Hide();
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {
            userName = uiLabel_name.Text.ToString();
            guahaoInfo guahaoInfo = new guahaoInfo(doctorid, doctorname, keshi, datetime, doctortitle, doctoredu, dexper);
            guahaoInfo.Show();
            this.Hide();
        }
    }
}
