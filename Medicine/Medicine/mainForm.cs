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
    public partial class mainForm : Form
    {
        private int imageIndex = 0;
        private Timer Timer = new Timer();
        private List<Image> images = new List<Image>();
        public mainForm()
        {
            InitializeComponent();
            images.Add(Image.FromFile("D:\\学习\\医院信息系统\\课程设计\\img\\主页面滑动图片1.png"));
            images.Add(Image.FromFile("D:\\学习\\医院信息系统\\课程设计\\img\\主页面滑动图片2.png"));
            images.Add(Image.FromFile("D:\\学习\\医院信息系统\\课程设计\\img\\主页面滑动图片3.png"));
            timer1.Interval = 2000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox_main.Image = images[imageIndex];
            imageIndex = (imageIndex + 1) % 3;
        }

        private void guahao_Click(object sender, EventArgs e)
        {
            guahao guahao = new guahao();
            guahao.Show();
            this.Hide();
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MySchdule mySchdule = new MySchdule();
            mySchdule.Show();
            this.Hide();
        }

        private void jiancha_Click(object sender, EventArgs e)
        {
            jianchainfo jiancha = new jianchainfo();
            jiancha.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tijianinfo tijian = new tijianinfo();
            tijian.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            information info = new information();
            info.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            myhome home = new myhome();
            home.Show();
            this.Hide();
        }
    }
}
