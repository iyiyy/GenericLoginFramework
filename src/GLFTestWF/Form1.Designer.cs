namespace GLFTestWF
{
    partial class Form1
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
            this.btn_facebook = new System.Windows.Forms.Button();
            this.btn_google = new System.Windows.Forms.Button();
            this.btn_generic = new System.Windows.Forms.Button();
            this.btn_toolbox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_facebook
            // 
            this.btn_facebook.Location = new System.Drawing.Point(84, 12);
            this.btn_facebook.Name = "btn_facebook";
            this.btn_facebook.Size = new System.Drawing.Size(75, 23);
            this.btn_facebook.TabIndex = 0;
            this.btn_facebook.Text = "Facebook";
            this.btn_facebook.UseVisualStyleBackColor = true;
            this.btn_facebook.Click += new System.EventHandler(this.btn_facebook_Click);
            // 
            // btn_google
            // 
            this.btn_google.Location = new System.Drawing.Point(84, 60);
            this.btn_google.Name = "btn_google";
            this.btn_google.Size = new System.Drawing.Size(75, 23);
            this.btn_google.TabIndex = 1;
            this.btn_google.Text = "Google";
            this.btn_google.UseVisualStyleBackColor = true;
            this.btn_google.Click += new System.EventHandler(this.btn_google_Click);
            // 
            // btn_generic
            // 
            this.btn_generic.Location = new System.Drawing.Point(84, 109);
            this.btn_generic.Name = "btn_generic";
            this.btn_generic.Size = new System.Drawing.Size(75, 23);
            this.btn_generic.TabIndex = 2;
            this.btn_generic.Text = "Generic";
            this.btn_generic.UseVisualStyleBackColor = true;
            this.btn_generic.Click += new System.EventHandler(this.btn_generic_Click);
            // 
            // btn_toolbox
            // 
            this.btn_toolbox.Location = new System.Drawing.Point(84, 149);
            this.btn_toolbox.Name = "btn_toolbox";
            this.btn_toolbox.Size = new System.Drawing.Size(75, 23);
            this.btn_toolbox.TabIndex = 3;
            this.btn_toolbox.Text = "Toolbox";
            this.btn_toolbox.UseVisualStyleBackColor = true;
            this.btn_toolbox.Click += new System.EventHandler(this.btn_toolbox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 184);
            this.Controls.Add(this.btn_toolbox);
            this.Controls.Add(this.btn_generic);
            this.Controls.Add(this.btn_google);
            this.Controls.Add(this.btn_facebook);
            this.Name = "Form1";
            this.Text = "WF Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_facebook;
        private System.Windows.Forms.Button btn_google;
        private System.Windows.Forms.Button btn_generic;
        private System.Windows.Forms.Button btn_toolbox;
    }
}

