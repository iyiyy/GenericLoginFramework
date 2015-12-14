namespace GLFTestWF
{
    partial class WFGeneric
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
            this.label1 = new System.Windows.Forms.Label();
            this.box_uname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.box_pwd = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.box_result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // box_uname
            // 
            this.box_uname.Location = new System.Drawing.Point(15, 26);
            this.box_uname.Name = "box_uname";
            this.box_uname.Size = new System.Drawing.Size(257, 20);
            this.box_uname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // box_pwd
            // 
            this.box_pwd.Location = new System.Drawing.Point(18, 70);
            this.box_pwd.Name = "box_pwd";
            this.box_pwd.PasswordChar = '*';
            this.box_pwd.Size = new System.Drawing.Size(254, 20);
            this.box_pwd.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(196, 97);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // box_result
            // 
            this.box_result.Location = new System.Drawing.Point(18, 127);
            this.box_result.Multiline = true;
            this.box_result.Name = "box_result";
            this.box_result.Size = new System.Drawing.Size(254, 223);
            this.box_result.TabIndex = 5;
            // 
            // WFGeneric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.box_result);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.box_pwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.box_uname);
            this.Controls.Add(this.label1);
            this.Name = "WFGeneric";
            this.Text = "WF Generic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox box_uname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox box_pwd;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox box_result;
    }
}