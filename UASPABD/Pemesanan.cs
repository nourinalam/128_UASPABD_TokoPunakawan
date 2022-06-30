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

namespace UASPABD
{
    public partial class Pemesanan : Form
    {
        public Pemesanan()
        {
            InitializeComponent();
            Fill_Combo_Menu();
            Fill_Combo_Kasir();
        }
        void Fill_Combo_Menu()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM; database=Toko_Punakawan;User ID=sa;Password=123456");
            SqlCommand query = new SqlCommand("Select * From Menu_Makanan ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cb_Menu.DisplayMember = "Id_Menu";
                cb_Menu.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        void Fill_Combo_Kasir()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM; database=Toko_Punakawan;User ID=sa;Password=123456");
            SqlCommand query = new SqlCommand("Select * From Kasir ", conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cb_Kasir.DisplayMember = "Id_Kasir";
                cb_Kasir.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        void insertData()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM; database=Toko_Punakawan;User ID=sa;Password=123456");
            try
            {
                conn.Open();
                SqlCommand insert = new SqlCommand("INSERT INTO Pemesananan (Id_Pemesanan, Id_Kasir, Id_Menu,Nama_Makanan,Jenis_Menu,Harga) VALUES" +
                    "('" + Id_Pemesanan.Text + "','" + cb_Kasir.Text + "','" + cb_Menu.Text + "','" + Nama_Makanan.Text + "', '" + Jenis_Menu.Text + "','" + Harga.Text + "')", conn);
                insert.ExecuteNonQuery();
                conn.Close();
                getData();
                MessageBox.Show("Success Save Data");
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
        void updateData()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM; database=Toko_Punakawan;User ID=sa;Password=123456");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Pemesananan set Id_Pemesanan = @Id_Pemesanan, Id_Kasir = @Id_Kasir, Id_Menu = @Id_Menu, Nama_Makanan = @Nama_Makanan, Jenis_Menu = @Jenis_Menu, Harga = @Harga where Id_Pemesanan = @Id_Pemesanan", conn);

            cmd.Parameters.AddWithValue("@Id_Pemesanan", Id_Pemesanan.Text);
            cmd.Parameters.AddWithValue("@Id_Kasir", cb_Kasir.Text);
            cmd.Parameters.AddWithValue("@Id_Menu", cb_Menu.Text);
            cmd.Parameters.AddWithValue("@Nama_Makanan", Nama_Makanan.Text);
            cmd.Parameters.AddWithValue("@Jenis_Menu", Jenis_Menu.Text);
            cmd.Parameters.AddWithValue("@Harga", Harga.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            getData();
            MessageBox.Show("Sukses Update");
        }

        void deleteData()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM; database=Toko_Punakawan;User ID=sa;Password=123456");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Pemesananan where Id_Pemesanan = @Id_Pemesanan", conn);
            cmd.Parameters.AddWithValue("@Id_Pemesanan", Id_Pemesanan.Text);
            cmd.ExecuteNonQuery();
            getData();
            conn.Close();
            MessageBox.Show("Berhasil hapus");
        }
        void getData()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM; database=Toko_Punakawan;User ID=sa;Password=123456");
            try
            {
                conn.Open();
                SqlCommand show = new SqlCommand("SELECT * FROM Pemesananan", conn);
                SqlDataAdapter sda = new SqlDataAdapter(show);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Id_Pemesanan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pemesanan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toko_Punakawan1DataSet.Pemesananan' table. You can move, or remove it, as needed.
            this.pemesanananTableAdapter.Fill(this.toko_PunakawanDataSet.Pemesananan);
            Nama_Makanan.Enabled = false;
            Jenis_Menu.Enabled = false;
            Harga.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                Id_Pemesanan.Text = "";
                cb_Kasir.Text = "";
                cb_Menu.Text = "";
                Nama_Makanan.Text = "";
                Jenis_Menu.Text = "";
                Harga.Text = "";

                Id_Pemesanan.Focus();
            }

        }

        private void cb_Menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM; database=Toko_Punakawan;User ID=sa;Password=123456");
            SqlCommand query = new SqlCommand("Select * From Menu_Makanan where Id_Menu = '" + cb_Menu.Text + "'", conn);
            SqlDataReader sdr;

            try
            {
                conn.Open();
                sdr = query.ExecuteReader();
                while (sdr.Read())
                {
                    Nama_Makanan.Text = sdr.GetString(1);
                    Jenis_Menu.Text = sdr.GetString(2);
                    Harga.Text = sdr.GetInt32(3).ToString();
                }
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                Id_Pemesanan.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                cb_Kasir.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                cb_Menu.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                Nama_Makanan.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                Jenis_Menu.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                Harga.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void cb_Kasir_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM;database=Toko_Punakawan;User ID=sa;Password=123456");
            SqlCommand query = new SqlCommand("Select * From Kasir where Id_Kasir = '" + cb_Kasir.Text + "'", conn);

            SqlDataReader sdr;

            try
            {
                conn.Open();
                sdr = query.ExecuteReader();
                while (sdr.Read()) ;
            }
            catch (Exception et)
            {
                MessageBox.Show(et.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void Pemesanan_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toko_PunakawanDataSet.Menu_Makanan' table. You can move, or remove it, as needed.
            this.menu_MakananTableAdapter.Fill(this.toko_PunakawanDataSet.Menu_Makanan);
            // TODO: This line of code loads data into the 'toko_PunakawanDataSet.Pemesananan' table. You can move, or remove it, as needed.
            this.pemesanananTableAdapter.Fill(this.toko_PunakawanDataSet.Pemesananan);

        }
    }
}
