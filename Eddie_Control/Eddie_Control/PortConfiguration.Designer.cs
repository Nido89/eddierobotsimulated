namespace Eddie_Control
{
    partial class frmPortConfiguration
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
            this.btnSaveConfiguration = new System.Windows.Forms.Button();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your System current Serial Port:";
            // 
            // btnSaveConfiguration
            // 
            this.btnSaveConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnSaveConfiguration.Location = new System.Drawing.Point(168, 104);
            this.btnSaveConfiguration.Name = "btnSaveConfiguration";
            this.btnSaveConfiguration.Size = new System.Drawing.Size(75, 31);
            this.btnSaveConfiguration.TabIndex = 2;
            this.btnSaveConfiguration.Text = "Save";
            this.btnSaveConfiguration.UseVisualStyleBackColor = true;
            this.btnSaveConfiguration.Click += new System.EventHandler(this.btnSaveConfiguration_Click);
            // 
            // numUpDown
            // 
            this.numUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDown.Location = new System.Drawing.Point(338, 46);
            this.numUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(45, 26);
            this.numUpDown.TabIndex = 3;
            this.numUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUpDown.ValueChanged += new System.EventHandler(this.numUpDown_ValueChanged);
            // 
            // frmPortConfiguration
            // 
            this.AcceptButton = this.btnSaveConfiguration;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 180);
            this.Controls.Add(this.numUpDown);
            this.Controls.Add(this.btnSaveConfiguration);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmPortConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Port Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveConfiguration;
        private System.Windows.Forms.NumericUpDown numUpDown;
    }
}