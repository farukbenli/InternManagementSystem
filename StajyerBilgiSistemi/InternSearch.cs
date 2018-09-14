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
    public partial class InternSearch : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=10.2.7.240;user=guvenlik;pwd=1q2w3e;database=ISBAKG;");
        Form parent;
        public InternSearch(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }
        private void buttonSearchIntern_Click(object sender, EventArgs e)
        {
            if (textBoxTC.Text.Length != 11) 
            {
                MessageBox.Show("EKSİK RAKAM GİRDİNİZ TEKRAR DENEYİN");
                return;
            }
            SqlDataReader read = null;
            string sorgu = "SELECT * from INTERNS where intern_tc='" + textBoxTC.Text + "' ";
            SqlCommand cmd =new SqlCommand(sorgu,baglanti);
            Baglanti_Acma();
                read = cmd.ExecuteReader();
                if(read.Read() == true)
                {
                    //bir sonraki forma geçiş yapıyoruz.
                    Intern intern = new Intern(Convert.ToInt64(textBoxTC.Text),this);
                    intern.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("YANLIŞ KİMLİK NUMARASI GİRDİNİZ TEKRAR DENEYİN");
                }
                Baglanti_Kapatma();
            
        }

        private void InternSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void textBoxTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Back != e.KeyChar)
            {
                if (char.IsLetter(e.KeyChar) || textBoxTC.Text.Length > 10)
                {
                    e.Handled = true;
                }
            }
        }
        public void Baglanti_Acma()
        {
            try
            {
                baglanti.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Internet bağlantınızı kontrol ediniz");
            }
        }
        public void Baglanti_Kapatma()
        {
            try
            {
                baglanti.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Internet bağlantınızı kontrol ediniz");
            }
        }
    }
}
