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
        int len = 6;//固定長度(超過6遊戲結束)
        int num = 0;//下一次的隨機生成數字
        int grade = 0;
        int randLoc;//隨機生成的downNum陣列位置
        int sec=3;
        int[] downNum = new int[3] { 2, 4, 8 };//ASD分別對到的數字
        Random random = new Random();
        bool req = false;//判定是否為簡單模式(如果是的話可以指定數字2.4.8)
        bool Single = true;//判定還有沒有上下重複的數字
        public void initialBtn(ref Button btn, int locX, int locY, int Xnum)//一開始按鈕的擺放
        {
            btn = new Button();
            Controls.Add(btn);
            btn.Location = new Point(10 + locX * 60, 300 - 60 * locY);
            btn.Size = new Size(50, 50);
        }
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
            timer1.Interval = 1000;//1秒//一開始就要設好不可以在tick才設不然會出事QAQ
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
        /* Easy mode */
        private void easy_Click(object sender, EventArgs e)
        {
            initialize();
            req = true;
            timer1.Enabled = false;
        }
        /*Medium mode */
        private void medium_Click(object sender, EventArgs e)
        {
            initialize();
            req = false;
            time.Visible = true;
            timer1.Enabled = true;
            time.Text = "倒數計時 : " + sec;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;/* Remember to add or the computer won't accept the keyboard information. */
        }
        /*everytime we press the keyboard */
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    Qnum[tempQ] = num;
                    do//至少check一次
                    {
                        checkRepeat(ref Qnum, ref tempQ);
                        checkRepeat(ref Wnum, ref tempW);//有可能一個橫排消掉後別排上下重複
                        checkRepeat(ref Enum, ref tempE);
                        checkRepeat(ref Rnum, ref tempR);
                        checkRow();
                    } while (Single == false);//沒有上下重複了
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
                    } while (!Single);
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
                    } while (!Single);
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
            if (Qnum[5] != 0 || Wnum[5] != 0 || Enum[5] != 0 || Rnum[5] != 0)//如果滿了就gameover
            {
                MessageBox.Show("遊戲結束!!!" + Environment.NewLine + "你的分數 : " + grade, "", MessageBoxButtons.OK, MessageBoxIcon.None);
                timer1.Enabled = false;
                Application.Exit();
            }
            nowGrade.Text = "你的分數 : " + grade;
            nowNum.Text = "當前數字 : " + num;
            if (timer1.Enabled)//普通模式在用的
            {
                sec = 3;
                time.Text = "倒數計時 : " + sec;
            }
        }
        /* Check the column if above button's number is equal to under button's. */ 
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
                    i= 0;//如果可以上下消掉，再從最底層開始掃描直到整排都沒有重複
                }
                else i++;
            }
            Single = true;
        }
        int tempQ=0, tempW=0, tempE=0, tempR=0;//去記最上層的位置(用來擺放新的數字)
        
        /* Check the row if a row is same. */
        private void checkRow()//檢查橫排
        {
            for(int i = 0; i < len; i++)
            {
                if (Qnum[i]!=0&&Qnum[i] == Wnum[i] && Enum[i] == Rnum[i] && Wnum[i] == Enum[i])
                {
                    Single = false;//要再檢查一次上下以防有重複
                    grade += Qnum[i] * Qnum[i];
                    for (int j = i; j< len - 1; j++) Qnum[j] = Qnum[j + 1];//每一直排都要往下移動
                    for (int j = i; j < len-1; j++) Wnum[j] = Wnum[j + 1];
                    for (int j = i; j < len-1; j++) Enum[j] = Enum[j + 1];
                    for (int j = i; j < len - 1; j++) Rnum[j] = Rnum[j + 1];
                    Qnum[len - 1] = 0;//最上排一定要是0(有可能第六排變第五排，第六排會沒東西)
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
        /* Determine some button whether to show to public.*/
        private void seeBtn(ref Button[] btn, int temp, int[] Xnum)//可以看到的button
        {
            for (int i = 0; i <= len - 1; i++)
            {
                if (Xnum[i] != 0)//不等於0的才顯示button
                {
                    btn[i].Visible = true;
                    btn[i].Text = Xnum[i].ToString();
                }
                else btn[i].Visible = false;
            }
            randLoc = random.Next(0, 3);//要去更改num(下一次的隨機生成數字)
            num = downNum[randLoc];
        }
        /* Timer is used to count down the time. */
        private void timer1_Tick(object sender, EventArgs e)
        {
            sec--;
            time.Text = "倒數計時 : " + sec;
            if (sec == 0)//如果時間到就自動掉下到第2直排
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
    }
}
