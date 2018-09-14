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
    public partial class CardList : Form
    {
        Form parent;
        SqlConnection baglanti = new SqlConnection(@"server=10.2.7.240;user=guvenlik;pwd=1q2w3e;database=ISBAKG;");
        SqlCommand komut;
        SqlDataAdapter adapter;
        DataTable dt = new DataTable();
        public CardList(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
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

        private void CardList_Load(object sender, EventArgs e)
        {
            Baglanti_Acma();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SP_LIST_ALL_CARDS";
            komut.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = komut;
            adapter.Fill(dt);
            dataGridViewCardList.DataSource = dt;
            komut.ExecuteNonQuery();
            Baglanti_Kapatma();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                for (int i = 0; i < dataGridViewCardList.Rows.Count -1; i++)
                {
                    string num = dataGridViewCardList.Rows[i].Cells["Kart No"].Value.ToString();
                    DataGridViewCheckBoxCell chk1 = (DataGridViewCheckBoxCell)dataGridViewCardList.Rows[i].Cells[3];
                    DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)dataGridViewCardList.Rows[i].Cells[4];
                    if (Convert.ToBoolean(chk2.Value) == false)
                    {
                        string card_id = "SELECT card_id FROM CARDS WHERE card_name='" + dataGridViewCardList.Rows[i].Cells[1].Value.ToString() + "'";
                        SqlCommand card_komut = new SqlCommand(card_id, baglanti);
                        SqlDataReader oku = null;
                        oku = card_komut.ExecuteReader();
                        int Card_Id;
                        oku.Read();
                        Card_Id = Convert.ToInt32(oku["card_id"]);
                        oku.Close();
                        card_komut.ExecuteNonQuery();
                        SqlCommand del_komut = new SqlCommand("DELETE FROM INTERN_CARD WHERE card_id=@Card_Id", baglanti);
                        del_komut.Parameters.AddWithValue("@Card_Id", Card_Id);
                        del_komut.ExecuteNonQuery();
 
                    }
                    SqlCommand query = new SqlCommand("update CARDS set isUsed = @used, isLost=@lost where card_num=@num", baglanti);
                    query.Parameters.AddWithValue("@num", num);
                    query.Parameters.AddWithValue("@used", chk2.Value);
                    query.Parameters.AddWithValue("@lost", chk1.Value);
                    query.ExecuteNonQuery();
                    dataGridViewCardList.Update();
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
            }
        }

        private void dataGridViewCardList_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == 4 || e.ColumnIndex == 3)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewCardList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                chk.TrueValue = true;
                chk.FalseValue = false;
                if (Convert.ToBoolean(chk.Value))
                {
                    chk.Value = false;
                }
                else
                {
                    chk.Value = true;
                }
            }
        }

        private void CardList_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }
    }
}