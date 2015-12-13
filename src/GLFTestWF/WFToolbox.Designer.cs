namespace GLFTestWF
{
    partial class WFToolbox
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
            this.txtbx_user = new System.Windows.Forms.TextBox();
            this.tlbx_facebook = new GLFToolboxWF.Facebook();
            this.tlbx_google = new GLFToolboxWF.Google();
            this.tlbx_generic = new GLFToolboxWF.Generic();
            this.SuspendLayout();
            // 
            // txtbx_user
            // 
            this.txtbx_user.Location = new System.Drawing.Point(218, 12);
            this.txtbx_user.Multiline = true;
            this.txtbx_user.Name = "txtbx_user";
            this.txtbx_user.Size = new System.Drawing.Size(296, 195);
            this.txtbx_user.TabIndex = 3;
            // 
            // tlbx_facebook
            // 
            this.tlbx_facebook.Location = new System.Drawing.Point(11, 12);
            this.tlbx_facebook.Name = "tlbx_facebook";
            this.tlbx_facebook.Size = new System.Drawing.Size(201, 39);
            this.tlbx_facebook.TabIndex = 4;
            this.tlbx_facebook.Token = null;
            this.tlbx_facebook.Click += new System.EventHandler(this.tlbx_facebook_Click);
            // 
            // tlbx_google
            // 
            this.tlbx_google.Location = new System.Drawing.Point(11, 57);
            this.tlbx_google.Name = "tlbx_google";
            this.tlbx_google.Size = new System.Drawing.Size(200, 37);
            this.tlbx_google.TabIndex = 5;
            this.tlbx_google.Click += new System.EventHandler(this.tlbx_google_Click);
            // 
            // tlbx_generic
            // 
            this.tlbx_generic.Location = new System.Drawing.Point(13, 101);
            this.tlbx_generic.Name = "tlbx_generic";
            this.tlbx_generic.Size = new System.Drawing.Size(206, 112);
            this.tlbx_generic.TabIndex = 6;
            // 
            // WFToolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 219);
            this.Controls.Add(this.tlbx_generic);
            this.Controls.Add(this.tlbx_google);
            this.Controls.Add(this.tlbx_facebook);
            this.Controls.Add(this.txtbx_user);
            this.Name = "WFToolbox";
            this.Text = "WFToolbox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtbx_user;
        private GLFToolboxWF.Generic tlbx_generic;
        private GLFToolboxWF.Google tlbx_google;
        private GLFToolboxWF.Facebook tlbx_facebook;
    }
}