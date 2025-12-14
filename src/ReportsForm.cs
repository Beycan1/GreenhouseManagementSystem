using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SmartGreenhouse
{
    public partial class ReportsForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GreenhouseDB;Trusted_Connection=True;";

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadData(DateTime.Today, DateTime.Now);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime start = dtpStart.Value.Date;
            DateTime end = dtpEnd.Value.Date.AddDays(1).AddSeconds(-1);

            LoadData(start, end);
        }

        private void LoadData(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT OperationName, Details, Initiator, OpTime 
                                     FROM OperationsLog 
                                     WHERE OpTime BETWEEN @start AND @end 
                                     ORDER BY OpTime DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@start", fromDate);
                        cmd.Parameters.AddWithValue("@end", toDate);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvReports.DataSource = dt;

                        dgvReports.Columns["OperationName"].HeaderText = "Действие";
                        dgvReports.Columns["Details"].HeaderText = "Детайли";
                        dgvReports.Columns["Initiator"].HeaderText = "Изпълнител";
                        dgvReports.Columns["OpTime"].HeaderText = "Време";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане: " + ex.Message);
            }
        }

        // Функция за експортиране на отчет на операции
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
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
                        sw.WriteLine("ОТЧЕТ ЗА ОПЕРАЦИИ");
                        sw.WriteLine($"Период: {dtpStart.Value.ToShortDateString()} - {dtpEnd.Value.ToShortDateString()}");
                        sw.WriteLine("--------------------------------------------------");
                        sw.WriteLine("Време                   | Действие               | Детайли              | Изпълнител");
                        foreach (DataGridViewRow row in dgvReports.Rows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string action = row.Cells["OperationName"].Value.ToString();
                                string details = row.Cells["Details"].Value.ToString();
                                string who = row.Cells["Initiator"].Value.ToString();
                                string time = row.Cells["OpTime"].Value.ToString();

                                sw.WriteLine($"[{time}] {action} | {details} | { who} ");
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