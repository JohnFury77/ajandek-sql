using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ajandek_sql
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost; Database=ajandek; Uid=root ;Pwd=  ;");
            conn.Open();
            this.FormClosed += (sender, args) =>
            {
                if (conn != null)
                {
                    conn.Close();
                }
            };

            AdatBetoltes();

        }
        
        private void AdatBetoltes()
        {
            string sql = @"
                SELECT id, nev, uzlet
                FROM ajandek
                ORDER BY nev
            ";
            var comm = this.conn.CreateCommand();
            comm.CommandText = sql;
            using (var reader = comm.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string nev = reader.GetString("nev");
                    string uzlet = reader.GetString("uzlet");
                    Ajandek ajandek = new Ajandek(id, nev, uzlet);
                    listBox1.Items.Add(ajandek);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox3.Text);
            string nev = textBox1.Text;
            string uzlet = textBox2.Text;
            var insertComm = conn.CreateCommand();
            insertComm.CommandText = @"
                            INSERT INTO ajandek (id, nev,uzlet)
                            VALUES(@id, @nev, @uzlet)
                        ";
            insertComm.Parameters.AddWithValue("@id", id);
            insertComm.Parameters.AddWithValue("@nev", nev);
            insertComm.Parameters.AddWithValue("@uzlet", uzlet);
            insertComm.ExecuteNonQuery();
            Ajandek ajandek = new Ajandek(id, nev, uzlet);
            listBox1.Items.Add(ajandek);
        }
    }
}
