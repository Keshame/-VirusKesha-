
namespace kesha.vir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.EnterPass = new Guna.UI2.WinForms.Guna2Button();
            this.key = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // EnterPass
            // 
            this.EnterPass.Animated = true;
            this.EnterPass.AutoRoundedCorners = true;
            this.EnterPass.BackColor = System.Drawing.Color.Transparent;
            this.EnterPass.BorderRadius = 21;
            this.EnterPass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.EnterPass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.EnterPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.EnterPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.EnterPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EnterPass.ForeColor = System.Drawing.Color.White;
            this.EnterPass.Location = new System.Drawing.Point(74, 94);
            this.EnterPass.Name = "EnterPass";
            this.EnterPass.Size = new System.Drawing.Size(180, 45);
            this.EnterPass.TabIndex = 0;
            this.EnterPass.Text = "ENTER";
            this.EnterPass.Click += new System.EventHandler(this.EnterPass_Click);
            // 
            // key
            // 
            this.key.Animated = true;
            this.key.AutoRoundedCorners = true;
            this.key.BorderRadius = 17;
            this.key.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.key.DefaultText = "";
            this.key.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.key.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.key.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.key.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.key.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.key.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.key.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.key.Location = new System.Drawing.Point(74, 52);
            this.key.Name = "key";
            this.key.PasswordChar = '\0';
            this.key.PlaceholderText = "KEY";
            this.key.SelectedText = "";
            this.key.Size = new System.Drawing.Size(180, 36);
            this.key.TabIndex = 22;
            this.key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(-17, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "---------------------------------------------------------------------------------" +
    "-----\r\n";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(328, 191);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.key);
            this.Controls.Add(this.EnterPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-sorry-";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button EnterPass;
        private Guna.UI2.WinForms.Guna2TextBox key;
     
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

