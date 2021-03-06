﻿namespace AMPUtility
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBoxWiFi = new System.Windows.Forms.GroupBox();
            this.buttonGetWLANStatus = new System.Windows.Forms.Button();
            this.buttonWLANService = new System.Windows.Forms.Button();
            this.buttonDisconnectWiFi = new System.Windows.Forms.Button();
            this.buttonConnectWiFi = new System.Windows.Forms.Button();
            this.buttonDisableWiFi = new System.Windows.Forms.Button();
            this.buttonEnableWiFi = new System.Windows.Forms.Button();
            this.groupBoxAudioSrv = new System.Windows.Forms.GroupBox();
            this.buttonAudioSrvDependecyList = new System.Windows.Forms.Button();
            this.buttonGetAudioSrvStatus = new System.Windows.Forms.Button();
            this.buttonDisableAudioSrv = new System.Windows.Forms.Button();
            this.buttonEnableAudioSrv = new System.Windows.Forms.Button();
            this.groupBoxWiFi.SuspendLayout();
            this.groupBoxAudioSrv.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxWiFi
            // 
            this.groupBoxWiFi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWiFi.Controls.Add(this.buttonGetWLANStatus);
            this.groupBoxWiFi.Controls.Add(this.buttonWLANService);
            this.groupBoxWiFi.Controls.Add(this.buttonDisconnectWiFi);
            this.groupBoxWiFi.Controls.Add(this.buttonConnectWiFi);
            this.groupBoxWiFi.Controls.Add(this.buttonDisableWiFi);
            this.groupBoxWiFi.Controls.Add(this.buttonEnableWiFi);
            this.groupBoxWiFi.Location = new System.Drawing.Point(12, 12);
            this.groupBoxWiFi.Name = "groupBoxWiFi";
            this.groupBoxWiFi.Size = new System.Drawing.Size(185, 117);
            this.groupBoxWiFi.TabIndex = 0;
            this.groupBoxWiFi.TabStop = false;
            this.groupBoxWiFi.Text = "WiFi";
            // 
            // buttonGetWLANStatus
            // 
            this.buttonGetWLANStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetWLANStatus.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetWLANStatus.Image")));
            this.buttonGetWLANStatus.Location = new System.Drawing.Point(144, 78);
            this.buttonGetWLANStatus.Name = "buttonGetWLANStatus";
            this.buttonGetWLANStatus.Size = new System.Drawing.Size(26, 23);
            this.buttonGetWLANStatus.TabIndex = 5;
            this.buttonGetWLANStatus.UseVisualStyleBackColor = true;
            this.buttonGetWLANStatus.Click += new System.EventHandler(this.buttonGetWLANStatus_Click);
            // 
            // buttonWLANService
            // 
            this.buttonWLANService.Location = new System.Drawing.Point(14, 78);
            this.buttonWLANService.Name = "buttonWLANService";
            this.buttonWLANService.Size = new System.Drawing.Size(124, 23);
            this.buttonWLANService.TabIndex = 4;
            this.buttonWLANService.Text = "WLAN Service";
            this.buttonWLANService.UseVisualStyleBackColor = true;
            this.buttonWLANService.Click += new System.EventHandler(this.buttonWLANService_Click);
            // 
            // buttonDisconnectWiFi
            // 
            this.buttonDisconnectWiFi.Location = new System.Drawing.Point(95, 49);
            this.buttonDisconnectWiFi.Name = "buttonDisconnectWiFi";
            this.buttonDisconnectWiFi.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnectWiFi.TabIndex = 3;
            this.buttonDisconnectWiFi.Text = "Disconnect";
            this.buttonDisconnectWiFi.UseVisualStyleBackColor = true;
            this.buttonDisconnectWiFi.Click += new System.EventHandler(this.buttonDisconnectWiFi_Click);
            // 
            // buttonConnectWiFi
            // 
            this.buttonConnectWiFi.Location = new System.Drawing.Point(95, 20);
            this.buttonConnectWiFi.Name = "buttonConnectWiFi";
            this.buttonConnectWiFi.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectWiFi.TabIndex = 2;
            this.buttonConnectWiFi.Text = "Connect";
            this.buttonConnectWiFi.UseVisualStyleBackColor = true;
            this.buttonConnectWiFi.Click += new System.EventHandler(this.buttonConnectWiFi_Click);
            // 
            // buttonDisableWiFi
            // 
            this.buttonDisableWiFi.Location = new System.Drawing.Point(14, 49);
            this.buttonDisableWiFi.Name = "buttonDisableWiFi";
            this.buttonDisableWiFi.Size = new System.Drawing.Size(75, 23);
            this.buttonDisableWiFi.TabIndex = 1;
            this.buttonDisableWiFi.Text = "Disable WiFi";
            this.buttonDisableWiFi.UseVisualStyleBackColor = true;
            this.buttonDisableWiFi.Click += new System.EventHandler(this.buttonDisableWiFi_Click);
            // 
            // buttonEnableWiFi
            // 
            this.buttonEnableWiFi.Location = new System.Drawing.Point(14, 20);
            this.buttonEnableWiFi.Name = "buttonEnableWiFi";
            this.buttonEnableWiFi.Size = new System.Drawing.Size(75, 23);
            this.buttonEnableWiFi.TabIndex = 0;
            this.buttonEnableWiFi.Text = "Enable WiFi";
            this.buttonEnableWiFi.UseVisualStyleBackColor = true;
            this.buttonEnableWiFi.Click += new System.EventHandler(this.buttonEnableWiFi_Click);
            // 
            // groupBoxAudioSrv
            // 
            this.groupBoxAudioSrv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAudioSrv.Controls.Add(this.buttonAudioSrvDependecyList);
            this.groupBoxAudioSrv.Controls.Add(this.buttonGetAudioSrvStatus);
            this.groupBoxAudioSrv.Controls.Add(this.buttonDisableAudioSrv);
            this.groupBoxAudioSrv.Controls.Add(this.buttonEnableAudioSrv);
            this.groupBoxAudioSrv.Location = new System.Drawing.Point(12, 135);
            this.groupBoxAudioSrv.Name = "groupBoxAudioSrv";
            this.groupBoxAudioSrv.Size = new System.Drawing.Size(185, 86);
            this.groupBoxAudioSrv.TabIndex = 1;
            this.groupBoxAudioSrv.TabStop = false;
            this.groupBoxAudioSrv.Text = "AudioSrv";
            // 
            // buttonAudioSrvDependecyList
            // 
            this.buttonAudioSrvDependecyList.Location = new System.Drawing.Point(14, 49);
            this.buttonAudioSrvDependecyList.Name = "buttonAudioSrvDependecyList";
            this.buttonAudioSrvDependecyList.Size = new System.Drawing.Size(124, 23);
            this.buttonAudioSrvDependecyList.TabIndex = 6;
            this.buttonAudioSrvDependecyList.Text = "Enable AudioSrv";
            this.buttonAudioSrvDependecyList.UseVisualStyleBackColor = true;
            this.buttonAudioSrvDependecyList.Click += new System.EventHandler(this.buttonAudioSrvDependecyList_Click);
            // 
            // buttonGetAudioSrvStatus
            // 
            this.buttonGetAudioSrvStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetAudioSrvStatus.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetAudioSrvStatus.Image")));
            this.buttonGetAudioSrvStatus.Location = new System.Drawing.Point(144, 49);
            this.buttonGetAudioSrvStatus.Name = "buttonGetAudioSrvStatus";
            this.buttonGetAudioSrvStatus.Size = new System.Drawing.Size(26, 23);
            this.buttonGetAudioSrvStatus.TabIndex = 5;
            this.buttonGetAudioSrvStatus.UseVisualStyleBackColor = true;
            this.buttonGetAudioSrvStatus.Click += new System.EventHandler(this.buttonGetAudioSrvStatus_Click);
            // 
            // buttonDisableAudioSrv
            // 
            this.buttonDisableAudioSrv.Location = new System.Drawing.Point(95, 20);
            this.buttonDisableAudioSrv.Name = "buttonDisableAudioSrv";
            this.buttonDisableAudioSrv.Size = new System.Drawing.Size(75, 23);
            this.buttonDisableAudioSrv.TabIndex = 1;
            this.buttonDisableAudioSrv.Text = "Disable AudioSrv";
            this.buttonDisableAudioSrv.UseVisualStyleBackColor = true;
            this.buttonDisableAudioSrv.Click += new System.EventHandler(this.buttonDisableAudioSrv_Click);
            // 
            // buttonEnableAudioSrv
            // 
            this.buttonEnableAudioSrv.Location = new System.Drawing.Point(14, 20);
            this.buttonEnableAudioSrv.Name = "buttonEnableAudioSrv";
            this.buttonEnableAudioSrv.Size = new System.Drawing.Size(75, 23);
            this.buttonEnableAudioSrv.TabIndex = 0;
            this.buttonEnableAudioSrv.Text = "Enable AudioSrv";
            this.buttonEnableAudioSrv.UseVisualStyleBackColor = true;
            this.buttonEnableAudioSrv.Click += new System.EventHandler(this.buttonEnableAudioSrv_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 235);
            this.Controls.Add(this.groupBoxAudioSrv);
            this.Controls.Add(this.groupBoxWiFi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AMP Utility";
            this.groupBoxWiFi.ResumeLayout(false);
            this.groupBoxAudioSrv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxWiFi;
        private System.Windows.Forms.Button buttonWLANService;
        private System.Windows.Forms.Button buttonDisconnectWiFi;
        private System.Windows.Forms.Button buttonConnectWiFi;
        private System.Windows.Forms.Button buttonDisableWiFi;
        private System.Windows.Forms.Button buttonEnableWiFi;
        private System.Windows.Forms.Button buttonGetWLANStatus;
        private System.Windows.Forms.GroupBox groupBoxAudioSrv;
        private System.Windows.Forms.Button buttonGetAudioSrvStatus;
        private System.Windows.Forms.Button buttonDisableAudioSrv;
        private System.Windows.Forms.Button buttonEnableAudioSrv;
        private System.Windows.Forms.Button buttonAudioSrvDependecyList;
    }
}

