using System.ComponentModel;

namespace GLFToolboxWF
{
    partial class Google
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GoogleBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoogleBtn
            // 
            this.GoogleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(198)))));
            this.GoogleBtn.FlatAppearance.BorderSize = 0;
            this.GoogleBtn.ForeColor = System.Drawing.Color.White;
            this.GoogleBtn.Location = new System.Drawing.Point(0, 0);
            this.GoogleBtn.Name = "GoogleBtn";
            this.GoogleBtn.Size = new System.Drawing.Size(200, 37);
            this.GoogleBtn.TabIndex = 0;
            this.GoogleBtn.Text = "Login with Google";
            this.GoogleBtn.UseVisualStyleBackColor = false;
            this.GoogleBtn.Click += new System.EventHandler(this.GoogleBtn_Click);
            // 
            // Google
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GoogleBtn);
            this.Name = "Google";
            this.Size = new System.Drawing.Size(200, 37);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoogleBtn;
    }
}
