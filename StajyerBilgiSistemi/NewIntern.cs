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
    public partial class NewIntern : Form
    {
        Form parent;
        SqlConnection baglanti = new SqlConnection(@"server=10.2.7.240;user=guvenlik;pwd=1q2w3e;database=ISBAKG;");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        public NewIntern(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
       
            try
            {
                string name = textBoxName.Text.ToString();
                string school = textBoxSchool.Text.ToString();
                long tc = Convert.ToInt64(textBoxTC.Text.ToString());
               
                int grade = Convert.ToInt32(textBoxGrade.Text.ToString());
                string Sch_dept = textBoxBolum.Text.ToString();
                string Work_dept = textBoxStajBolum.Text.ToString();
                string email = textBoxEmail.Text.ToString();
                long num = Convert.ToInt64(textBoxPhoneNumber.Text.ToString());
                string adress = richTextBoxAddress.Text.ToString();

                int arge_card = Convert.ToInt32(comboBox2.SelectedValue);
                int isbak_card = Convert.ToInt32(comboBox1.SelectedValue);

                
                komut.Parameters.Clear();
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SP_ADD_INTERN";                
                komut.Parameters.AddWithValue("@intern_name", name);
                if (textBoxName.Text == "") 
                {
                    MessageBox.Show("İSİM ALANI BOŞ BIRAKILAMAZ.");
                    return;
                }
                komut.Parameters.AddWithValue("@intern_tc", tc);
                if (textBoxTC.Text.Length != 11)
                {
                    MessageBox.Show("TC KİMLİK NUMARANIZI 11 HANELİ OLARAK GİRİNİZ.");
                    return;
                }
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
                if (dateTimePicker1.Value > dateTimePicker2.Value)
                {
                    MessageBox.Show("Staj Başlangıç Tarihi Bitiş Tarihinden sonra olamaz.");
                    return;
                }
                Baglanti_Ac();
                adapter.InsertCommand = komut;
                adapter.InsertCommand.ExecuteNonQuery();

                string intern_id = "SELECT intern_id FROM INTERNS WHERE intern_tc=@intern_tc";  // card-intern tablosu için intern_id alınıyor
                SqlCommand komut2 = new SqlCommand(intern_id, baglanti);
                komut2.Parameters.AddWithValue("@intern_tc", tc);
                Object obj = komut2.ExecuteScalar();
                int internID = 0;
                if (obj != DBNull.Value)
                {
                    internID = Convert.ToInt32(obj);
                }

                if (arge_card > 0)
                {
                    SqlCommand card_intern_ekle = new SqlCommand("INSERT INTO INTERN_CARD (card_id,intern_id) VALUES (@card_id,@intern_id)", baglanti);
                    card_intern_ekle.Parameters.AddWithValue("@card_id", arge_card);
                    SqlCommand card_used = new SqlCommand("UPDATE CARDS SET isUsed='true' WHERE card_id=@card_id", baglanti);
                    card_used.Parameters.AddWithValue("@card_id", arge_card);
                    card_used.ExecuteNonQuery();
                    card_intern_ekle.Parameters.AddWithValue("@intern_id", internID);
                    card_intern_ekle.ExecuteNonQuery();
                }
                if (isbak_card > 0)
                {
                    SqlCommand card_intern_ekle = new SqlCommand("INSERT INTO INTERN_CARD (card_id,intern_id) VALUES (@card_id,@intern_id)", baglanti);
                    card_intern_ekle.Parameters.AddWithValue("@card_id", isbak_card);
                    SqlCommand card_used = new SqlCommand("UPDATE CARDS SET isUsed='true' WHERE card_id=@card_id", baglanti);
                    card_used.Parameters.AddWithValue("@card_id", isbak_card);
                    card_used.ExecuteNonQuery();
                    card_intern_ekle.Parameters.AddWithValue("@intern_id", internID);
                    card_intern_ekle.ExecuteNonQuery();
                }
                
                MessageBox.Show("Kayıt Başarılı");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen '*' olan yerleri doldurunuz.");
            }
            finally
            {
                Baglanti_Kapat();
            }
        }
        
        public void Baglanti_Ac()
        {
            try
            {
                komut.Connection = baglanti;
                baglanti.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Baglanti_Kapat()
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
        private void NewIntern_FormClosing(object sender, FormClosingEventArgs e)
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
        private void NewIntern_Load(object sender, EventArgs e)
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
        private void textBoxTC_KeyPress(object sender, KeyPressEventArgs e)
        {

            if((char)Keys.Back!=e.KeyChar)
            {
                if (char.IsLetter(e.KeyChar) || textBoxTC.Text.Length > 10)
                {

                    e.Handled = true;
                }
            }
            
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

        private void textBoxGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Back != e.KeyChar)
            {
                if (char.IsLetter(e.KeyChar) || textBoxGrade.Text.Length > 0)
                {
                    e.Handled = true;
                }
            }
        }
    }
} 