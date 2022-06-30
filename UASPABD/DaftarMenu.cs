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
    public partial class DaftarMenu : Form
    {
        public DaftarMenu()
        {
            InitializeComponent();
        }

        void insertData()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM;database=Toko_Punakawan;User ID=sa;Password=123456");
            try
            {
                conn.Open();
                SqlCommand insert = new SqlCommand("INSERT INTO Menu_Makanan (Id_Menu, Nama_Makanan,Jenis_Menu,Harga) VALUES" +
                    "('" + Id_Menu.Text + "', '" + Nama_Makanan.Text + "','" + Jenis_Menu.Text + "','" + Harga.Text + "')", conn);
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
        void getData()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM;database=Toko_Punakawan;User ID=sa;Password=123456");
            try
            {
                conn.Open();
                SqlCommand show = new SqlCommand("SELECT * FROM Menu_Makanan", conn);
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

        void updateData()
        {
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM;database=Toko_Punakawan;User ID=sa;Password=123456");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Menu_Makanan set Id_Menu = @Id_Menu, Nama_Makanan = @Nama_Makanan, Jenis_Menu = @Jenis_Menu, Harga = @Harga where Id_Menu = @Id_Menu", conn);
            cmd.Parameters.AddWithValue("@Id_Menu", Id_Menu.Text);
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
            SqlConnection conn = new SqlConnection("data source = LAPTOP-8JHE7APE\\ALAM;database=Toko_Punakawan;User ID=sa;Password=123456");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Menu_Makanan where Id_Menu = @Id_Menu", conn);
            cmd.Parameters.AddWithValue("@Id_Menu", Id_Menu.Text);
            cmd.ExecuteNonQuery();
            getData();
            conn.Close();
            MessageBox.Show("Berhasil hapus");
        }

        private void DaftarMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toko_Punakawan1DataSet.Menu_Makanan' table. You can move, or remove it, as needed.
            this.menu_MakananTableAdapter.Fill(this.toko_PunakawanDataSet.Menu_Makanan);
            Id_Menu.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                Id_Menu.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                Nama_Makanan.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                Jenis_Menu.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                Harga.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Id_Menu.Text = "";
            Nama_Makanan.Text = "";
            Jenis_Menu.Text = "";
            Harga.Text = "";

            Id_Menu.Focus();
        }

        private void DaftarMenu_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'toko_PunakawanDataSet.Menu_Makanan' table. You can move, or remove it, as needed.
            this.menu_MakananTableAdapter.Fill(this.toko_PunakawanDataSet.Menu_Makanan);

        }
    }
}