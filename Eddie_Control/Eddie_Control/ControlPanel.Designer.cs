namespace Eddie_Control
{
    partial class ControlPanel
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAutonomusTestDrive = new System.Windows.Forms.Button();
            this.btnFindHumans = new System.Windows.Forms.Button();
            this.btnFindObjects = new System.Windows.Forms.Button();
            this.btnVoiceDrive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfigurePort = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutonomusTestDrive
            // 
            this.btnAutonomusTestDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnAutonomusTestDrive.Location = new System.Drawing.Point(48, 83);
            this.btnAutonomusTestDrive.Name = "btnAutonomusTestDrive";
            this.btnAutonomusTestDrive.Size = new System.Drawing.Size(96, 32);
            this.btnAutonomusTestDrive.TabIndex = 0;
            this.btnAutonomusTestDrive.Text = "Start";
            this.btnAutonomusTestDrive.UseVisualStyleBackColor = true;
            this.btnAutonomusTestDrive.Click += new System.EventHandler(this.btnAutonomusTestDrive_Click);
            // 
            // btnFindHumans
            // 
            this.btnFindHumans.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnFindHumans.Location = new System.Drawing.Point(411, 83);
            this.btnFindHumans.Name = "btnFindHumans";
            this.btnFindHumans.Size = new System.Drawing.Size(94, 32);
            this.btnFindHumans.TabIndex = 1;
            this.btnFindHumans.Text = "Start";
            this.btnFindHumans.UseVisualStyleBackColor = true;
            this.btnFindHumans.Click += new System.EventHandler(this.btnFindHumans_Click);
            // 
            // btnFindObjects
            // 
            this.btnFindObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnFindObjects.Location = new System.Drawing.Point(48, 194);
            this.btnFindObjects.Name = "btnFindObjects";
            this.btnFindObjects.Size = new System.Drawing.Size(96, 32);
            this.btnFindObjects.TabIndex = 2;
            this.btnFindObjects.Text = "Start";
            this.btnFindObjects.UseVisualStyleBackColor = true;
            this.btnFindObjects.Click += new System.EventHandler(this.btnFindObjects_Click);
            // 
            // btnVoiceDrive
            // 
            this.btnVoiceDrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnVoiceDrive.Location = new System.Drawing.Point(411, 194);
            this.btnVoiceDrive.Name = "btnVoiceDrive";
            this.btnVoiceDrive.Size = new System.Drawing.Size(94, 32);
            this.btnVoiceDrive.TabIndex = 3;
            this.btnVoiceDrive.Text = "Start";
            this.btnVoiceDrive.UseVisualStyleBackColor = true;
            this.btnVoiceDrive.Click += new System.EventHandler(this.btnVoiceDrive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Autonomous Test Drive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(406, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Find Humans";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(43, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Find Objects";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label4.Location = new System.Drawing.Point(406, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Voice Drive";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label5.Location = new System.Drawing.Point(43, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Configure Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label6.Location = new System.Drawing.Point(406, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Stop All";
            // 
            // btnConfigurePort
            // 
            this.btnConfigurePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnConfigurePort.Location = new System.Drawing.Point(48, 302);
            this.btnConfigurePort.Name = "btnConfigurePort";
            this.btnConfigurePort.Size = new System.Drawing.Size(96, 32);
            this.btnConfigurePort.TabIndex = 12;
            this.btnConfigurePort.Text = "Start";
            this.btnConfigurePort.UseVisualStyleBackColor = true;
            this.btnConfigurePort.Click += new System.EventHandler(this.btnConfigurePort_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnStopAll.Location = new System.Drawing.Point(411, 302);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(96, 32);
            this.btnStopAll.TabIndex = 13;
            this.btnStopAll.Text = "Stop";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(576, 372);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.btnConfigurePort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVoiceDrive);
            this.Controls.Add(this.btnFindObjects);
            this.Controls.Add(this.btnFindHumans);
            this.Controls.Add(this.btnAutonomusTestDrive);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(754, 540);
            this.MinimumSize = new System.Drawing.Size(554, 340);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutonomusTestDrive;
        private System.Windows.Forms.Button btnFindHumans;
        private System.Windows.Forms.Button btnFindObjects;
        private System.Windows.Forms.Button btnVoiceDrive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfigurePort;
        private System.Windows.Forms.Button btnStopAll;
    }
}

