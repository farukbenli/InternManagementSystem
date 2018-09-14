namespace StajyerBilgiSistemi
{
    partial class CardList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardList));
            this.dataGridViewCardList = new System.Windows.Forms.DataGridView();
            this.btn_update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCardList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCardList
            // 
            this.dataGridViewCardList.AllowUserToAddRows = false;
            this.dataGridViewCardList.AllowUserToDeleteRows = false;
            this.dataGridViewCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCardList.Location = new System.Drawing.Point(13, 12);
            this.dataGridViewCardList.Name = "dataGridViewCardList";
            this.dataGridViewCardList.ReadOnly = true;
            this.dataGridViewCardList.Size = new System.Drawing.Size(565, 337);
            this.dataGridViewCardList.TabIndex = 0;
            this.dataGridViewCardList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCardList_CellClick);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(282, 357);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "GÜNCELLE";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // CardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 392);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.dataGridViewCardList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CardList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kart Listesi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CardList_FormClosing);
            this.Load += new System.EventHandler(this.CardList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCardList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCardList;
        private System.Windows.Forms.Button btn_update;
    }
}