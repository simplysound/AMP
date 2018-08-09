namespace AMPClient
{
    partial class AMPControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AMPControlPanel));
            this.pbSwitcher = new System.Windows.Forms.PictureBox();
            this.pbAMPLogo = new System.Windows.Forms.PictureBox();
            this.pbLight = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMainForm = new System.Windows.Forms.PictureBox();
            this.toolTipURL = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSwitcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAMPLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainForm)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSwitcher
            // 
            this.pbSwitcher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSwitcher.Image = global::AMPClient.Properties.Resources.SwitcherOFF;
            this.pbSwitcher.Location = new System.Drawing.Point(25, 330);
            this.pbSwitcher.Name = "pbSwitcher";
            this.pbSwitcher.Size = new System.Drawing.Size(250, 95);
            this.pbSwitcher.TabIndex = 5;
            this.pbSwitcher.TabStop = false;
            this.pbSwitcher.Click += new System.EventHandler(this.pbSwitcher_Click);
            // 
            // pbAMPLogo
            // 
            this.pbAMPLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAMPLogo.Image = global::AMPClient.Properties.Resources.AMPLogo;
            this.pbAMPLogo.Location = new System.Drawing.Point(83, 454);
            this.pbAMPLogo.Name = "pbAMPLogo";
            this.pbAMPLogo.Size = new System.Drawing.Size(135, 135);
            this.pbAMPLogo.TabIndex = 4;
            this.pbAMPLogo.TabStop = false;
            this.pbAMPLogo.Click += new System.EventHandler(this.pbAMPLogo_Click);
            // 
            // pbLight
            // 
            this.pbLight.Image = ((System.Drawing.Image)(resources.GetObject("pbLight.Image")));
            this.pbLight.Location = new System.Drawing.Point(13, 50);
            this.pbLight.Name = "pbLight";
            this.pbLight.Size = new System.Drawing.Size(275, 275);
            this.pbLight.TabIndex = 3;
            this.pbLight.TabStop = false;
            // 
            // pbMinimize
            // 
            this.pbMinimize.BackColor = System.Drawing.Color.Transparent;
            this.pbMinimize.Image = global::AMPClient.Properties.Resources.MinimizeOFF;
            this.pbMinimize.Location = new System.Drawing.Point(230, 10);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(30, 30);
            this.pbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMinimize.TabIndex = 2;
            this.pbMinimize.TabStop = false;
            this.pbMinimize.Click += new System.EventHandler(this.pbMinimize_Click);
            this.pbMinimize.MouseLeave += new System.EventHandler(this.pbMinimize_MouseLeave);
            this.pbMinimize.MouseHover += new System.EventHandler(this.pbMinimize_MouseHover);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Image = global::AMPClient.Properties.Resources.CloseOFF;
            this.pbClose.Location = new System.Drawing.Point(260, 10);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(30, 30);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbClose.TabIndex = 1;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            this.pbClose.MouseLeave += new System.EventHandler(this.pbClose_MouseLeave);
            this.pbClose.MouseHover += new System.EventHandler(this.pbClose_MouseHover);
            // 
            // pbMainForm
            // 
            this.pbMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMainForm.Image = global::AMPClient.Properties.Resources.MainForm;
            this.pbMainForm.Location = new System.Drawing.Point(0, 0);
            this.pbMainForm.Name = "pbMainForm";
            this.pbMainForm.Size = new System.Drawing.Size(300, 622);
            this.pbMainForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMainForm.TabIndex = 0;
            this.pbMainForm.TabStop = false;
            // 
            // AMPControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbSwitcher);
            this.Controls.Add(this.pbAMPLogo);
            this.Controls.Add(this.pbLight);
            this.Controls.Add(this.pbMinimize);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.pbMainForm);
            this.Name = "AMPControlPanel";
            this.Size = new System.Drawing.Size(300, 622);
            ((System.ComponentModel.ISupportInitialize)(this.pbSwitcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAMPLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMainForm;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbMinimize;
        private System.Windows.Forms.PictureBox pbLight;
        private System.Windows.Forms.PictureBox pbAMPLogo;
        private System.Windows.Forms.PictureBox pbSwitcher;
        private System.Windows.Forms.ToolTip toolTipURL;
    }
}
