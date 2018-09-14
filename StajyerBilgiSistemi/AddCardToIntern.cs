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

    public partial class AddCardToIntern : Form
    {
        Form parent;
        SqlConnection baglanti = new SqlConnection(Program.ConnString);
        int intern_id = Intern.intern_ID;
        public AddCardToIntern(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }

        private void AddCardToIntern_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
        public DataTable isbak_card_doldur()
        {
            try
            {
                baglanti.Open();
                string kom = "SELECT * FROM CARDS WHERE type='iSBAK' and isLost='false' and isUsed='false' ";
                SqlDataAdapter adapter = new SqlDataAdapter(kom, baglanti);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);
                return tbl;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }
        public DataTable arge_card_doldur()
        {
            try
            {
                baglanti.Open();
                string kom = "SELECT * FROM CARDS WHERE type='ARGE' and isLost='false' and isUsed='false' ";
                SqlDataAdapter adapter = new SqlDataAdapter(kom, baglanti);
                DataTable tbl = new DataTable();
                adapter.Fill(tbl);
                return tbl;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void AddCardToIntern_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = isbak_card_doldur();
            comboBox1.DisplayMember = "card_name";
            comboBox1.ValueMember = "card_id";
            comboBox1.SelectedValue = 0;
            comboBox2.DataSource = arge_card_doldur();
            comboBox2.DisplayMember = "card_name";
            comboBox2.ValueMember = "card_id";
            comboBox2.SelectedValue = 0;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                int cmbx_isbak_card = Convert.ToInt32(comboBox1.SelectedValue);//comboboxtan isbak kartını alıyoruz
                int cmbx_arge_card = Convert.ToInt32(comboBox2.SelectedValue);//comboboxtan arge kartını alıyoruz

                //isbak kartını ekliyoruz
                if (cmbx_isbak_card > 0) 
                {
                    SqlCommand insert_isbak_card_cmbbx = new SqlCommand("INSERT INTO INTERN_CARD (intern_id,card_id) VALUES(@intern_id,@cmbx_isbak_card)", baglanti);
                    insert_isbak_card_cmbbx.Parameters.AddWithValue("@intern_id", intern_id);
                    insert_isbak_card_cmbbx.Parameters.AddWithValue("@cmbx_isbak_card", cmbx_isbak_card);
                    insert_isbak_card_cmbbx.ExecuteNonQuery();
                    //eklediğimiz isbak kartının cards listesindeki kullanım durumunu true yapıyoruz
                    SqlCommand upd_command = new SqlCommand("UPDATE CARDS SET isUsed='TRUE' WHERE card_id=@isbak_card", baglanti);
                    upd_command.Parameters.AddWithValue("isbak_card", cmbx_isbak_card);
                    upd_command.ExecuteNonQuery();
                }
                //arge kartını ekliyoruz
                if (cmbx_arge_card>0)
                {
               
                    SqlCommand insert_arge_card_cmbbx = new SqlCommand("INSERT INTO INTERN_CARD (intern_id,card_id) VALUES(@intern_id,@cmbx_arge_card)", baglanti);
                    insert_arge_card_cmbbx.Parameters.AddWithValue("@intern_id", intern_id);
                    insert_arge_card_cmbbx.Parameters.AddWithValue("@cmbx_arge_card", cmbx_arge_card);
                    insert_arge_card_cmbbx.ExecuteNonQuery();
                    //eklediğimiz arge kartının cards tablosundaki isused durumunu true yapıyoruz.
                    SqlCommand upd_arge_cmd = new SqlCommand("UPDATE CARDS SET isUsed='TRUE' WHERE card_id=@arge_card", baglanti);
                    upd_arge_cmd.Parameters.AddWithValue("@arge_card", cmbx_arge_card);
                    upd_arge_cmd.ExecuteNonQuery();
                }
                
                MessageBox.Show("Güncellendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglanti.Close();
                this.Close();
            }
        }
    }
}