using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Greenhouse;

namespace SmartGreenhouse
{
    public partial class MainForm : Form
    {
        string userRole;
        string username;
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GreenhouseDB;Trusted_Connection=True;";

        bool isRoofOpen = false;
        bool isWateringOn = false;
        bool isPesticideOn = false;
        bool areCurtainsClosed = false;

        bool isValveAOpen = false;
        bool isValveBOpen = false;
        bool isValveCOpen = false;
        bool isValveDOpen = false;


        int statusMesaageCounter = 0;
        int databaseLogCounter = 0;
        int scheduleCheckCounter = 0;

        public static double LimitMaxTemp = 30;
        public static double LimitMinTemp = 20;
        public static double LimitMaxLight = 80000;
        public static double LimitMinLight = 50000;
        public static double LimitMinSoil = 30;
        public static double LimitMaxSoil = 70;

        public MainForm(string role, string user)
        {
            InitializeComponent();
            this.userRole = role;
            this.username = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = $"Потребител: {username}";
            
            if (userRole == "Worker")
            {
                gbSetting.Visible = false;
                btnRegisterUser.Visible = false;
            }
            
            simulationTimer.Start();
            lblStatus.Text = "Системата е активна.";
            LoadDeviceStatesFromDB();
            UpdateDeviceLabels();
        }

        private void simulationTimer_Tick(object sender, EventArgs e)
        {
            double temp = (double)numTemp.Value;
            double light = (double)numLight.Value;
            double soilA = (double)numSectorA.Value;
            double soilB = (double)numSectorB.Value;
            double soilC = (double)numSectorC.Value;
            double soilD = (double)numSectorD.Value;

            double localMaxTemp = LimitMaxTemp;
            double localMinTemp = LimitMinTemp;
            double localMaxLight = LimitMaxLight;
            double localMinLight = LimitMinLight;
            double localMinSoil = LimitMinSoil;
            double localMaxSoil = LimitMaxSoil;

            lblTemp.Text = $"Температура: {temp} °C";
            lblLight.Text = $"Светлина: {light} lux";
            lblSoil.Text = $"Влажност на почвата по сектори:\n\rA: {soilA} % | B: {soilB} % | C: {soilC} % | D: {soilD} %";

            bool actionHappened = false;

            // Автоматизация за температура
            if (temp >= localMaxTemp && !isRoofOpen)
            {
                OpenRoof($"Висока температура {temp}°C!", "System");
                actionHappened = true;
            }
            else if (temp <= localMinTemp && isRoofOpen)
            {
                CloseRoof($"Ниска температура {temp}°C!", "System");
                actionHappened = true;
            }
            
            // Автоматизация за поливане
            if (soilA <= localMinSoil && !isValveAOpen)
            {
                UpdateDeviceStateInDB("Valve Sector A", 1);
                isValveAOpen = true;
            }
            else if (soilA >= localMaxSoil && isValveAOpen)
            {
                UpdateDeviceStateInDB("Valve Sector A", 0);
                isValveAOpen = false;
            }

            if (soilB <= localMinSoil && !isValveBOpen)
            {
                UpdateDeviceStateInDB("Valve Sector B", 1);
                isValveBOpen = true;
            }
            else if (soilB >= localMaxSoil && isValveBOpen)
            {
                UpdateDeviceStateInDB("Valve Sector B", 0);
                isValveBOpen = false;
            }

            if (soilC <= localMinSoil && !isValveCOpen)
            {
                UpdateDeviceStateInDB("Valve Sector C", 1);
                isValveCOpen = true;
            }
            else if (soilC >= localMaxSoil && isValveCOpen)
            {
                UpdateDeviceStateInDB("Valve Sector C", 0);
                isValveCOpen = false;
            }

            if (soilD <= localMinSoil && !isValveDOpen)
            {
                UpdateDeviceStateInDB("Valve Sector D", 1);
                isValveDOpen = true;
            }
            else if (soilD >= localMaxSoil && isValveDOpen)
            {
                UpdateDeviceStateInDB("Valve Sector D", 0);
                isValveDOpen = false;
            }

            bool needWater  = isValveAOpen || isValveBOpen || isValveCOpen || isValveDOpen;

            if (needWater && !isWateringOn)
            {
                StartWatering("Автоматично поливане поради ниска влажност на почвата.", "System");
                actionHappened = true;
            }
            else if (!needWater && isWateringOn)
            {
                StopWatering("Автоматично спиране на поливането - влажността е в норма.", "System");
                actionHappened = true;
            }


            // Автоматизация за затъмняване на стъклата
            if (light >= localMaxLight)
            {
                if (temp <= 25)
                {
                    if (areCurtainsClosed)
                    {
                        StopGlass($"Температурата е {temp}°C. Стъклата възстановяват прозрачността си.", "System");
                        actionHappened = true;
                    }
                }
                else
                {
                    if (!areCurtainsClosed)
                    {
                        StartGlass($"Силно слънце ({light} lux) и температура ({temp}°C). Стъклата се затъмняват.", "System");
                        actionHappened = true;
                    }
                }
            }
            else if (light <= localMinLight)
            {
                if (areCurtainsClosed)
                {
                    StopGlass("Светлината е в норма. Възстановяване прозрачността на стъклата.", "System");
                    actionHappened = true;
                }
            }

            if (!actionHappened)
            {
                if (statusMesaageCounter > 0)
                {
                    statusMesaageCounter--;
                }
                else
                {
                    if (lblStatus.Text != "Системата е активна.")
                    {
                        lblStatus.Text = "Системата е активна.";
                        lblStatus.ForeColor = Color.Black;
                    }
                }
            }

            databaseLogCounter++;
            if (databaseLogCounter >= 60)
            {
                SaveSensorData("Temperature Sensor", temp);
                SaveSensorData("Light Sensor", light);
                SaveSensorData("Humidity Sensor A", soilA);
                SaveSensorData("Humidity Sensor B", soilB);
                SaveSensorData("Humidity Sensor C", soilC);
                SaveSensorData("Humidity Sensor D", soilD);
                databaseLogCounter = 0;
            }

            scheduleCheckCounter++;
            if (scheduleCheckCounter >= 1)
            {
                CheckScheduleEvents();
                scheduleCheckCounter = 0;
            }

            UpdateActiveSectorsLabel();
        }

