using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StajyerBilgiSistemi
{
    public partial class MainMenu : Form
    {
        Form parent;
        public MainMenu(Form prnt)
        {
            parent = prnt;
            InitializeComponent();
        }

        private void buttonNewIntern_Click(object sender, EventArgs e)
        {
            NewIntern newIntern = new NewIntern(this);
            newIntern.Show();
            this.Hide();
        }

        private void buttonSearchIntern_Click(object sender, EventArgs e)
        {
            InternSearch search = new InternSearch(this);
            search.Show();
            this.Hide();
        }

        private void buttonListOfCards_Click(object sender, EventArgs e)
        {
            CardList cardList = new CardList(this);
            cardList.Show();
            this.Hide();
        }

        private void buttonListOfInterns_Click(object sender, EventArgs e)
        {
            InternList internList = new InternList(this);
            internList.Show();
            this.Hide();
        }

        private void btn_add_card_Click(object sender, EventArgs e)
        {
            AddCard add_card = new AddCard(this);
            add_card.Show();
            this.Hide();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Close();
        }

        private void result_Click(object sender, EventArgs e)
        {
            SearchingResults results = new SearchingResults(this);
            results.Show();
            this.Hide();
        }

       


    }
}
