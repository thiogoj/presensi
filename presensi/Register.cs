using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presensi
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();

            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == "" || tbNik.Text == "" || tbPass.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong!", "Konfirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                Connection Conn = new Connection();
                SqlConnection Connection = Conn.GetConn();

                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Pegawai (nik, pass, email) VALUES (@nik, @pass, @email)", Connection);
                    cmd.Parameters.AddWithValue("@nik", tbNik.Text);
                    cmd.Parameters.AddWithValue("@pass", tosha256(tbPass.Text));
                    cmd.Parameters.AddWithValue("@email", tbEmail.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Berhasil register", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form1 login = new Form1();
                    login.Show();

                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        static string tosha256(string s)
        {
            string hash = String.Empty;

            SHA256 sha256 = SHA256.Create();
            byte[] hashedValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

            foreach (byte b in hashedValue)
            {
                hash += $"{b:X2}";
            }

            return hash;
        }
    }
}
