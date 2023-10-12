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

namespace presensi
{
    public partial class lblGender : Form
    {
        public lblGender()
        {
            InitializeComponent();
        }

        void Divisi()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Divisi", Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboxDivisi.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cboxDivisi.Items.Add(row["nama"].ToString());
            }
        }

        void Jabatan()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Jabatan", Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboxJabatan.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                cboxJabatan.Items.Add(row["jabatan"].ToString());
            }
        }

        void LoadData()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblGender_Load(object sender, EventArgs e)
        {
            Divisi();
            Jabatan();
        }
    }
}
