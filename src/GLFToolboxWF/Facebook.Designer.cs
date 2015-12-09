using System.ComponentModel;

namespace GLFToolboxWF
{
    partial class Facebook
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
            this.FacebookBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FacebookBtn
            // 
            this.FacebookBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(103)))), ((int)(((byte)(168)))));
            this.FacebookBtn.FlatAppearance.BorderSize = 0;
            this.FacebookBtn.ForeColor = System.Drawing.Color.White;
            this.FacebookBtn.Location = new System.Drawing.Point(0, 0);
            this.FacebookBtn.Name = "FacebookBtn";
            this.FacebookBtn.Size = new System.Drawing.Size(200, 37);
            this.FacebookBtn.TabIndex = 0;
            this.FacebookBtn.Text = "Login with Facebook";
            this.FacebookBtn.UseVisualStyleBackColor = false;
            this.FacebookBtn.Click += new System.EventHandler(this.FacebookBtn_Click);
            // 
            // Facebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FacebookBtn);
            this.Name = "Facebook";
            this.Size = new System.Drawing.Size(200, 36);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button FacebookBtn;
    }
}
