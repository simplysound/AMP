namespace AMPClient
{
    partial class FormSplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelAppDescription = new System.Windows.Forms.Label();
            this.checkBoxDontShowMeAgain = new System.Windows.Forms.CheckBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelAppVersion = new System.Windows.Forms.Label();
            this.pbAMPLogo = new System.Windows.Forms.PictureBox();
            this.toolTipURL = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbAMPLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCopyright
            // 
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelCopyright.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelCopyright.Location = new System.Drawing.Point(7, 305);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(250, 33);
            this.labelCopyright.TabIndex = 3;
            this.labelCopyright.Text = "2017-2018 All Rights Reserved\r\nThe Simply Sound Company";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAppDescription
            // 
            this.labelAppDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAppDescription.Location = new System.Drawing.Point(10, 213);
            this.labelAppDescription.Name = "labelAppDescription";
            this.labelAppDescription.Size = new System.Drawing.Size(250, 69);
            this.labelAppDescription.TabIndex = 2;
            this.labelAppDescription.Text = "AMP";
            this.labelAppDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxDontShowMeAgain
            // 
            this.checkBoxDontShowMeAgain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDontShowMeAgain.AutoSize = true;
            this.checkBoxDontShowMeAgain.Location = new System.Drawing.Point(10, 377);
            this.checkBoxDontShowMeAgain.Name = "checkBoxDontShowMeAgain";
            this.checkBoxDontShowMeAgain.Size = new System.Drawing.Size(132, 17);
            this.checkBoxDontShowMeAgain.TabIndex = 0;
            this.checkBoxDontShowMeAgain.Text = "Do not show me again";
            this.checkBoxDontShowMeAgain.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(182, 374);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelAppVersion
            // 
            this.labelAppVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAppVersion.Location = new System.Drawing.Point(7, 282);
            this.labelAppVersion.Name = "labelAppVersion";
            this.labelAppVersion.Size = new System.Drawing.Size(250, 23);
            this.labelAppVersion.TabIndex = 10;
            this.labelAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbAMPLogo
            // 
            this.pbAMPLogo.Image = global::AMPClient.Properties.Resources.MainLogo;
            this.pbAMPLogo.Location = new System.Drawing.Point(60, 60);
            this.pbAMPLogo.Name = "pbAMPLogo";
            this.pbAMPLogo.Size = new System.Drawing.Size(150, 150);
            this.pbAMPLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAMPLogo.TabIndex = 7;
            this.pbAMPLogo.TabStop = false;
            this.pbAMPLogo.Click += new System.EventHandler(this.pbAMPLogo_Click);
            // 
            // FormSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 410);
            this.Controls.Add(this.labelAppVersion);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelAppDescription);
            this.Controls.Add(this.pbAMPLogo);
            this.Controls.Add(this.checkBoxDontShowMeAgain);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSplashScreen";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSplashScreen";
            this.Load += new System.EventHandler(this.FormSplashScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormSplashScreen_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbAMPLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelAppDescription;
        private System.Windows.Forms.PictureBox pbAMPLogo;
        private System.Windows.Forms.CheckBox checkBoxDontShowMeAgain;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelAppVersion;
        private System.Windows.Forms.ToolTip toolTipURL;
    }
}