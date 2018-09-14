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
    public partial class Entry : Form
    {
        SqlConnection baglanti = new SqlConnection(@"server=10.2.7.240;user=guvenlik;pwd=1q2w3e;database=ISBAKG;");
        public Entry()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            gecis();
        }
        public void gecis()
        {
            SqlDataReader read = null;
            string sorgu = "SELECT * from USERS where username='" + textBoxName.Text + "' and user_pwd= '" + textBoxPassword.Text + "' ";
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            Baglanti_Acma();
            try
            {
                read = cmd.ExecuteReader();
                if (read.Read() == true)
                {
                    MainMenu menu = new MainMenu(this);
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya Şifre Yanlış");
                    textBoxName.Clear();
                    textBoxPassword.Clear();
                    textBoxName.Focus();
                }
            }
            catch (Exception)
            {

            }
            Baglanti_Kapatma();
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
            catch (Exception )
            {
                MessageBox.Show("Internet bağlantınızı kontrol ediniz");
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gecis();
            }
        }
    }
}
