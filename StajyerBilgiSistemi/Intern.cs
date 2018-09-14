using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace StajyerBilgiSistemi
{
    public partial class Intern : Form
    {
        Form parent;
        SqlConnection baglanti;
        long intern_tc;
        public static int intern_ID;
        public Intern(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }

        public Intern(long intern_tc, Form prnt)
        {
            parent = prnt;
            this.intern_tc = intern_tc;
            InitializeComponent();
            baglanti = new SqlConnection(Program.ConnString);
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.TrueValue = true;
            chk.FalseValue = false;
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "Kartı Sil";
        }

        DataTable dt_intern = new DataTable();

        private void Intern_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            komut.Parameters.Clear();
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SP_INTERN_SEARCH";
            komut.Parameters.AddWithValue("@intern_tc", intern_tc);
            komut.Connection = baglanti;
            adapter.SelectCommand = komut;
            adapter.Fill(dt_intern);
            if (dt_intern.Rows.Count == 0) 
            {
                MessageBox.Show(intern_tc+" NOLU STAJYER BULUNAMADI.");
                return;
            }
            komut.Parameters.Clear();
            komut.CommandText = "SP_GET_INTERNS_CARD";
            komut.Parameters.AddWithValue("@intern_id", dt_intern.Rows[0]["intern_id"]);
            komut.Connection = baglanti;
            DataTable dt_cards = new DataTable();
            adapter.Fill(dt_cards);
            intern_ID = Convert.ToInt32(dt_intern.Rows[0]["intern_id"]);
            getInternCards(intern_ID);
            //datagridview kullanıcının kartlarını dolduruyor.
            int intern_id =(int) dt_intern.Rows[0]["intern_id"];
           
            baglanti.Close();
            // kartı sil sütunu eklendi
           
            if (dt_intern.Rows.Count > 0) 
            {
                textBoxName.Text = dt_intern.Rows[0]["intern_name"].ToString();
                textBoxTC.Text = dt_intern.Rows[0]["intern_tc"].ToString();
                textBoxStajBolum.Text = dt_intern.Rows[0]["department"].ToString();
                textBoxBolum.Text = dt_intern.Rows[0]["intern_dept"].ToString();
                textBoxSchool.Text = dt_intern.Rows[0]["intern_school"].ToString();
                dateTimePicker1.Text = ((DateTime)dt_intern.Rows[0]["starting_date"]).ToShortDateString();
                textBoxPhoneNumber.Text = dt_intern.Rows[0]["intern_tel_num"].ToString();
                textBoxEmail.Text = dt_intern.Rows[0]["intern_email"].ToString();
                dateTimePicker2.Text = ((DateTime)dt_intern.Rows[0]["finishing_date"]).ToShortDateString();
                textBoxGrade.Text = dt_intern.Rows[0]["intern_grade"].ToString();
                richTextBoxAddress.Text = dt_intern.Rows[0]["intern_address"].ToString();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String name = textBoxName.Text.ToString();
            String school = textBoxSchool.Text.ToString();
            long tc = Convert.ToInt64(textBoxTC.Text.ToString());
            int grade = Convert.ToInt32(textBoxGrade.Text.ToString());
            String Sch_dept = textBoxBolum.Text.ToString();
            String Work_dept = textBoxStajBolum.Text.ToString();
            String email = textBoxEmail.Text.ToString();
            long num = Convert.ToInt64(textBoxPhoneNumber.Text.ToString());
            String adress = richTextBoxAddress.Text.ToString();
          
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "SP_UPDATE_INTERN";
                komut.CommandType = CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@intern_name", name);
                komut.Parameters.AddWithValue("@intern_tc", tc);
                komut.Parameters.AddWithValue("@intern_school", school);
                komut.Parameters.AddWithValue("@intern_grade", grade);
                komut.Parameters.AddWithValue("@intern_dept", Sch_dept);
                komut.Parameters.AddWithValue("@department", Work_dept);
                komut.Parameters.AddWithValue("@intern_email", email);
                komut.Parameters.AddWithValue("@intern_tel_num", num);
                if (textBoxPhoneNumber.Text.Length != 10)
                {
                    MessageBox.Show("TELEFON NUMARANIZI ÖRNEKTEKİ GİBİ GİRİNİZ.");
                    return;
                }
                komut.Parameters.AddWithValue("@intern_address", adress);
                komut.Parameters.AddWithValue("@starting_date", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                komut.Parameters.AddWithValue("@finishing_date", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter = new SqlDataAdapter();
                adapter.UpdateCommand = komut;
                komut.ExecuteNonQuery();
                
               
                ////datagridview ile ilgili işlemler
                int CardIndex = dataGridView1.Columns["Kart Adı"].Index;
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++) 
                {
                    DataGridViewCheckBoxCell chkk = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    if (Convert.ToBoolean(chkk.Value) == true)
                       
                    {
                        string card_id = "SELECT card_id FROM CARDS WHERE card_name='" + dataGridView1.Rows[i].Cells[CardIndex].Value.ToString() + "'";
                        SqlCommand card_komut = new SqlCommand(card_id,baglanti);
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
                        SqlCommand upd_card = new SqlCommand("UPDATE CARDS SET isUsed='FALSE' WHERE card_id=@arge_card", baglanti);
                        upd_card.Parameters.AddWithValue("@arge_card", Card_Id);
                        upd_card.ExecuteNonQuery();
                    }
                }

                    MessageBox.Show("Güncellendi");
                    getInternCards(intern_ID);
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

        private void Intern_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                chk.TrueValue = true;
                chk.FalseValue = false;
                if (chk.Value == chk.TrueValue)
                {
                    chk.Value = chk.FalseValue;
                }
                else
                {
                    chk.Value = chk.TrueValue;
                }
            }
        }

        private void btn_add_card_Click(object sender, EventArgs e)
        {
            AddCardToIntern add_card = new AddCardToIntern(this);
            add_card.ShowDialog();
            baglanti.Open();
            getInternCards(intern_ID);
            baglanti.Close();
            
        }

        private void getInternCards(int internId)
        {
            string sorgu = "SELECT CARDS.card_name as [Kart Adı],CARDS.type as [Tür], CARDS.isLost as [Kayıp Durumu],CARDS.isUsed as [Kullanım Durumu] FROM INTERN_CARD INNER JOIN CARDS ON INTERN_CARD.card_id=CARDS.card_id WHERE INTERN_CARD.intern_id=@intern_id and CARDS.isUsed=1";
            SqlCommand komut2 = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable dt = new DataTable();
            komut2.Parameters.AddWithValue("@intern_id", internId);
            adapter2.SelectCommand = komut2;
            adapter2.Fill(dt);
            dataGridView1.DataSource = dt;
            komut2.ExecuteNonQuery();

        }

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Back != e.KeyChar)
            {
                if (char.IsLetter(e.KeyChar) || textBoxPhoneNumber.Text.Length > 9)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
