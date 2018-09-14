namespace StajyerBilgiSistemi
{
    partial class SearchingResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchingResults));
            this.dataGridViewSearcResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearcResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSearcResults
            // 
            this.dataGridViewSearcResults.AllowUserToAddRows = false;
            this.dataGridViewSearcResults.AllowUserToDeleteRows = false;
            this.dataGridViewSearcResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearcResults.Location = new System.Drawing.Point(12, 43);
            this.dataGridViewSearcResults.Name = "dataGridViewSearcResults";
            this.dataGridViewSearcResults.Size = new System.Drawing.Size(543, 178);
            this.dataGridViewSearcResults.TabIndex = 2;
            this.dataGridViewSearcResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearcResults_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BİTİŞ TARİHİ GEÇİP KARTI ALINMAYAN STAJYERLER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // SearchingResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 240);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSearcResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchingResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arama Sonuçları";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchingResults_FormClosing);
            this.Load += new System.EventHandler(this.SearchingResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearcResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSearcResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}