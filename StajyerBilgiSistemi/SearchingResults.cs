using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Timers;
namespace StajyerBilgiSistemi
{
    public partial class SearchingResults : Form
    {
        Form parent;
        public SearchingResults(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(Program.ConnString);
        private void SearchingResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void SearchingResults_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Today.ToShortDateString().ToString();
            baglanti.Open();
            string sorgu = "SELECT INTERNS.intern_tc AS [TC NO],INTERNS.intern_name AS [ADI - SOYADI],INTERNS.intern_tel_num AS [TELEFON NO],INTERNS.intern_address AS [ADRES],INTERNS.intern_email AS [e - mail] from INTERNS INNER JOIN INTERN_CARD ON INTERNS.intern_id=INTERN_CARD.intern_id WHERE INTERNS.finishing_date < REPLACE(CONVERT(VARCHAR(10), GETDATE(), 111), '/', '-')";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adapter.SelectCommand = komut;
            adapter.Fill(dt);
            dataGridViewSearcResults.DataSource = dt;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void dataGridViewSearcResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long tc = Convert.ToInt64(dataGridViewSearcResults.Rows[e.RowIndex].Cells[0].Value);
                Intern intern = new Intern(tc, this);
                intern.Show();
            }
        }
    }
}
