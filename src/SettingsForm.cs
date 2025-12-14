using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartGreenhouse;

namespace Greenhouse
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            numSetMaxTemp.Value = (decimal)MainForm.LimitMaxTemp;
            numSetMinTemp.Value = (decimal)MainForm.LimitMinTemp;

            numSetMaxLight.Value = (decimal)MainForm.LimitMaxLight;
            numSetMinLight.Value = (decimal)MainForm.LimitMinLight;

            numSetMinSoil.Value = (decimal)MainForm.LimitMinSoil;
            numSetMaxSoil.Value = (decimal)MainForm.LimitMaxSoil;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (numSetMinTemp.Value >= numSetMaxTemp.Value)
            {
                MessageBox.Show("Минималната температура трябва да е по-ниска от максималната!");
                return;
            }

            MainForm.LimitMaxTemp = (double)numSetMaxTemp.Value;
            MainForm.LimitMinTemp = (double)numSetMinTemp.Value;

            MainForm.LimitMaxLight = (double)numSetMaxLight.Value;
            MainForm.LimitMinLight = (double)numSetMinLight.Value;

            MainForm.LimitMinSoil = (double)numSetMinSoil.Value;
            MainForm.LimitMaxSoil = (double)numSetMaxSoil.Value;

            MessageBox.Show("Настройките са запазени успешно!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
