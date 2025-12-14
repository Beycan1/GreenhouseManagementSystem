using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Greenhouse
{
    public partial class RegisterForm : Form
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GreenhouseDB;Trusted_Connection=True;";
        public RegisterForm()
        {
            InitializeComponent();
            cmbRole.SelectedIndex = 1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUser.Text;
            string password = txtNewPass.Text;
            string confirm = txtConfirmPass.Text;
            string role = cmbRole.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Моля, попълнете всички полета!");
                return;
            }
            if (password != confirm)
            {
                MessageBox.Show("Паролите не съвпадат!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @u";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@u", username);
                        int userCount = (int)checkCmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Потребителското име вече съществува!");
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@u, @p, @r)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@u", username);
                        insertCmd.Parameters.AddWithValue("@p", password);
                        insertCmd.Parameters.AddWithValue("@r", role);

                        insertCmd.ExecuteNonQuery();

                        MessageBox.Show($"Потребител {username} е регистриран успешно като {role}!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при запис: " + ex.Message);
            }
        }
    }
}
