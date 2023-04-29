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

namespace Medicine
{
    public partial class tijianinfo : Form
    {
        private Hashtable infoHash;
        private List<string> list;
        private DateTime dateTime;
        private int index;
        public tijianinfo()
        {
            InitializeComponent();
            Hashtable hashtable = new Hashtable();
            infoHash = hashtable;
            index = 0;
            hashtable.Add("采血", "静脉采血（6元）");
            hashtable.Add("血常规", "全血细胞计数+五分类检测(20元）\n\n检查意义：\n可发现有无贫血、细菌感染、病毒感染、血液病等异常情况。\n");
            hashtable.Add("尿常规", "尿常规化学分析（6元)\n尿有形成分分析（20元）\n\n检查意义：\n泌尿系统疾病的辅助检查，如泌尿系统感染、结石、肾炎、肿瘤等，还可用于协助检查全身其他系统疾病，如糖尿病、高血压、肝炎等。\n");
            hashtable.Add("肝功能六项", "丙氨酸氨基转移酶（ALT）测定（4.5元\n天门冬氨酸氨基转移酶（ASL）测定（5元\n总胆红素（T-Bil）测定(5元)\n直接胆红素(D-Bil）测定（5元）\n间接胆红素（0元）\nγ-谷氨酰基转移酶（GGT）测定（5元）\n\n检查意义：\n检测肝脏功能，对各型肝炎、药物中毒、酒精性脂肪肝等引起的肝脏疾病有辅助诊断作用。\n");
            hashtable.Add("肾功能三项", "尿素(Urea）测定（5元）\n肌酐（Cr）测定(7元）\n尿酸（UA）测定（5元）\n\n检查意义：\n检测肾脏功能，对高血压、糖尿病、肾炎、痛风、肾结石等引起的肾脏疾病有辅助诊断作用。");
            hashtable.Add("血脂四项", "总胆固醇（TC）（5元）\n甘油三酯(TG)（7元）\n低密度脂蛋白胆固醇（10元）\n高密度脂蛋白胆固醇（HDL-C）测定（10元）\n\n检查意义：\n血脂异常是冠心病和缺血性脑血管病的独立危险因素，临床上分为原发性和继发性两大类，干预血脂异常是重要慢病防治的主要措施和手段。");
            hashtable.Add("空腹血糖", "葡萄糖（Glu）测定（6.5元）\n\n检查意义：\n用于诊断糖尿病、监测血糖控制情况。");
            hashtable.Add("超声", "肝胆胰脾彩色多普勒超声检查（114元）\n\n检查意义：\n检查肝、胆、胰、脾各脏器的大小、结构是否正常，有无结石、炎症、肿物等病变。\n");
            hashtable.Add("耳鼻喉", "间接喉镜检查（4元）,鼻咽镜检查（20元）\n\n检查意义：\n喉及喉咽部检查。鼻咽部检查。");
            hashtable.Add("健康体检", "内科、外科、妇科、眼科、口腔科、耳鼻喉科\n\n检查意义：\n血压、心、肺、肝、脾、神经系统等常规检查。身高、体重、甲状腺、乳腺、淋巴结、腰臀比等常规检查。妇科常规检查。外眼等常规检查。口腔卫生、牙齿及牙龈检查。\n");
            hashtable.Add("外科", "肛门指诊（5元）\n\n检查意义：\n	肛门直肠检查。\n");
            hashtable.Add("眼科", "	普通远视力检查（4元）色觉检查-假同色图谱法（3元）非散瞳直接检眼镜眼底检查（3元）\n\n检查意义：\n采用国际标准视力表对远视力进行检查。\n");
            hashtable.Add("妇科", "阴道检查（5元）人乳头瘤病毒基因分型检测（220元）\n\n检查意义：\n检查外阴及阴道情况。\n");
        }


        private void uiNavMenu1_MenuItemClick(TreeNode node, Sunny.UI.NavMenuItem item, int pageIndex)
        {
            List<string> list = new List<string>();
            this.list = list;
            

            Sunny.UI.UIPage newPage = new Sunny.UI.UIPage();
            newPage.Text = node.Text.ToString();
            newPage.Name = node.Text.ToString();
            
            Tab.AddPage(newPage);
            Tab.SelectedIndex = index;
            index++;
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Size = new Size(395, 350);
            newPage.Controls.Add(richTextBox);
            richTextBox.Text = infoHash[node.Text.ToString()].ToString();

            Sunny.UI.UICheckBox checkBox = new Sunny.UI.UICheckBox();
            checkBox.Checked = false;
            newPage.Controls.Add(checkBox);
            checkBox.Location = new Point(130, 380);
            
            checkBox.Text = "是否选择该项目";
            checkBox.AutoSize = true;
            checkBox.Style = Sunny.UI.UIStyle.Orange;
            checkBox.Name = node.Text.ToString();
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Sunny.UI.UICheckBox checkBox = (Sunny.UI.UICheckBox)sender;
            if (checkBox.Checked == true)
            {
                uiListBox1.Items.Add(checkBox.Name.ToString());
            }
            else
            {
                uiListBox1.Items.Remove(checkBox.Name.ToString());
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uiListBox1.Items.Count; ++i)
            {
                list.Add(uiListBox1.Items[i].ToString());
            }
            dateTime = uiDatetimePicker1.Value;
            ExamiationCheck examiationCheck = new ExamiationCheck(list, 2, dateTime);
            examiationCheck.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mainForm form = new mainForm();
            form.Show();
            this.Hide();
        }
    }
}