        private void UpdateScheduleStatus(int id, string newStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Schedules SET Status = @status WHERE ScheduleId = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Status Update Error: " + ex.Message);
            }
        }

        private void CheckScheduleEvents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ScheduleId, ActionName, Sector, DurationMinutes 
                                     FROM Schedules 
                                     WHERE Status = 'Pending' AND ScheduledDate <= GETDATE()";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ScheduleId"]);
                                string action = reader["ActionName"].ToString();
                                string sector = reader["Sector"].ToString();
                                int duration = Convert.ToInt32(reader["DurationMinutes"]);

                                StartTaskDevice(action, sector, duration);
                                UpdateScheduleStatus(id, "InProgress");
                            }
                        }
                    }
                    string stopQuery = @"SELECT ScheduleId, ActionName, ScheduledDate, DurationMinutes 
                                 FROM Schedules 
                                 WHERE Status = 'InProgress'";

                    using (SqlCommand cmd = new SqlCommand(stopQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ScheduleId"]);
                                string action = reader["ActionName"].ToString();
                                DateTime startDate = Convert.ToDateTime(reader["ScheduledDate"]);
                                int duration = Convert.ToInt32(reader["DurationMinutes"]);

                                DateTime endTime = startDate.AddMinutes(duration);

                                if (DateTime.Now >= endTime)
                                {
                                    StopTaskDevice(action, "Scheduler");
                                    UpdateScheduleStatus(id, "Finished");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Грешка при проверка на планираните събития.");
            }
        }

        private void UpdateActiveSectorsLabel()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DeviceName FROM Devices WHERE DeviceName LIKE 'Valve%' AND IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            string activeSectors = "";
                            while (reader.Read())
                            {
                                string fullName = reader["DeviceName"].ToString();
                                string shortName = fullName.Replace("Valve Sector", "");

                                if (activeSectors != "")
                                {
                                    activeSectors += ", ";
                                }
                                activeSectors += shortName;
                            }

                            if (string.IsNullOrEmpty(activeSectors))
                            {
                                lblActiveSectors.Text = "Активни сектори: Няма";
                                lblActiveSectors.ForeColor = Color.Black;
                            }
                            else
                            {
                                lblActiveSectors.Text = $"Активни сектори: {activeSectors}";
                                lblActiveSectors.ForeColor = Color.Blue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void StartTaskDevice(string action, string sector, int duration)
        {
            string logMsg = $"ГРАФИК СТАРТ: '{action}' за {duration} мин.";

            if (action.Contains("Поливане"))
            {
                string activeSectorsLog = "";

                if (sector == "Сектор A" || sector == "Всички сектори")
                {
                    UpdateDeviceStateInDB("Valve Sector A", 1);
                    isValveAOpen = true;
                    activeSectorsLog += "A ";
                }
                if (sector == "Сектор B" || sector == "Всички сектори")
                {
                    UpdateDeviceStateInDB("Valve Sector B", 1);
                    isValveBOpen = true;
                    activeSectorsLog += "B ";
                }
                if (sector == "Сектор C" || sector == "Всички сектори")
                {
                    UpdateDeviceStateInDB("Valve Sector C", 1);
                    isValveCOpen = true;
                    activeSectorsLog += "C ";
                }
                if (sector == "Сектор D" || sector == "Всички сектори")
                {
                    UpdateDeviceStateInDB("Valve Sector D", 1);
                    isValveDOpen = true;
                    activeSectorsLog += "D ";
                }

                if (!isWateringOn)
                {
                    StartWatering($"ГРАФИК: Активиране на поливната система за {activeSectorsLog}.", "Scheduler");
                }
                else
                {
                    lblActiveSectors.Text = $"ГРАФИК: Активиране на поливна система за {activeSectorsLog}.";
                }
            }
            else if (action.Contains("Пръскане"))
            {
                if (!isPesticideOn) StartPesticides(logMsg, "Scheduler");
            }
            else if (action.Contains("Покрив"))
            {
                if (!isRoofOpen) OpenRoof(logMsg, "Scheduler");
            }
            else if (action.Contains("Затъмняване"))
            {
                if (!areCurtainsClosed) StartGlass(logMsg, "Scheduler");
            }
            lblStatus.Text = $"ГРАФИК: Стартирано '{action}' за {duration} мин.";
            lblStatus.ForeColor = Color.BlueViolet;

        }

        private void StopTaskDevice(string action, string initiator)
        {
            string logMsg = $"ГРАФИК СТОП: Времето за '{action}' изтече.";

            if (action.Contains("Поливане"))
            {
                if (isWateringOn) StopWatering(logMsg, initiator);
                UpdateDeviceStateInDB("Valve Sector A", 0);
                UpdateDeviceStateInDB("Valve Sector B", 0);
                UpdateDeviceStateInDB("Valve Sector C", 0);
                UpdateDeviceStateInDB("Valve Sector D", 0);
                isValveAOpen = false;
                isValveBOpen = false;
                isValveCOpen = false;
                isValveDOpen = false;
            }
            else if (action.Contains("Пръскане"))
            {
                if (isPesticideOn) StopPesticides(logMsg, initiator);
            }
            else if (action.Contains("Покрив"))
            {
                if (isRoofOpen) CloseRoof(logMsg, initiator);
            }
            else if (action.Contains("Затъмняване"))
            {
                if (areCurtainsClosed) StartGlass(logMsg, "Scheduler");
            }

            lblStatus.Text = $"ГРАФИК: Приключи {action}";
            lblStatus.ForeColor = Color.Green;
        }

        private void LoadDeviceStatesFromDB()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT DeviceName, IsActive FROM Devices";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["DeviceName"].ToString();
                                double val = Convert.ToDouble(reader["IsActive"]);
                                bool isActive = (val == 1);

                                if (name == "Roof Motor")
                                {
                                    isRoofOpen = isActive;
                                }
                                else if (name == "Water Pump")
                                {
                                    isWateringOn = isActive;
                                }
                                else if (name == "Windows")
                                {
                                    areCurtainsClosed = isActive;
                                }
                                else if (name == "Pesticide Sprayers")
                                {
                                    isPesticideOn = isActive;
                                }
                                else if (name == "Valve Sector A")
                                {
                                    isValveAOpen = isActive;
                                }
                                else if (name == "Valve Sector B")
                                {
                                    isValveBOpen = isActive;
                                }
                                else if (name == "Valve Sector C")
                                {
                                    isValveCOpen = isActive;
                                }
                                else if (name == "Valve Sector D")
                                {
                                    isValveDOpen = isActive;
                                }
                            }    
                        }
                    }
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Грешка при зареждане на състоянието на устройствата от базата данни.");
            }
        }

        private void UpdateDeviceStateInDB(string deviceName, double value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Devices SET IsActive = @val, LastUpdated = GETDATE() WHERE DeviceName = @name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@val", value);
                        cmd.Parameters.AddWithValue("@name", deviceName);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            System.Diagnostics.Debug.WriteLine($"Устройството '{deviceName}' не е намерено в базата данни!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void SaveSensorData(string sensorName, double value)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO SensorLog (SensorId, Value, ReadingTime) 
                                     SELECT SensorID, @val, GETDATE()
                                     FROM Sensors
                                     WHERE SensorName = @name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@val", value);
                        cmd.Parameters.AddWithValue("@name", sensorName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void UpdateDeviceLabels()
        {
            // Покрив
            if (isRoofOpen)
            {
                lblRoof.Text = "Покрив: ОТВОРЕН";
                lblRoof.ForeColor = Color.Red;
                btnVent.Text = "Затвори покрива";
            }
            else
            {
                lblRoof.Text = "Покрив: ЗАТВОРЕН";
                lblRoof.ForeColor = Color.Black;
                btnVent.Text = "Отвори покрива";
            }

            // Стъкла
            if (areCurtainsClosed)
            {
                lblGlass.Text = "Стъкла: ЗАТЪМНЕНИ";
                lblGlass.ForeColor = Color.OrangeRed;
                btnGlass.Text = "Изсветли стъклата";
            }
            else
            {
                lblGlass.Text = "Стъкла: ПРОЗРАЧНИ";
                lblGlass.ForeColor = Color.Black;
                btnGlass.Text = "Затъмни стъклата";
            }

            // Поливане
            if (isWateringOn)
            {
                lblWater.Text = "Поливане: АКТИВНО";
                lblWater.ForeColor = Color.Blue;
                btnWater.Text = "Спри водата";
            }
            else
            {
                lblWater.Text = "Поливане: ИЗКЛЮЧЕНО";
                lblWater.ForeColor = Color.Black;
                btnWater.Text = "Пусни водата";
            }

            if (isPesticideOn)
            {
                lblPesticides.Text = "Пръскане: АКТИВНО";
                lblPesticides.ForeColor = Color.DarkMagenta;
                btnPesticides.Text = "Изключи пръскачки";
            }
            else
            {
                lblPesticides.Text = "Пръскане: ИЗКЛЮЧЕНО";
                lblPesticides.ForeColor = Color.Black;
                btnPesticides.Text = "Включи пръскачки";
            }
        }

        // Помощни функции за действия
        private void OpenRoof(string msg, string initiator)
        {
            if (isPesticideOn)
            {
                lblStatus.Text = "НЕ МОЖЕ ДА СЕ ОТВОРИ ПОКРИВА ПО ВРЕМЕ НА ПРЪСКАНЕ С ПЕСТИЦИДИ!";
                lblStatus.ForeColor = Color.Red;
                statusMesaageCounter = 5;

                LogOperation("Опит за отваряне на покрив", "БЛОКИРАНО: Активна е системана за пръскане", initiator);
                return;
            }

            isRoofOpen = true;
            UpdateDeviceLabels();

            lblStatus.Text = $"Отваряне на покрива.";
            lblStatus.ForeColor = Color.OrangeRed;

            statusMesaageCounter = 3;
            LogOperation("Отваряне на покрива.", msg, initiator);

            UpdateDeviceStateInDB("Roof Motor", 1);
        }

        private void CloseRoof(string msg, string initiator)
        {
            isRoofOpen = false;
            UpdateDeviceLabels();

            lblStatus.Text = $"Затваряне на покрива.";
            lblStatus.ForeColor = Color.Blue;

            statusMesaageCounter = 3;
            LogOperation("Затваряне на покрива.", msg, initiator);

            UpdateDeviceStateInDB("Roof Motor", 0);
        }

        private void StartGlass(string msg, string initiator)
        {
            areCurtainsClosed = true;
            UpdateDeviceLabels();

            lblStatus.Text = $"Затъмняване на стъклата.";
            lblStatus.ForeColor = Color.OrangeRed;

            statusMesaageCounter = 3;
            LogOperation("Затъмняване на стъклата.", msg, initiator);

            UpdateDeviceStateInDB("Windows", 1);
        }

        private void StopGlass(string msg, string initiator)
        {
            areCurtainsClosed = false;
            UpdateDeviceLabels();

            lblStatus.Text = $"Възстановяване прозрачността на стъклата.";
            lblStatus.ForeColor = Color.Green;

            statusMesaageCounter = 3;
            LogOperation("Възстановяване прозрачността на стъклата.", msg, initiator);

            UpdateDeviceStateInDB("Windows", 0);
        }

        private void StartWatering(string msg, string initiator)
        {
            isWateringOn = true;
            UpdateDeviceLabels();

            lblStatus.Text = $"Активиране на поливната система.";
            lblStatus.ForeColor = Color.OrangeRed;

            statusMesaageCounter = 3;
            LogOperation("Активиране на поливната система.", msg, initiator);

            UpdateDeviceStateInDB("Water Pump", 1);
        }

        private void StopWatering(string msg, string initiator)
        {
            isWateringOn = false;
            UpdateDeviceLabels();

            lblStatus.Text = $"Деактивиране на поливната система.";
            lblStatus.ForeColor = Color.Green;

            statusMesaageCounter = 3;
            LogOperation("Деактивиране на поливната система.", msg, initiator);

            UpdateDeviceStateInDB("Water Pump", 0);
        }

        private void StartPesticides(string msg, string initiator)
        {
            if (isRoofOpen)
            {
                CloseRoof("Покривът се затваря поради пръскане.", initiator);
            }

            isPesticideOn = true;
            UpdateDeviceLabels();

            lblStatus.Text = $"ОПАСНОСТ: Пръскане с пестициди! Достъпът забранен.";
            lblStatus.ForeColor = Color.DarkMagenta;
            statusMesaageCounter = 5;

            LogOperation("Пръскане с пестициди.", msg, initiator);
            UpdateDeviceStateInDB("Pesticide Sprayers", 1);
        }

        private void StopPesticides(string msg, string initiator)
        {
            isPesticideOn = false;
            UpdateDeviceLabels();

            lblStatus.Text = "Пръскането с пестициди е приключи. Достъпът разрешен.";
            lblStatus.ForeColor = Color.Green;
            statusMesaageCounter = 5;

            LogOperation("Край на пръскането.", msg, initiator);
            UpdateDeviceStateInDB("Pesticide Sprayers", 0);
        }   

        // Функции за управление с бутони
        private void btnRoof_Click(object sender, EventArgs e)
        {
            if (isRoofOpen)
            {
                CloseRoof("Ръчно от потребител", this.username);
            }
            else
            {
                OpenRoof("Ръчно от потребител", this.username);
            }
        }

        private void btnGlass_Click(object sender, EventArgs e)
        {
            if (areCurtainsClosed)
            {
                StopGlass("Ръчно от потребител", this.username);
            }
            else
            {
                StartGlass("Ръчно от потребител", this.username);
            }
        }

        private void btnPesticides_Click(object sender, EventArgs e)
        {
            if (isPesticideOn)
            {
                StopPesticides("Ръчно от потребител", this.username);
            }
            else
            {
                StartPesticides("Ръчно от потребител", this.username);
            }
        }

        private void btnWater_Click(object sender, EventArgs e)
        {
            if (isWateringOn)
            {
                StopWatering("Ръчно от потребител", this.username);

                UpdateDeviceStateInDB("Valve Sector A", 0);
                isValveAOpen = false;
                UpdateDeviceStateInDB("Valve Sector B", 0);
                isValveBOpen = false;
                UpdateDeviceStateInDB("Valve Sector C", 0);
                isValveCOpen = false;
                UpdateDeviceStateInDB("Valve Sector D", 0);
                isValveDOpen = false;

                chkSectorA.Checked = false;
                chkSectorB.Checked = false;
                chkSectorC.Checked = false;
                chkSectorD.Checked = false;
            }
            else
            {
                if (!chkSectorA.Checked && !chkSectorB.Checked && !chkSectorC.Checked && !chkSectorD.Checked)
                {
                    chkSectorA.Checked = true;
                    chkSectorB.Checked = true;
                    chkSectorC.Checked = true;
                    chkSectorD.Checked = true;
                }


                string activeSectors = "";
                if (chkSectorA.Checked)                 {
                    UpdateDeviceStateInDB("Valve Sector A", 1);
                    isValveAOpen = true;
                    activeSectors += "A ";
                }
                if (chkSectorB.Checked)
                {
                    UpdateDeviceStateInDB("Valve Sector B", 1);
                    isValveBOpen = true;
                    activeSectors += "B ";
                }
                if (chkSectorC.Checked)
                {
                    UpdateDeviceStateInDB("Valve Sector C", 1);
                    isValveCOpen = true;
                    activeSectors += "C ";
                }
                if (chkSectorD.Checked)
                {
                    UpdateDeviceStateInDB("Valve Sector D", 1);
                    isValveDOpen = true;
                    activeSectors += "D ";
                }
                StartWatering($"Ръчно от потребител (Сектори: {activeSectors})", this.username);
            }
        }



        // Функция за запис на логове в базата данни
        private void LogOperation(string op, string det, string init)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO OperationsLog (OperationName, Details, Initiator, OpTime) VALUES (@o, @d, @i, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@o", op);
                        cmd.Parameters.AddWithValue("@d", det);
                        cmd.Parameters.AddWithValue("@i", init);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ScheduleForm schedule = new ScheduleForm(this.username);
            schedule.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportForm = new ReportsForm();
            reportForm.ShowDialog();
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void btnSensorHistory_Click(object sender, EventArgs e)
        {
            SensorHistoryForm historyForm = new SensorHistoryForm();
            historyForm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }
    }
}