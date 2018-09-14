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
    public partial class AddCard : Form
    {
        Form parent;
        SqlConnection baglanti;
        public AddCard(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }

        private void btn_add_card_Click(object sender, EventArgs e)
        {
            string no = textBoxCardNo.Text;
            string name = textBoxCardName.Text;
            baglanti=new SqlConnection(Program.ConnString);
            baglanti.Open();
            try 
            {
               
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "SP_ADD_CARDS";
                komut.Parameters.AddWithValue("@card_num", no);
                komut.Parameters.AddWithValue("@card_name", name);
                komut.Parameters.AddWithValue("@isLost", false);
                komut.Parameters.AddWithValue("@isUsed", false);
                if (radioButton1.Checked)
                {
                    komut.Parameters.AddWithValue("@type", radioButton1.Text);
                }
                else 
                {
                    komut.Parameters.AddWithValue("@type",radioButton2.Text);
                }

                if (no =="")
                {
                    MessageBox.Show("RFID bölümünü doldurunuz");
                    return;
                }

                if (name == "")
                {
                    MessageBox.Show("Kard Adı bölümünü doldurunuz");
                    return;
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = komut;
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
                textBoxCardNo.Clear();
                textBoxCardName.Clear();
                textBoxCardNo.Focus();
            }
            catch(Exception)
            {
                MessageBox.Show("Aynı Kart No'lu kayıt bulunmaktadır.");
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void AddCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void AddCard_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }
    }
}
