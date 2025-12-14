namespace SmartGreenhouse
{
    partial class MainForm
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
            this.gbSensors = new System.Windows.Forms.GroupBox();
            this.lblSoil = new System.Windows.Forms.Label();
            this.lblLight = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.chkSectorD = new System.Windows.Forms.CheckBox();
            this.chkSectorC = new System.Windows.Forms.CheckBox();
            this.chkSectorB = new System.Windows.Forms.CheckBox();
            this.chkSectorA = new System.Windows.Forms.CheckBox();
            this.btnPesticides = new System.Windows.Forms.Button();
            this.btnGlass = new System.Windows.Forms.Button();
            this.btnWater = new System.Windows.Forms.Button();
            this.btnVent = new System.Windows.Forms.Button();
            this.simulationTimer = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.gbTestValues = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numSectorD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numSectorC = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numSectorB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTestHumidity = new System.Windows.Forms.Label();
            this.numSectorA = new System.Windows.Forms.NumericUpDown();
            this.lblTestLight = new System.Windows.Forms.Label();
            this.numLight = new System.Windows.Forms.NumericUpDown();
            this.lblTestTemp = new System.Windows.Forms.Label();
            this.numTemp = new System.Windows.Forms.NumericUpDown();
            this.gbDevices = new System.Windows.Forms.GroupBox();
            this.lblActiveSectors = new System.Windows.Forms.Label();
            this.lblPesticides = new System.Windows.Forms.Label();
            this.lblWater = new System.Windows.Forms.Label();
            this.lblGlass = new System.Windows.Forms.Label();
            this.lblRoof = new System.Windows.Forms.Label();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.btnSensorHistory = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.btnRegisterUser = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.gbSensors.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.gbTestValues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp)).BeginInit();
            this.gbDevices.SuspendLayout();
            this.gbSetting.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSensors
            // 
            this.gbSensors.Controls.Add(this.lblSoil);
            this.gbSensors.Controls.Add(this.lblLight);
            this.gbSensors.Controls.Add(this.lblTemp);
            this.gbSensors.Location = new System.Drawing.Point(25, 264);
            this.gbSensors.Name = "gbSensors";
            this.gbSensors.Size = new System.Drawing.Size(200, 164);
            this.gbSensors.TabIndex = 0;
            this.gbSensors.TabStop = false;
            this.gbSensors.Text = "Сензори";
            // 
            // lblSoil
            // 
            this.lblSoil.AutoSize = true;
            this.lblSoil.Location = new System.Drawing.Point(15, 87);
            this.lblSoil.Name = "lblSoil";
            this.lblSoil.Size = new System.Drawing.Size(151, 13);
            this.lblSoil.TabIndex = 2;
            this.lblSoil.Text = "Влажност почва по сектори:";
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(15, 56);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(83, 13);
            this.lblLight.TabIndex = 1;
            this.lblLight.Text = "Светлина: -- lux";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(15, 26);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(100, 13);
            this.lblTemp.TabIndex = 0;
            this.lblTemp.Text = "Температура: -- °C";
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.chkSectorD);
            this.gbControl.Controls.Add(this.chkSectorC);
            this.gbControl.Controls.Add(this.chkSectorB);
            this.gbControl.Controls.Add(this.chkSectorA);
            this.gbControl.Controls.Add(this.btnPesticides);
            this.gbControl.Controls.Add(this.btnGlass);
            this.gbControl.Controls.Add(this.btnWater);
            this.gbControl.Controls.Add(this.btnVent);
            this.gbControl.Location = new System.Drawing.Point(259, 63);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(200, 188);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Управление";
            // 
            // chkSectorD
            // 
            this.chkSectorD.AutoSize = true;
            this.chkSectorD.Location = new System.Drawing.Point(145, 152);
            this.chkSectorD.Name = "chkSectorD";
            this.chkSectorD.Size = new System.Drawing.Size(34, 17);
            this.chkSectorD.TabIndex = 7;
            this.chkSectorD.Text = "D";
            this.chkSectorD.UseVisualStyleBackColor = true;
            // 
            // chkSectorC
            // 
            this.chkSectorC.AutoSize = true;
            this.chkSectorC.Location = new System.Drawing.Point(106, 152);
            this.chkSectorC.Name = "chkSectorC";
            this.chkSectorC.Size = new System.Drawing.Size(33, 17);
            this.chkSectorC.TabIndex = 6;
            this.chkSectorC.Text = "C";
            this.chkSectorC.UseVisualStyleBackColor = true;
            // 
            // chkSectorB
            // 
            this.chkSectorB.AutoSize = true;
            this.chkSectorB.Location = new System.Drawing.Point(67, 152);
            this.chkSectorB.Name = "chkSectorB";
            this.chkSectorB.Size = new System.Drawing.Size(33, 17);
            this.chkSectorB.TabIndex = 5;
            this.chkSectorB.Text = "B";
            this.chkSectorB.UseVisualStyleBackColor = true;
            // 
            // chkSectorA
            // 
            this.chkSectorA.AutoSize = true;
            this.chkSectorA.Location = new System.Drawing.Point(28, 152);
            this.chkSectorA.Name = "chkSectorA";
            this.chkSectorA.Size = new System.Drawing.Size(33, 17);
            this.chkSectorA.TabIndex = 4;
            this.chkSectorA.Text = "A";
            this.chkSectorA.UseVisualStyleBackColor = true;
            // 
            // btnPesticides
            // 
            this.btnPesticides.Location = new System.Drawing.Point(41, 86);
            this.btnPesticides.Name = "btnPesticides";
            this.btnPesticides.Size = new System.Drawing.Size(124, 23);
            this.btnPesticides.TabIndex = 3;
            this.btnPesticides.Text = "Включи пръскачки";
            this.btnPesticides.UseVisualStyleBackColor = true;
            this.btnPesticides.Click += new System.EventHandler(this.btnPesticides_Click);
            // 
            // btnGlass
            // 
            this.btnGlass.Location = new System.Drawing.Point(41, 53);
            this.btnGlass.Name = "btnGlass";
            this.btnGlass.Size = new System.Drawing.Size(124, 23);
            this.btnGlass.TabIndex = 2;
            this.btnGlass.Text = "Затъмни стъклата";
            this.btnGlass.UseVisualStyleBackColor = true;
            this.btnGlass.Click += new System.EventHandler(this.btnGlass_Click);
            // 
            // btnWater
            // 
            this.btnWater.Location = new System.Drawing.Point(41, 118);
            this.btnWater.Name = "btnWater";
            this.btnWater.Size = new System.Drawing.Size(124, 23);
            this.btnWater.TabIndex = 1;
            this.btnWater.Text = "Пусни водата";
            this.btnWater.UseVisualStyleBackColor = true;
            this.btnWater.Click += new System.EventHandler(this.btnWater_Click);
            // 
            // btnVent
            // 
            this.btnVent.Location = new System.Drawing.Point(41, 21);
            this.btnVent.Name = "btnVent";
            this.btnVent.Size = new System.Drawing.Size(124, 23);
            this.btnVent.TabIndex = 0;
            this.btnVent.Text = "Отвори покрива";
            this.btnVent.UseVisualStyleBackColor = true;
            this.btnVent.Click += new System.EventHandler(this.btnRoof_Click);
            // 
            // simulationTimer
            // 
            this.simulationTimer.Enabled = true;
            this.simulationTimer.Interval = 2000;
            this.simulationTimer.Tick += new System.EventHandler(this.simulationTimer_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(21, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(239, 20);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Системата е в готовност...";
            // 
            // gbTestValues
            // 
            this.gbTestValues.Controls.Add(this.label4);
            this.gbTestValues.Controls.Add(this.numSectorD);
            this.gbTestValues.Controls.Add(this.label3);
            this.gbTestValues.Controls.Add(this.numSectorC);
            this.gbTestValues.Controls.Add(this.label2);
            this.gbTestValues.Controls.Add(this.numSectorB);
            this.gbTestValues.Controls.Add(this.label1);
            this.gbTestValues.Controls.Add(this.lblTestHumidity);
            this.gbTestValues.Controls.Add(this.numSectorA);
            this.gbTestValues.Controls.Add(this.lblTestLight);
            this.gbTestValues.Controls.Add(this.numLight);
            this.gbTestValues.Controls.Add(this.lblTestTemp);
            this.gbTestValues.Controls.Add(this.numTemp);
            this.gbTestValues.Location = new System.Drawing.Point(499, 158);
            this.gbTestValues.Name = "gbTestValues";
            this.gbTestValues.Size = new System.Drawing.Size(254, 225);
            this.gbTestValues.TabIndex = 3;
            this.gbTestValues.TabStop = false;
            this.gbTestValues.Text = "Тест на сензори:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Сектор D:";
            // 
            // numSectorD
            // 
            this.numSectorD.Location = new System.Drawing.Point(106, 189);
            this.numSectorD.Name = "numSectorD";
            this.numSectorD.Size = new System.Drawing.Size(120, 20);
            this.numSectorD.TabIndex = 11;
            this.numSectorD.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Сектор C:";
            // 
            // numSectorC
            // 
            this.numSectorC.Location = new System.Drawing.Point(106, 163);
            this.numSectorC.Name = "numSectorC";
            this.numSectorC.Size = new System.Drawing.Size(120, 20);
            this.numSectorC.TabIndex = 9;
            this.numSectorC.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Сектор B:";
            // 
            // numSectorB
            // 
            this.numSectorB.Location = new System.Drawing.Point(106, 136);
            this.numSectorB.Name = "numSectorB";
            this.numSectorB.Size = new System.Drawing.Size(120, 20);
            this.numSectorB.TabIndex = 7;
            this.numSectorB.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сектор А:";
            // 
            // lblTestHumidity
            // 
            this.lblTestHumidity.AutoSize = true;
            this.lblTestHumidity.Location = new System.Drawing.Point(40, 86);
            this.lblTestHumidity.Name = "lblTestHumidity";
            this.lblTestHumidity.Size = new System.Drawing.Size(60, 13);
            this.lblTestHumidity.TabIndex = 5;
            this.lblTestHumidity.Text = "Влажност:";
            // 
            // numSectorA
            // 
            this.numSectorA.Location = new System.Drawing.Point(106, 110);
            this.numSectorA.Name = "numSectorA";
            this.numSectorA.Size = new System.Drawing.Size(120, 20);
            this.numSectorA.TabIndex = 4;
            this.numSectorA.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblTestLight
            // 
            this.lblTestLight.AutoSize = true;
            this.lblTestLight.Location = new System.Drawing.Point(40, 55);
            this.lblTestLight.Name = "lblTestLight";
            this.lblTestLight.Size = new System.Drawing.Size(58, 13);
            this.lblTestLight.TabIndex = 3;
            this.lblTestLight.Text = "Светлина:";
            // 
            // numLight
            // 
            this.numLight.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLight.Location = new System.Drawing.Point(106, 53);
            this.numLight.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numLight.Name = "numLight";
            this.numLight.Size = new System.Drawing.Size(120, 20);
            this.numLight.TabIndex = 2;
            this.numLight.Value = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            // 
            // lblTestTemp
            // 
            this.lblTestTemp.AutoSize = true;
            this.lblTestTemp.Location = new System.Drawing.Point(23, 23);
            this.lblTestTemp.Name = "lblTestTemp";
            this.lblTestTemp.Size = new System.Drawing.Size(77, 13);
            this.lblTestTemp.TabIndex = 1;
            this.lblTestTemp.Text = "Температура:";
            // 
            // numTemp
            // 
            this.numTemp.Location = new System.Drawing.Point(106, 21);
            this.numTemp.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTemp.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numTemp.Name = "numTemp";
            this.numTemp.Size = new System.Drawing.Size(120, 20);
            this.numTemp.TabIndex = 0;
            this.numTemp.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // gbDevices
            // 
            this.gbDevices.Controls.Add(this.lblActiveSectors);
            this.gbDevices.Controls.Add(this.lblPesticides);
            this.gbDevices.Controls.Add(this.lblWater);
            this.gbDevices.Controls.Add(this.lblGlass);
            this.gbDevices.Controls.Add(this.lblRoof);
            this.gbDevices.Location = new System.Drawing.Point(25, 63);
            this.gbDevices.Name = "gbDevices";
            this.gbDevices.Size = new System.Drawing.Size(200, 188);
            this.gbDevices.TabIndex = 4;
            this.gbDevices.TabStop = false;
            this.gbDevices.Text = "Състояние на устройствата:";
            // 
            // lblActiveSectors
            // 
            this.lblActiveSectors.AutoSize = true;
            this.lblActiveSectors.Location = new System.Drawing.Point(19, 151);
            this.lblActiveSectors.Name = "lblActiveSectors";
            this.lblActiveSectors.Size = new System.Drawing.Size(127, 13);
            this.lblActiveSectors.TabIndex = 11;
            this.lblActiveSectors.Text = "Активни сектори: Няма";
            // 
            // lblPesticides
            // 
            this.lblPesticides.AutoSize = true;
            this.lblPesticides.Location = new System.Drawing.Point(18, 91);
            this.lblPesticides.Name = "lblPesticides";
            this.lblPesticides.Size = new System.Drawing.Size(134, 13);
            this.lblPesticides.TabIndex = 3;
            this.lblPesticides.Text = "Пръскане: ИЗКЛЮЧЕНО";
            // 
            // lblWater
            // 
            this.lblWater.AutoSize = true;
            this.lblWater.Location = new System.Drawing.Point(19, 123);
            this.lblWater.Name = "lblWater";
            this.lblWater.Size = new System.Drawing.Size(133, 13);
            this.lblWater.TabIndex = 2;
            this.lblWater.Text = "Поливане: ИЗКЛЮЧЕНО";
            // 
            // lblGlass
            // 
            this.lblGlass.AutoSize = true;
            this.lblGlass.Location = new System.Drawing.Point(18, 58);
            this.lblGlass.Name = "lblGlass";
            this.lblGlass.Size = new System.Drawing.Size(118, 13);
            this.lblGlass.TabIndex = 1;
            this.lblGlass.Text = "Стъкла: ПРОЗРАЧНИ";
            // 
            // lblRoof
            // 
            this.lblRoof.AutoSize = true;
            this.lblRoof.Location = new System.Drawing.Point(18, 26);
            this.lblRoof.Name = "lblRoof";
            this.lblRoof.Size = new System.Drawing.Size(109, 13);
            this.lblRoof.TabIndex = 0;
            this.lblRoof.Text = "Покрив: ЗАТВОРЕН";
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(31, 22);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(134, 23);
            this.btnSchedule.TabIndex = 5;
            this.btnSchedule.Text = "График";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(31, 54);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(134, 23);
            this.btnReports.TabIndex = 6;
            this.btnReports.Text = "Отчет на действията";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.btnSettings);
            this.gbSetting.Controls.Add(this.btnSensorHistory);
            this.gbSetting.Controls.Add(this.btnSchedule);
            this.gbSetting.Controls.Add(this.btnReports);
            this.gbSetting.Location = new System.Drawing.Point(259, 264);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(200, 164);
            this.gbSetting.TabIndex = 7;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "Настройки:";
            // 
            // btnSensorHistory
            // 
            this.btnSensorHistory.Location = new System.Drawing.Point(31, 87);
            this.btnSensorHistory.Name = "btnSensorHistory";
            this.btnSensorHistory.Size = new System.Drawing.Size(134, 23);
            this.btnSensorHistory.TabIndex = 7;
            this.btnSensorHistory.Text = "История на сензори";
            this.btnSensorHistory.UseVisualStyleBackColor = true;
            this.btnSensorHistory.Click += new System.EventHandler(this.btnSensorHistory_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.ForeColor = System.Drawing.Color.Red;
            this.btnLogout.Location = new System.Drawing.Point(9, 47);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(50, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Изход";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentUser.Location = new System.Drawing.Point(6, 24);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(79, 13);
            this.lblCurrentUser.TabIndex = 9;
            this.lblCurrentUser.Text = "Потребител: --";
            // 
            // gbUser
            // 
            this.gbUser.Controls.Add(this.btnRegisterUser);
            this.gbUser.Controls.Add(this.lblCurrentUser);
            this.gbUser.Controls.Add(this.btnLogout);
            this.gbUser.Location = new System.Drawing.Point(499, 63);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(254, 89);
            this.gbUser.TabIndex = 10;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "Потребител:";
            // 
            // btnRegisterUser
            // 
            this.btnRegisterUser.Location = new System.Drawing.Point(65, 47);
            this.btnRegisterUser.Name = "btnRegisterUser";
            this.btnRegisterUser.Size = new System.Drawing.Size(89, 23);
            this.btnRegisterUser.TabIndex = 10;
            this.btnRegisterUser.Text = "Регистрация";
            this.btnRegisterUser.UseVisualStyleBackColor = true;
            this.btnRegisterUser.Click += new System.EventHandler(this.btnRegisterUser_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(31, 119);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(134, 23);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 440);
            this.Controls.Add(this.gbUser);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.gbTestValues);
            this.Controls.Add(this.gbDevices);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbSensors);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbSensors.ResumeLayout(false);
            this.gbSensors.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.gbTestValues.ResumeLayout(false);
            this.gbTestValues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectorA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTemp)).EndInit();
            this.gbDevices.ResumeLayout(false);
            this.gbDevices.PerformLayout();
            this.gbSetting.ResumeLayout(false);
            this.gbUser.ResumeLayout(false);
            this.gbUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSensors;
        private System.Windows.Forms.Label lblSoil;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Timer simulationTimer;
        private System.Windows.Forms.Button btnWater;
        private System.Windows.Forms.Button btnVent;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox gbTestValues;
        private System.Windows.Forms.NumericUpDown numTemp;
        private System.Windows.Forms.Label lblTestLight;
        private System.Windows.Forms.NumericUpDown numLight;
        private System.Windows.Forms.Label lblTestTemp;
        private System.Windows.Forms.Label lblTestHumidity;
        private System.Windows.Forms.NumericUpDown numSectorA;
        private System.Windows.Forms.GroupBox gbDevices;
        private System.Windows.Forms.Label lblWater;
        private System.Windows.Forms.Label lblGlass;
        private System.Windows.Forms.Label lblRoof;
        private System.Windows.Forms.Button btnGlass;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnPesticides;
        private System.Windows.Forms.Label lblPesticides;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.Button btnRegisterUser;
        private System.Windows.Forms.Button btnSensorHistory;
        private System.Windows.Forms.Label lblActiveSectors;
        private System.Windows.Forms.CheckBox chkSectorD;
        private System.Windows.Forms.CheckBox chkSectorC;
        private System.Windows.Forms.CheckBox chkSectorB;
        private System.Windows.Forms.CheckBox chkSectorA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSectorD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSectorC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSectorB;
        private System.Windows.Forms.Button btnSettings;
    }
}