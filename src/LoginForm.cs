using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartGreenhouse;

namespace Greenhouse
{
    public partial class LoginForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GreenhouseDB;Trusted_Connection=True;";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Моля, въведете име и парола.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Role FROM Users WHERE Username = @u AND Password = @p";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            this.Hide();
                            MainForm mainForm = new MainForm(role, txtUsername.Text)    ;
                            DialogResult answer = mainForm.ShowDialog();
                            if (answer == DialogResult.OK)
                            {
                                this.Show();
                                txtUsername.Text = "";
                                txtPassword.Text = "";
                                txtUsername.Focus();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Грешно име или парола!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }
    }
}
