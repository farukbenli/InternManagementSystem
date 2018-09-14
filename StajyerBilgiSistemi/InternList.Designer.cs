namespace StajyerBilgiSistemi
{
    partial class InternList
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
            this.dataGridViewInternList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInternList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInternList
            // 
            this.dataGridViewInternList.AllowUserToAddRows = false;
            this.dataGridViewInternList.AllowUserToDeleteRows = false;
            this.dataGridViewInternList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInternList.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewInternList.Name = "dataGridViewInternList";
            this.dataGridViewInternList.ReadOnly = true;
            this.dataGridViewInternList.Size = new System.Drawing.Size(631, 348);
            this.dataGridViewInternList.TabIndex = 0;
            this.dataGridViewInternList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInternList_CellClick);
            // 
            // InternList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 382);
            this.Controls.Add(this.dataGridViewInternList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InternList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stajyer Listesi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InternList_FormClosing);
            this.Load += new System.EventHandler(this.InternList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInternList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInternList;
    }
}