namespace Laba_5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PB_Main = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.L_Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Main
            // 
            this.PB_Main.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PB_Main.Location = new System.Drawing.Point(12, 13);
            this.PB_Main.Name = "PB_Main";
            this.PB_Main.Size = new System.Drawing.Size(774, 425);
            this.PB_Main.TabIndex = 0;
            this.PB_Main.TabStop = false;
            this.PB_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.PB_Main_Paint);
            this.PB_Main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PB_Main_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // L_Score
            // 
            this.L_Score.AutoSize = true;
            this.L_Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Score.Location = new System.Drawing.Point(715, 2);
            this.L_Score.Name = "L_Score";
            this.L_Score.Size = new System.Drawing.Size(80, 24);
            this.L_Score.TabIndex = 1;
            this.L_Score.Text = "Score: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.L_Score);
            this.Controls.Add(this.PB_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №5";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Main;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label L_Score;
    }
}

