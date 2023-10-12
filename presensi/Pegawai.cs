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

        void Search()
        {
            cboxSearch.Items.Clear();
            cboxSearch.Items.Add("Email");
            cboxSearch.Items.Add("NIK");
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
                cboxJabatan.Items.Add(row["nama"].ToString());
            }
        }

        void LoadData()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.Pegawai.id, dbo.Divisi.nama, dbo.Jabatan.nama, dbo.Atasan.nama, dbo.Pegawai.nik, dbo.Pegawai.pass, dbo.Pegawai.gender, dbo.Pegawai.alamat, dbo.Pegawai.email, dbo.Pegawai.foto, dbo.Pegawai.ket FROM dbo.Pegawai INNER JOIN dbo.Divisi ON dbo.Pegawai.id_divisi = dbo.Divisi.id INNER JOIN dbo.Jabatan ON dbo.Pegawai.id_jabatan = dbo.Jabatan.id INNER JOIN dbo.Atasan ON dbo.Pegawai.id_atasan = dbo.Atasan.id", Connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns[1].HeaderText = "Divisi";
                dataGridView1.Columns[2].HeaderText = "Jabatan";
                dataGridView1.Columns[3].HeaderText = "Atasan";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void AutoCompleteAtasan()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT nama FROM dbo.Atasan", Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            AutoCompleteStringCollection src = new AutoCompleteStringCollection();

            foreach (DataRow row in dt.Rows)
            {
                src.Add(row["nama"].ToString());
            }

            tbAtasan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbAtasan.AutoCompleteCustomSource = src;
            tbAtasan.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void lblGender_Load(object sender, EventArgs e)
        {
            Divisi();
            Jabatan();
            LoadData();
            AutoCompleteAtasan();
            Search();

            tbSearch.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        string idDivisi_v;
        void idDivisi()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Divisi WHERE nama='" + cboxDivisi.Text + "'", Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            idDivisi_v = rd["id"].ToString();
        }


        string idJabatan_v;
        void idJabatan()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Jabatan WHERE nama='" + cboxJabatan.Text + "'", Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            idJabatan_v = rd["id"].ToString();
        }

        string idAtasan_v;
        void idAtasan()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            Connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Atasan WHERE nama='" + tbAtasan.Text + "'", Connection);
            SqlDataReader rd = cmd.ExecuteReader();
            rd.Read();
            idAtasan_v = rd["id"].ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (tbNik.Text == "" ||  tbAlamat.Text == "" || tbEmail.Text == "" || tbKet.Text == "" || cboxDivisi.Text == "" || cboxJabatan.Text == "" ||  tbAtasan.Text == "" || (cbPria.Checked == false && cbPerempuan.Checked == false) || openFileDialog1.FileName == "openFileDialog1")
            {
                MessageBox.Show("Data tidak boleh kosong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                idDivisi();
                Connection Conn = new Connection();
                SqlConnection Connection = Conn.GetConn();

                try
                {
                    idDivisi();
                    idJabatan();
                    idAtasan();

                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Pegawai (id_divisi, id_jabatan, id_atasan, nik, pass, gender, alamat, email, foto, ket) VALUES (@divisi, @jabatan, @atasan, @nik, @pass, @gender, @alamat, @email, @foto, @ket)", Connection);
                    cmd.Parameters.AddWithValue("@divisi", idDivisi_v);
                    cmd.Parameters.AddWithValue("@jabatan", idJabatan_v);
                    cmd.Parameters.AddWithValue("@atasan", idAtasan_v);
                    cmd.Parameters.AddWithValue("@nik", tbNik.Text);
                    cmd.Parameters.AddWithValue("@pass", tbPass.Text);
                    if (cbPria.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@gender", 1);
                    } else if (cbPerempuan.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@gender", 2);
                    }
                    cmd.Parameters.AddWithValue("@alamat", tbAlamat.Text);
                    cmd.Parameters.AddWithValue("@email", lblEmail.Text);
                    cmd.Parameters.AddWithValue("@foto", openFileDialog1.FileName);
                    cmd.Parameters.AddWithValue("@ket", tbKet.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Berhasil diinput", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Gambar|*png;*jpg;";
            openFileDialog1.ShowDialog();

            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void cbPria_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPria.Checked == true)
            {
                cbPerempuan.Checked = false;
            }
        }

        private void cbPerempuan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPerempuan.Checked == true)
            {
                cbPria.Checked = false;
            }
        }

        private void cboxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSearch.Text != "")
            {
                tbSearch.Enabled = true;
                btnSearch.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboxSearch.Text == "Email")
            {
                Connection Conn = new Connection();
                SqlConnection Connection = Conn.GetConn();

                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT dbo.Pegawai.id, dbo.Divisi.nama, dbo.Jabatan.nama, dbo.Atasan.nama, dbo.Pegawai.nik, dbo.Pegawai.pass, dbo.Pegawai.gender, dbo.Pegawai.alamat, dbo.Pegawai.email, dbo.Pegawai.foto, dbo.Pegawai.ket FROM dbo.Pegawai INNER JOIN dbo.Divisi ON dbo.Pegawai.id_divisi = dbo.Divisi.id INNER JOIN dbo.Jabatan ON dbo.Pegawai.id_jabatan = dbo.Jabatan.id INNER JOIN dbo.Atasan ON dbo.Pegawai.id_atasan = dbo.Atasan.id WHERE dbo.Pegawai.email LIKE '%"+ tbSearch.Text +"%'", Connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[1].HeaderText = "Divisi";
                    dataGridView1.Columns[2].HeaderText = "Jabatan";
                    dataGridView1.Columns[3].HeaderText = "Atasan";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if (cboxSearch.Text == "NIK")
            {
                Connection Conn = new Connection();
                SqlConnection Connection = Conn.GetConn();

                try
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT dbo.Pegawai.id, dbo.Divisi.nama, dbo.Jabatan.nama, dbo.Atasan.nama, dbo.Pegawai.nik, dbo.Pegawai.pass, dbo.Pegawai.gender, dbo.Pegawai.alamat, dbo.Pegawai.email, dbo.Pegawai.foto, dbo.Pegawai.ket FROM dbo.Pegawai INNER JOIN dbo.Divisi ON dbo.Pegawai.id_divisi = dbo.Divisi.id INNER JOIN dbo.Jabatan ON dbo.Pegawai.id_jabatan = dbo.Jabatan.id INNER JOIN dbo.Atasan ON dbo.Pegawai.id_atasan = dbo.Atasan.id WHERE dbo.Pegawai.nik LIKE '%" + tbSearch.Text + "%'", Connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns[1].HeaderText = "Divisi";
                    dataGridView1.Columns[2].HeaderText = "Jabatan";
                    dataGridView1.Columns[3].HeaderText = "Atasan";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
