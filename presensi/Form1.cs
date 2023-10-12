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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
   
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();

            this.Hide();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbNik.Text == "" || tbPass.Text == "")
            {
                 MessageBox.Show("Data tidak boleh kosong!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Connection Conn = new Connection();
                SqlConnection Connection = Conn.GetConn();
                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Pegawai WHERE nik=@nik AND pass=@pass", Connection);
                    cmd.Parameters.AddWithValue("@nik", tbNik.Text);
                    cmd.Parameters.AddWithValue("@pass", tosha256(tbPass.Text));
                    SqlDataReader rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        rd.Read();
                        AdminForm mainForm = new AdminForm();
                        mainForm.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
