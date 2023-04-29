using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Medicine
{
    public partial class ExamiationCheck : Form
    {
        private List<string> list;
        private int index;
        private Hashtable infoHash;
        private DateTime dateTime;
        public ExamiationCheck(List<string> list, int i, DateTime dt)
        {
            InitializeComponent();
            this.list = list;
            index = i;
            dateTime = dt;
            Hashtable infoHash = new Hashtable();
            this.infoHash = infoHash;
            infoHash.Add("一般检查", "身高、体重(指数)、视力(左右眼）、辨色力、血压");
            infoHash.Add("内科检查", "呼吸频率、肺部听诊、心率/律、神经反射、肝脏/胆囊/脾脏触诊");
            infoHash.Add("外科检查", "皮肤、粘膜、浅表淋巴结、四肢活动度、足背动脉/脊柱、甲状腺、下肢浅表静脉、低位结肠、内/外/混合痔、肛裂/肛瘘");
            infoHash.Add("心电图检查", "十二导联心电图");
            infoHash.Add("胸透检查", "心、双肺、横/纵膈");
            infoHash.Add("血常规检查", "白细胞总数、淋巴细胞数目、中间细胞数目、中性粒细胞数目、淋巴细胞百分比、中间细胞百分比、中性粒细胞百分比、红细胞数目、血红蛋白、血常规检查红细胞压积、平均红细胞体积、平均红细胞血红蛋白、平均红细胞血红蛋白浓度、红细胞分布宽度变异系数、红细胞分布宽度标准差、血小板数目、平均血小板体积、血小板分布宽度、血小板压积");
            infoHash.Add("尿常规检查", "蛋白质、葡萄糖、胆红素、尿胆原、酮体、亚硝酸盐、白细胞、尿比重、尿酸碱度、红细胞、维C");
            infoHash.Add("肝功能检查", "谷丙转氨酶、谷草转氨酶");
            infoHash.Add("采血", "静脉采血（6元）");
            infoHash.Add("血常规", "全血细胞计数+五分类检测\n检查意义：可发现有无贫血、细菌感染、病毒感染、血液病等异常情况。\n");
            infoHash.Add("尿常规", "尿常规化学分析\n尿有形成分分析\n检查意义：泌尿系统疾病的辅助检查，如泌尿系统感染、结石、肾炎、肿瘤等，还可用于协助检查全身其他系统疾病，如糖尿病、高血压、肝炎等。\n");
            infoHash.Add("肝功能六项", "丙氨酸氨基转移酶（ALT）测定\n天门冬氨酸氨基转移酶（ASL）测定\n总胆红素（T-Bil）测定\n直接胆红素(D-Bil）测定\n间接胆红素\nγ-谷氨酰基转移酶（GGT）测定\n检查意义：\n检测肝脏功能，对各型肝炎、药物中毒、酒精性脂肪肝等引起的肝脏疾病有辅助诊断作用。\n");
            infoHash.Add("肾功能三项", "尿素(Urea）测定\n肌酐（Cr）测定\n尿酸（UA）测定\n检查意义：检测肾脏功能，对高血压、糖尿病、肾炎、痛风、肾结石等引起的肾脏疾病有辅助诊断作用。");
            infoHash.Add("血脂四项", "总胆固醇（TC）\n甘油三酯(TG)\n低密度脂蛋白胆固醇（10元）\n高密度脂蛋白胆固醇（HDL-C）测定（10元）\n检查意义：\n血脂异常是冠心病和缺血性脑血管病的独立危险因素，临床上分为原发性和继发性两大类，干预血脂异常是重要慢病防治的主要措施和手段。");
            infoHash.Add("空腹血糖", "葡萄糖（Glu）测定\n检查意义：用于诊断糖尿病、监测血糖控制情况。");
            infoHash.Add("超声", "肝胆胰脾彩色多普勒超声检查（114元）\n检查意义：\n检查肝、胆、胰、脾各脏器的大小、结构是否正常，有无结石、炎症、肿物等病变。\n");
            infoHash.Add("耳鼻喉", "间接喉镜检查（4元）,鼻咽镜检查（20元）\n检查意义：\n喉及喉咽部检查。鼻咽部检查。");
            infoHash.Add("健康体检", "内科、外科、妇科、眼科、口腔科、耳鼻喉科\n检查意义：\n血压、心、肺、肝、脾、神经系统等常规检查。身高、体重、甲状腺、乳腺、淋巴结、腰臀比等常规检查。妇科常规检查。外眼等常规检查。口腔卫生、牙齿及牙龈检查。\n");
            infoHash.Add("外科", "肛门指诊（5元）\n检查意义：\n	肛门直肠检查。\n");
            infoHash.Add("眼科", "	普通远视力检查（4元）色觉检查-假同色图谱法（3元）非散瞳直接检眼镜眼底检查（3元）\n检查意义：\n采用国际标准视力表对远视力进行检查。\n");
            infoHash.Add("妇科", "阴道检查（5元）人乳头瘤病毒基因分型检测（220元）\n检查意义：\n检查外阴及阴道情况。\n");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(index == 1)
            {
                jianchainfo jiancha = new jianchainfo();
                jiancha.Show();
                this.Hide();
            }
            if(index == 2)
            {
                tijianinfo tijian = new tijianinfo();
                tijian.Show();
                this.Hide();
            }
        }

        private void ExamiationCheck_Load(object sender, EventArgs e)
        {
            foreach(var item in list)
            {
                
                uiRichTextBox1.Text += "------" + item.ToString() + "------" + "\n";
                uiRichTextBox1.Font = new Font("微软雅黑", 20, FontStyle.Bold);
                
                uiRichTextBox1.Text += infoHash[item.ToString()] + "\n";
                uiRichTextBox1.Font = new Font("微软雅黑", 10, FontStyle.Regular);
                uiRichTextBox1.Text += "\n";
            }
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            DBConnection connection = new DBConnection();
            string sql1 = "SELECT MAX(examination_id) from physicalexamination";
            MySqlCommand cmd1 = new MySqlCommand(sql1, connection.connection);
            object val1 = cmd1.ExecuteScalar();
            int max_id;
            if(val1 == DBNull.Value)
            {
                max_id = 1;
            }
            else
            {
                max_id = (int)val1 + 1;
            }

            string sql2 = "SELECT user_id from user WHERE user_phone = '" + Login.user_phone + "'";
            MySqlCommand cmd2 = new MySqlCommand(sql2, connection.connection);
            object val2 = cmd2.ExecuteScalar();
            int user_id = (int)val2;

            string context = "";
            foreach (string item in list)
            {
                context += item + "、";
            }
            context = context.Substring(0, context.Length - 1);
            string sql = "INSERT INTO physicalexamination(examination_id, user_id, examination_time, context) VALUES('" + max_id + "', '" + user_id + "','" + dateTime + "','" + context + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection.connection);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("预约成功");
                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
