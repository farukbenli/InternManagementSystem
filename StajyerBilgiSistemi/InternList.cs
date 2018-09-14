using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace StajyerBilgiSistemi
{
    public partial class InternList : Form
    {
        Form parent;
        SqlConnection baglanti = new SqlConnection(@"server=10.2.7.240;user=guvenlik;pwd=1q2w3e;database=ISBAKG;");
        SqlCommand komut;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public InternList(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }

        private void InternList_Load(object sender, EventArgs e)
        {
            Baglanti_Acma();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SP_INTERN_LIST";
            komut.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = komut;
            adapter.Fill(dt);
            dataGridViewInternList.DataSource = dt;
            komut.ExecuteNonQuery();
            Baglanti_Kapatma();
        }
        public void Baglanti_Acma()
        {
            try
            {
                baglanti.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void Baglanti_Kapatma()
        {
            try
            {
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridViewInternList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long tc = Convert.ToInt64(dataGridViewInternList.Rows[e.RowIndex].Cells[0].Value);
                Intern intern = new Intern(tc, this);
                intern.Show();
            }
        }

        private void InternList_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}
