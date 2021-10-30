namespace Tetris2048
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.easy = new System.Windows.Forms.Button();
            this.medium = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // easy
            // 
            this.easy.Location = new System.Drawing.Point(421, 171);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(146, 59);
            this.easy.TabIndex = 0;
            this.easy.Text = "簡單模式";
            this.easy.UseVisualStyleBackColor = true;
            this.easy.Click += new System.EventHandler(this.easy_Click);
            // 
            // medium
            // 
            this.medium.Location = new System.Drawing.Point(421, 273);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(146, 61);
            this.medium.TabIndex = 1;
            this.medium.Text = "普通模式";
            this.medium.UseVisualStyleBackColor = true;
            this.medium.Click += new System.EventHandler(this.medium_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 521);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.easy);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easy;
        private System.Windows.Forms.Button medium;
        private System.Windows.Forms.Timer timer1;
    }
}

