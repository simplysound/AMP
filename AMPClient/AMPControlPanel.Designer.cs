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
            this.toolTipURL = new System.Windows.Forms.ToolTip(this.components);
            this.pbSwitcher = new System.Windows.Forms.PictureBox();
            this.pbAMPLogo = new System.Windows.Forms.PictureBox();
            this.pbLight = new System.Windows.Forms.PictureBox();
            this.pbMinimize = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pbMainForm = new System.Windows.Forms.PictureBox();
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
            this.pbSwitcher.Image = ((System.Drawing.Image)(resources.GetObject("pbSwitcher.Image")));
            this.pbSwitcher.Location = new System.Drawing.Point(17, 220);
            this.pbSwitcher.Name = "pbSwitcher";
            this.pbSwitcher.Size = new System.Drawing.Size(166, 63);
            this.pbSwitcher.TabIndex = 5;
            this.pbSwitcher.TabStop = false;
            this.pbSwitcher.Click += new System.EventHandler(this.pbSwitcher_Click);
            // 
            // pbAMPLogo
            // 
            this.pbAMPLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAMPLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbAMPLogo.Image")));
            this.pbAMPLogo.Location = new System.Drawing.Point(55, 303);
            this.pbAMPLogo.Name = "pbAMPLogo";
            this.pbAMPLogo.Size = new System.Drawing.Size(90, 90);
            this.pbAMPLogo.TabIndex = 4;
            this.pbAMPLogo.TabStop = false;
            this.pbAMPLogo.Click += new System.EventHandler(this.pbAMPLogo_Click);
            // 
            // pbLight
            // 
            this.pbLight.Image = ((System.Drawing.Image)(resources.GetObject("pbLight.Image")));
            this.pbLight.Location = new System.Drawing.Point(9, 33);
            this.pbLight.Name = "pbLight";
            this.pbLight.Size = new System.Drawing.Size(183, 183);
            this.pbLight.TabIndex = 3;
            this.pbLight.TabStop = false;
            // 
            // pbMinimize
            // 
            this.pbMinimize.BackColor = System.Drawing.Color.Transparent;
            this.pbMinimize.Image = ((System.Drawing.Image)(resources.GetObject("pbMinimize.Image")));
            this.pbMinimize.Location = new System.Drawing.Point(153, 7);
            this.pbMinimize.Name = "pbMinimize";
            this.pbMinimize.Size = new System.Drawing.Size(20, 20);
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
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(173, 7);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(20, 20);
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
            this.pbMainForm.Image = ((System.Drawing.Image)(resources.GetObject("pbMainForm.Image")));
            this.pbMainForm.Location = new System.Drawing.Point(0, 0);
            this.pbMainForm.Name = "pbMainForm";
            this.pbMainForm.Size = new System.Drawing.Size(200, 415);
            this.pbMainForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMainForm.TabIndex = 0;
            this.pbMainForm.TabStop = false;
            // 
            // AMPControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbAMPLogo);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.pbMinimize);
            this.Controls.Add(this.pbSwitcher);
            this.Controls.Add(this.pbLight);
            this.Controls.Add(this.pbMainForm);
            this.Name = "AMPControlPanel";
            this.Size = new System.Drawing.Size(200, 415);
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
