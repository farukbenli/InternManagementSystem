namespace StajyerBilgiSistemi
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNewIntern = new System.Windows.Forms.Button();
            this.buttonSearchIntern = new System.Windows.Forms.Button();
            this.buttonListOfCards = new System.Windows.Forms.Button();
            this.buttonListOfInterns = new System.Windows.Forms.Button();
            this.btn_add_card = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(48, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stajyer Bilgi Sistemi";
            // 
            // buttonNewIntern
            // 
            this.buttonNewIntern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonNewIntern.Location = new System.Drawing.Point(66, 62);
            this.buttonNewIntern.Name = "buttonNewIntern";
            this.buttonNewIntern.Size = new System.Drawing.Size(138, 23);
            this.buttonNewIntern.TabIndex = 1;
            this.buttonNewIntern.Text = "Yeni Stajyer";
            this.buttonNewIntern.UseVisualStyleBackColor = true;
            this.buttonNewIntern.Click += new System.EventHandler(this.buttonNewIntern_Click);
            // 
            // buttonSearchIntern
            // 
            this.buttonSearchIntern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSearchIntern.Location = new System.Drawing.Point(66, 104);
            this.buttonSearchIntern.Name = "buttonSearchIntern";
            this.buttonSearchIntern.Size = new System.Drawing.Size(138, 23);
            this.buttonSearchIntern.TabIndex = 2;
            this.buttonSearchIntern.Text = "Stajyer Arama";
            this.buttonSearchIntern.UseVisualStyleBackColor = true;
            this.buttonSearchIntern.Click += new System.EventHandler(this.buttonSearchIntern_Click);
            // 
            // buttonListOfCards
            // 
            this.buttonListOfCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonListOfCards.Location = new System.Drawing.Point(66, 143);
            this.buttonListOfCards.Name = "buttonListOfCards";
            this.buttonListOfCards.Size = new System.Drawing.Size(138, 23);
            this.buttonListOfCards.TabIndex = 3;
            this.buttonListOfCards.Text = "Kart Listesi";
            this.buttonListOfCards.UseVisualStyleBackColor = true;
            this.buttonListOfCards.Click += new System.EventHandler(this.buttonListOfCards_Click);
            // 
            // buttonListOfInterns
            // 
            this.buttonListOfInterns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonListOfInterns.Location = new System.Drawing.Point(66, 183);
            this.buttonListOfInterns.Name = "buttonListOfInterns";
            this.buttonListOfInterns.Size = new System.Drawing.Size(138, 23);
            this.buttonListOfInterns.TabIndex = 4;
            this.buttonListOfInterns.Text = "Stajyer Listesi";
            this.buttonListOfInterns.UseVisualStyleBackColor = true;
            this.buttonListOfInterns.Click += new System.EventHandler(this.buttonListOfInterns_Click);
            // 
            // btn_add_card
            // 
            this.btn_add_card.Location = new System.Drawing.Point(66, 226);
            this.btn_add_card.Name = "btn_add_card";
            this.btn_add_card.Size = new System.Drawing.Size(138, 23);
            this.btn_add_card.TabIndex = 5;
            this.btn_add_card.Text = "Kart Ekleme";
            this.btn_add_card.UseVisualStyleBackColor = true;
            this.btn_add_card.Click += new System.EventHandler(this.btn_add_card_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(66, 272);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(138, 23);
            this.result.TabIndex = 7;
            this.result.Text = "Çıkış Yapılmayanlar";
            this.result.UseVisualStyleBackColor = true;
            this.result.Click += new System.EventHandler(this.result_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 356);
            this.Controls.Add(this.result);
            this.Controls.Add(this.btn_add_card);
            this.Controls.Add(this.buttonListOfInterns);
            this.Controls.Add(this.buttonListOfCards);
            this.Controls.Add(this.buttonSearchIntern);
            this.Controls.Add(this.buttonNewIntern);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNewIntern;
        private System.Windows.Forms.Button buttonSearchIntern;
        private System.Windows.Forms.Button buttonListOfCards;
        private System.Windows.Forms.Button buttonListOfInterns;
        private System.Windows.Forms.Button btn_add_card;
        private System.Windows.Forms.Button result;
    }
}