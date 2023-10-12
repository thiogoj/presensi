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
    public partial class Divisi : Form
    {
        public Divisi()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            Connection Conn = new Connection();
            SqlConnection Connection = Conn.GetConn();

            try
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, nama, CASE WHEN status = 1 THEN 'Aktif' ELSE 'Tidak Aktif' END AS status FROM dbo.Divisi", Connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        void columnButton()
        {
            DataGridViewButtonColumn columnEdit = new DataGridViewButtonColumn();
            columnEdit.UseColumnTextForButtonValue = true;
            columnEdit.Text = "Edit";

            DataGridViewButtonColumn columnDelete = new DataGridViewButtonColumn();
            columnDelete.UseColumnTextForButtonValue = true;
            columnDelete.Text = "Delete";

            dataGridView1.Columns.Add(columnEdit);
            dataGridView1.Columns.Add(columnDelete);
        }

        private void Divisi_Load(object sender, EventArgs e)
        {
            LoadData();
            columnButton();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            object cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            DataGridViewRow selectedIndex = dataGridView1.Rows[e.RowIndex];

            if (cellValue != null && cellValue.ToString() == "Edit")
            {
                tbNama.Text = selectedIndex.Cells["nama"].Value.ToString();

                if (selectedIndex.Cells["status"].Value.ToString() == "Aktif")
                {
                    cbAktif.Checked = true;
                } else
                {
                    cbTidakAktif.Checked = true;
                }
            } else if(cellValue != null && cellValue.ToString() == "Delete")
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Apakah kamu yakin untuk hapus?", "Hapus", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    Connection Conn = new Connection();
                    SqlConnection Connection = Conn.GetConn();

                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE dbo.Divisi WHERE id='" + selectedIndex.Cells["id"].Value.ToString() + "'", Connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Berhasil delete", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                } else
                {

                }
            }
            else
            {
                MessageBox.Show("Choose Action");
            }
        }
    }
}
