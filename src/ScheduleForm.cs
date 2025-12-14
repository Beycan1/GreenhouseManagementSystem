using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Greenhouse
{
    public partial class ScheduleForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GreenhouseDB;Trusted_Connection=True;";
        string currentUser;
        public ScheduleForm(string user)
        {
            InitializeComponent();
            this.currentUser = user;
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            string action = cmbAction.Text;
            string sector = cmbSector.Text;
            int duration = (int)numDuration.Value;
            DateTime scheduledTime = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;

            if (scheduledTime < DateTime.Now)
            {
                MessageBox.Show("Не можете да планирате събития в миналото!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Schedules (ActionName, Sector, ScheduledDate, DurationMinutes, Status) VALUES (@act, @sector, @date, @dur, 'Pending')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@act", action);
                        cmd.Parameters.AddWithValue("@sector", sector);
                        cmd.Parameters.AddWithValue("@date", scheduledTime);
                        cmd.Parameters.AddWithValue("@dur", duration);

                        cmd.ExecuteNonQuery();
                    }
                }
                string logDetails = $"{action} в {sector} за {scheduledTime:dd.MM.yyyy HH:mm} с продължителност: {duration} мин";
                LogToHistory("Планиране на задача", logDetails);
                LoadScheduleData();
                MessageBox.Show("Задачата е добавена успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при запис: " + ex.Message);
            }
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ScheduleId, ScheduledDate, ActionName, Sector, DurationMinutes, Status FROM Schedules ORDER BY ScheduledDate ASC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSchedule.DataSource = dt;

                    dgvSchedule.Columns["ScheduleId"].Visible = false;
                    dgvSchedule.Columns["ScheduledDate"].HeaderText = "Дата и Час";
                    dgvSchedule.Columns["ActionName"].HeaderText = "Дейност";
                    dgvSchedule.Columns["Sector"].HeaderText = "Сектор";
                    dgvSchedule.Columns["DurationMinutes"].HeaderText = "Мин.";
                    dgvSchedule.Columns["Status"].HeaderText = "Статус";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на списъка: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.SelectedRows.Count == 0)
            {
                MessageBox.Show("Моля, първо изберете ред от таблицата, който искате да изтриете.");
                return;
            }

            int idToDelete = Convert.ToInt32(dgvSchedule.SelectedRows[0].Cells["ScheduleId"].Value);

            var confirmResult = MessageBox.Show("Сигурни ли сте, че искате да изтриете тази задача?",
                                             "Потвърждение за изтриване",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                string taskName = dgvSchedule.SelectedRows[0].Cells["ActionName"].Value.ToString();
                string taskDate = dgvSchedule.SelectedRows[0].Cells["ScheduledDate"].Value.ToString();
                string taskSector = dgvSchedule.SelectedRows[0].Cells["Sector"].Value.ToString();
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Schedules WHERE ScheduleId = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idToDelete);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LogToHistory("Премахване на задача", $"{taskName} в {taskSector} за {taskDate}");
                    LoadScheduleData();
                    MessageBox.Show("Записът беше изтрит успешно.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка при изтриване: " + ex.Message);
                }
            }
        }

        private void LogToHistory(string action, string details)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO OperationsLog (OperationName, Details, Initiator, OpTime) 
                                     VALUES (@op, @det, @init, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@op", action);
                        cmd.Parameters.AddWithValue("@det", details);
                        cmd.Parameters.AddWithValue("@init", this.currentUser);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Log Error: " + ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.Rows.Count == 0)
            {
                MessageBox.Show("Няма данни за експорт!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt|CSV File|*.csv";
            sfd.FileName = "Greenhouse_Report_" + DateTime.Now.ToString("yyyyMMdd_") + DateTime.Now.ToString("HHmmss");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine("ГРАФИК");
                        sw.WriteLine("--------------------------------------------------");
                        sw.WriteLine("Дата и час               | Дейност | Сектор | Продължителност | Статус");
                        foreach (DataGridViewRow row in dgvSchedule.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string action = row.Cells["ActionName"].Value.ToString();
                                string sector = row.Cells["Sector"].Value.ToString();
                                string date = row.Cells["ScheduledDate"].Value.ToString();
                                string duration = row.Cells["DurationMinutes"].Value.ToString();
                                string status = row.Cells["Status"].Value.ToString();

                                sw.WriteLine($"[{date}] | {action} | {sector} | {duration} | {status} ");
                            }
                        }
                        sw.WriteLine("--------------------------------------------------");
                        sw.WriteLine("Генериран от SmartGreenhouse System");
                    }

                    MessageBox.Show("Отчетът е записан успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Грешка при запис: " + ex.Message);
                }
            }
        }

        private void cmbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAction = cmbAction.Text;

            bool isWatering = selectedAction.Contains("Поливане");

            if (isWatering)
            {
                cmbSector.Enabled = true;
            }
            else
            {
                cmbSector.Enabled = false;
                cmbSector.SelectedIndex = 0;
            }
        }
    }
}
