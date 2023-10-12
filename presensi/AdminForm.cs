using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presensi
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExceptThis();

            lblGender pegawai = new lblGender();
            pegawai.Show();
        }

        void ExceptThis()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != "AdminForm")
                {
                    form.Hide();
                }
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void divisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExceptThis();

            Divisi divisi = new Divisi();
            divisi.Show();
        }
    }
}
