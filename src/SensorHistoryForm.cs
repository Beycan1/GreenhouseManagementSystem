using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Greenhouse
{
    public partial class SensorHistoryForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GreenhouseDB;Trusted_Connection=True;";

        public SensorHistoryForm()
        {
            InitializeComponent();
        }

        private void SensorHistoryForm_Load(object sender, EventArgs e)
        {
            LoadSensorsCombo();
        }

        private void LoadSensorsCombo()
        {
            try
            {
                cmbSensors.Items.Clear();
                cmbSensors.Items.Add("Всички сензори");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SensorName FROM Sensors";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbSensors.Items.Add(reader["SensorName"].ToString());
                            }
                        }
                    }
                }
                cmbSensors.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на сензорите: " + ex.Message);
            }
        }

        private void LoadHistoryData(string sensorName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT TOP 200 
                                        s.SensorName AS 'Сензор', 
                                        l.Value AS 'Стойност', 
                                        s.Unit AS 'Единица', 
                                        l.ReadingTime AS 'Време на отчитане'
                                     FROM SensorLog l
                                     JOIN Sensors s ON l.SensorId = s.SensorId";

                    bool filterBySensor = sensorName != "Всички сензори";
                    if (filterBySensor)
                    {
                        query += " WHERE s.SensorName = @name";
                    }
                    query += " ORDER BY l.ReadingTime DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (filterBySensor)
                        {
                            cmd.Parameters.AddWithValue("@name", sensorName);
                        }
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvHistory.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане на данните: " + ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string selectedSensor = cmbSensors.Text;
            LoadHistoryData(selectedSensor);
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0)
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
                        sw.WriteLine("ИСТОРИЯ НА СЕНЗОРИ");
                        sw.WriteLine($"История на: {cmbSensors.Text}");
                        sw.WriteLine("--------------------------------------------------");
                        sw.WriteLine("Време                    | Сензор         | Стойност");
                        foreach (DataGridViewRow row in dgvHistory.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string sensor = row.Cells["Сензор"].Value.ToString();
                                string value = row.Cells["Стойност"].Value.ToString();
                                string unit = row.Cells["Единица"].Value.ToString();
                                string time = row.Cells["Време на отчитане"].Value.ToString();

                                sw.WriteLine($"[{time}] | {sensor} | {value}{unit} ");
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
    
    }
}
