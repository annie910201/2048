using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris2048
{
    public partial class Form1 : Form
    {
        Label nowGrade = new Label();
        Label nowNum = new Label();
        Label time = new Label();
        Button keyQ = new Button();
        Button keyW = new Button();
        Button keyE = new Button();
        Button keyR = new Button();
        Button[] Qbtn = new Button[6];
        Button[] Wbtn = new Button[6];
        Button[] Ebtn = new Button[6];
        Button[] Rbtn = new Button[6];
        int[] Qnum = new int[6] { 0,0,0,0,0,0};
        int[] Wnum = new int[6] { 0, 0, 0, 0, 0, 0 };
        int[] Enum = new int[6] { 0, 0, 0, 0, 0, 0 };
        int[] Rnum = new int[6] { 0, 0, 0, 0, 0, 0 };
        int len = 6;
        int num = 0, grade = 0;
        int randLoc;
        int sec=3;
        int[] downNum = new int[3] { 2, 4, 8 };
        Random random = new Random();
        bool req = false;
        public Form1()
        {
            InitializeComponent();
            for(int i = 0; i < len; i++)
            {
                initialBtn(ref Qbtn[i], 0, i, Qnum[i]);
                initialBtn(ref Wbtn[i], 1, i, Wnum[i]);
                initialBtn(ref Ebtn[i], 2, i, Enum[i]);
                initialBtn(ref Rbtn[i], 3, i, Rnum[i]);
                Qbtn[i].Visible = false;
                Wbtn[i].Visible = false;
                Ebtn[i].Visible = false;
                Rbtn[i].Visible = false;
            }
        }
        public void initialBtn(ref Button btn, int locX, int locY, int Xnum)
        {
            btn = new Button();
            Controls.Add(btn);
            btn.Location = new Point(10 + locX * 60, 300 - 60 * locY);
            btn.Size = new Size(50, 50);
            
        }
        private void seeBtn(ref Button[] btn,int temp,int[] Xnum)
        {
            for (int i = 0; i <= len-1; i++)
            {
                if (Xnum[i] != 0)
                {
                    btn[i].Visible = true;
                    btn[i].Text = Xnum[i].ToString();
                }
                else btn[i].Visible = false;
            }
            randLoc = random.Next(0, 3);
            num = downNum[randLoc];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        bool Single = true;
        public void checkRepeat(ref int[] num,ref int temp)
        {
            int i=0;
            while(i!=len-1)
            {
                if (num[i] != 0 && num[i] == num[i + 1])
                {
                    num[i] *= 2;
                    for (int j = i + 1; j < len - 1; j++) num[j] = num[j + 1];
                    num[len - 1] = 0;
                    temp--;
                    i= 0;
                }
                else i++;
            }
            Single = true;
        }
        int tempQ=0, tempW=0, tempE=0, tempR=0;
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled) timer1.Stop();
            switch (e.KeyCode)
            {
                case Keys.Q:
                    Qnum[tempQ] = num;
                    do
                    {
                        checkRepeat(ref Qnum, ref tempQ);
                        checkRepeat(ref Wnum, ref tempW);
                        checkRepeat(ref Enum, ref tempE);
                        checkRepeat(ref Rnum, ref tempR);
                        checkRow();
                    } while (Single==false);
                    seeBtn(ref Qbtn, tempQ, Qnum);
                    seeBtn(ref Wbtn, tempW, Wnum);
                    seeBtn(ref Ebtn, tempE, Enum);
                    seeBtn(ref Rbtn, tempR, Rnum);
                    tempQ++;
                    break;
                case Keys.W:
                    Wnum[tempW] = num;
                    do
                    {
                        checkRepeat(ref Qnum, ref tempQ);
                        checkRepeat(ref Wnum, ref tempW);
                        checkRepeat(ref Enum, ref tempE);
                        checkRepeat(ref Rnum, ref tempR);
                        checkRow();
                    } while (!Single);
                    seeBtn(ref Qbtn, tempQ, Qnum);
                    seeBtn(ref Wbtn, tempW, Wnum);
                    seeBtn(ref Ebtn, tempE, Enum);
                    seeBtn(ref Rbtn, tempR, Rnum);
                    tempW++;
                    break;
                case Keys.E:
                    Enum[tempE] = num;
                    do
                    {
                        checkRepeat(ref Qnum, ref tempQ);
                        checkRepeat(ref Wnum, ref tempW);
                        checkRepeat(ref Enum, ref tempE);
                        checkRepeat(ref Rnum, ref tempR);
                        checkRow();
                    } while (!Single) ;
                    seeBtn(ref Qbtn, tempQ, Qnum);
                    seeBtn(ref Wbtn, tempW, Wnum);
                    seeBtn(ref Ebtn, tempE, Enum);
                    seeBtn(ref Rbtn, tempR, Rnum);
                    tempE++;
                    break;
                case Keys.R:
                    Rnum[tempR] = num;
                    do
                    {
                        checkRepeat(ref Qnum, ref tempQ);
                        checkRepeat(ref Wnum, ref tempW);
                        checkRepeat(ref Enum, ref tempE);
                        checkRepeat(ref Rnum, ref tempR);
                        checkRow();
                    } while (!Single) ;
                    seeBtn(ref Qbtn, tempQ, Qnum);
                    seeBtn(ref Wbtn, tempW, Wnum);
                    seeBtn(ref Ebtn, tempE, Enum);
                    seeBtn(ref Rbtn, tempR, Rnum);
                    tempR++;
                    break;
                case Keys.A:
                    if (req == true) num = 2;
                    break;
                case Keys.S:
                    if (req == true) num = 4;
                    break;
                case Keys.D:
                    if (req == true) num = 8;
                    break;
            }
            if (Qnum[5] != 0 || Wnum[5] != 0 || Enum[5] != 0 || Rnum[5] != 0)
            {
                MessageBox.Show("遊戲結束!!!" + Environment.NewLine + "你的分數 : " + grade, "", MessageBoxButtons.OK, MessageBoxIcon.None);
                timer1.Enabled = false;
            }
            nowGrade.Text = "你的分數 : " + grade;
            nowNum.Text = "當前數字 : " + num;
            if (timer1.Enabled)
            {
                sec = 3;
                timer1.Start();
            }
        }
        private void checkRow()
        {
            for(int i = 0; i < len; i++)
            {
                if (Qnum[i]!=0&&Qnum[i] == Wnum[i] && Enum[i] == Rnum[i] && Wnum[i] == Enum[i])
                {
                    Single = false;
                    grade += Qnum[i] * Qnum[i];
                    for (int j = i; j< len - 1; j++) Qnum[j] = Qnum[j + 1];
                    for (int j = i; j < len-1; j++) Wnum[j] = Wnum[j + 1];
                    for (int j = i; j < len-1; j++) Enum[j] = Enum[j + 1];
                    for (int j = i; j < len - 1; j++) Rnum[j] = Rnum[j + 1];
                    Qnum[len - 1] = 0;
                    tempQ--;
                    Wnum[len - 1] = 0;
                    tempW--;
                    Enum[len - 1] = 0;
                    tempE--;
                    Rnum[len - 1] = 0;
                    tempR--;
                   
                }
            }
        }
        private void initialize()
        {
            easy.Visible = false;
            medium.Visible = false;
            randLoc = random.Next(0, 3);
            num = downNum[randLoc];
            nowNum.Text = "當前數字 : " + num;
            nowGrade.Text = "你的分數 : " + grade;
            time.Text = "倒數計時 : " + sec;
            nowGrade.Size = new Size(100, 15);
            nowNum.Size = new Size(100, 15);
            time.Size = new Size(100, 15);
            nowGrade.Location = new Point(650, 10);
            nowNum.Location = new Point(650, 30);
            time.Location = new Point(650, 50);
            Controls.Add(nowGrade);
            Controls.Add(nowNum);
            Controls.Add(time);
            time.Visible = false;
        }
        private void easy_Click(object sender, EventArgs e)
        {
            initialize();
            req = true;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec--;
            time.Text = "倒數計時 : " + sec;
            if (sec == 0)
            {
                sec = 3;
                Wnum[tempW] = num;
                checkRepeat(ref Wnum, ref tempW);
                checkRow();
                seeBtn(ref Qbtn, tempQ, Qnum);
                seeBtn(ref Wbtn, tempW, Wnum);
                seeBtn(ref Ebtn, tempE, Enum);
                seeBtn(ref Rbtn, tempR, Rnum);
                tempW++;
            }
        }
        private void medium_Click(object sender, EventArgs e)
        {
            initialize();
            req = false;
            time.Visible = true;
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }
    }
}
