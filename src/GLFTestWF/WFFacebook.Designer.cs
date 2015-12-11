namespace GLFTestWF
{
    partial class WFFacebook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginBtn = new System.Windows.Forms.Button();
            this.resultTxtbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.loginBtn.Location = new System.Drawing.Point(104, 14);
            this.loginBtn.Name = "button1";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // textBox1
            // 
            this.resultTxtbx.Location = new System.Drawing.Point(11, 49);
            this.resultTxtbx.Multiline = true;
            this.resultTxtbx.Name = "textBox1";
            this.resultTxtbx.Size = new System.Drawing.Size(260, 200);
            this.resultTxtbx.TabIndex = 1;
            // 
            // WFFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.resultTxtbx);
            this.Controls.Add(this.loginBtn);
            this.Name = "WFFacebook";
            this.Text = "WF Facebook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox resultTxtbx;
    }
}