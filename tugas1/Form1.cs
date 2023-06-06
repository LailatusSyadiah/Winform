using System;
using System.Data;
using Npgsql;

namespace project_alif
{
    public partial class Form1 : Form
    {
        private string connection = "Server=localhost; Port=5432; User Id=postgres; Password=12345678; Database=postgres";
        private NpgsqlConnection connect;
        private string postgresql;
        private NpgsqlCommand command;
        private DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect = new NpgsqlConnection(connection);
            Tampilkan_Data();
        }

        private void Tampilkan_Data()
        {
            try
            {
                connect.Open();
                postgresql = @"select laptop_supply.id_laptop, laptop_supply.nama_laptop, laptop_supply.harga_laptop, laptop_supply.stok_laptop, transaksi_pembeli.id_transaksi_pembeli, transaksi_pembeli.nama_pembeli, transaksi_detail_pembeli.laptop_pembeli, transaksi_detail_pembeli.stok_pembeli from laptop_supply join transaksi_detail_pembeli on laptop_supply.nama_laptop = transaksi_detail_pembeli.laptop_pembeli join transaksi_pembeli on transaksi_detail_pembeli.id_detail_transaksi_pembeli = transaksi_pembeli.id_transaksi_pembeli";
                command = new NpgsqlCommand(postgresql, connect);
                table = new DataTable();
                table.Load(command.ExecuteReader());
                connect.Close();
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show("Error nih: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tampilkan_Data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            string create1 = @"insert into laptop_supply (id_laptop, nama_laptop, harga_laptop, stok_laptop) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            command = new NpgsqlCommand(create1, connect);
            command.ExecuteNonQuery();
            MessageBox.Show("Data diinput!");
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            string create_transaksi = @"insert into transaksi_detail_pembeli (id_detail_transaksi_pembeli, laptop_pembeli, stok_pembeli) values ('" + textBox10.Text + "','" + textBox9.Text + "','" + textBox6.Text + "')";
            command = new NpgsqlCommand(create_transaksi, connect);
            command.ExecuteNonQuery();
            MessageBox.Show("Data diinput!");
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            string create_nama = @"insert into transaksi_pembeli (id_transaksi_pembeli, nama_pembeli) values ('" + textBox8.Text + "','" + textBox7.Text + "')";
            command = new NpgsqlCommand(create_nama, connect);
            command.ExecuteNonQuery();
            MessageBox.Show("Data diinput!");
            connect.Close();
        }
    }
}