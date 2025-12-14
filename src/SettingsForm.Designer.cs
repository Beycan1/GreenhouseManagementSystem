namespace Greenhouse
{
    partial class SettingsForm
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
            this.gbAutomationSettings = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numSetMaxSoil = new System.Windows.Forms.NumericUpDown();
            this.numSetMinSoil = new System.Windows.Forms.NumericUpDown();
            this.numSetMinLight = new System.Windows.Forms.NumericUpDown();
            this.numSetMaxLight = new System.Windows.Forms.NumericUpDown();
            this.numSetMinTemp = new System.Windows.Forms.NumericUpDown();
            this.numSetMaxTemp = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbAutomationSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMaxSoil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMinSoil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMinLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMaxLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMinTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMaxTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAutomationSettings
            // 
            this.gbAutomationSettings.Controls.Add(this.label7);
            this.gbAutomationSettings.Controls.Add(this.label5);
            this.gbAutomationSettings.Controls.Add(this.label6);
            this.gbAutomationSettings.Controls.Add(this.label4);
            this.gbAutomationSettings.Controls.Add(this.label3);
            this.gbAutomationSettings.Controls.Add(this.label1);
            this.gbAutomationSettings.Controls.Add(this.numSetMaxSoil);
            this.gbAutomationSettings.Controls.Add(this.numSetMinSoil);
            this.gbAutomationSettings.Controls.Add(this.numSetMinLight);
            this.gbAutomationSettings.Controls.Add(this.numSetMaxLight);
            this.gbAutomationSettings.Controls.Add(this.numSetMinTemp);
            this.gbAutomationSettings.Controls.Add(this.numSetMaxTemp);
            this.gbAutomationSettings.Location = new System.Drawing.Point(25, 30);
            this.gbAutomationSettings.Name = "gbAutomationSettings";
            this.gbAutomationSettings.Size = new System.Drawing.Size(241, 188);
            this.gbAutomationSettings.TabIndex = 0;
            this.gbAutomationSettings.TabStop = false;
            this.gbAutomationSettings.Text = "Настройки на автоматизацията:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Минимална влажност:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Максимална влажност:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Минимална светлина:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Максимална светлина:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Максимална температура:";
            // 
            // numSetMaxSoil
            // 
            this.numSetMaxSoil.Location = new System.Drawing.Point(155, 149);
            this.numSetMaxSoil.Name = "numSetMaxSoil";
            this.numSetMaxSoil.Size = new System.Drawing.Size(65, 20);
            this.numSetMaxSoil.TabIndex = 5;
            this.numSetMaxSoil.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // numSetMinSoil
            // 
            this.numSetMinSoil.Location = new System.Drawing.Point(155, 123);
            this.numSetMinSoil.Name = "numSetMinSoil";
            this.numSetMinSoil.Size = new System.Drawing.Size(65, 20);
            this.numSetMinSoil.TabIndex = 4;
            this.numSetMinSoil.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numSetMinLight
            // 
            this.numSetMinLight.Location = new System.Drawing.Point(155, 97);
            this.numSetMinLight.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numSetMinLight.Name = "numSetMinLight";
            this.numSetMinLight.Size = new System.Drawing.Size(65, 20);
            this.numSetMinLight.TabIndex = 3;
            this.numSetMinLight.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // numSetMaxLight
            // 
            this.numSetMaxLight.Location = new System.Drawing.Point(155, 71);
            this.numSetMaxLight.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numSetMaxLight.Name = "numSetMaxLight";
            this.numSetMaxLight.Size = new System.Drawing.Size(65, 20);
            this.numSetMaxLight.TabIndex = 2;
            this.numSetMaxLight.Value = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            // 
            // numSetMinTemp
            // 
            this.numSetMinTemp.Location = new System.Drawing.Point(155, 45);
            this.numSetMinTemp.Name = "numSetMinTemp";
            this.numSetMinTemp.Size = new System.Drawing.Size(65, 20);
            this.numSetMinTemp.TabIndex = 1;
            this.numSetMinTemp.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numSetMaxTemp
            // 
            this.numSetMaxTemp.Location = new System.Drawing.Point(155, 19);
            this.numSetMaxTemp.Name = "numSetMaxTemp";
            this.numSetMaxTemp.Size = new System.Drawing.Size(65, 20);
            this.numSetMaxTemp.TabIndex = 0;
            this.numSetMaxTemp.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Минимална температура:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(180, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Запиши";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отказ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 396);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbAutomationSettings);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.gbAutomationSettings.ResumeLayout(false);
            this.gbAutomationSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMaxSoil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMinSoil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMinLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMaxLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMinTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSetMaxTemp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAutomationSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSetMaxSoil;
        private System.Windows.Forms.NumericUpDown numSetMinSoil;
        private System.Windows.Forms.NumericUpDown numSetMinLight;
        private System.Windows.Forms.NumericUpDown numSetMaxLight;
        private System.Windows.Forms.NumericUpDown numSetMinTemp;
        private System.Windows.Forms.NumericUpDown numSetMaxTemp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}