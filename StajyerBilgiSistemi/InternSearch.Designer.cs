namespace StajyerBilgiSistemi
{
    partial class InternSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternSearch));
            this.labelTC = new System.Windows.Forms.Label();
            this.buttonSearchIntern = new System.Windows.Forms.Button();
            this.textBoxTC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTC
            // 
            this.labelTC.AutoSize = true;
            this.labelTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTC.Location = new System.Drawing.Point(36, 101);
            this.labelTC.Name = "labelTC";
            this.labelTC.Size = new System.Drawing.Size(84, 15);
            this.labelTC.TabIndex = 0;
            this.labelTC.Text = "T.C. Kimlik No";
            // 
            // buttonSearchIntern
            // 
            this.buttonSearchIntern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSearchIntern.Location = new System.Drawing.Point(88, 160);
            this.buttonSearchIntern.Name = "buttonSearchIntern";
            this.buttonSearchIntern.Size = new System.Drawing.Size(100, 23);
            this.buttonSearchIntern.TabIndex = 3;
            this.buttonSearchIntern.Text = "Ara";
            this.buttonSearchIntern.UseVisualStyleBackColor = true;
            this.buttonSearchIntern.Click += new System.EventHandler(this.buttonSearchIntern_Click);
            // 
            // textBoxTC
            // 
            this.textBoxTC.Location = new System.Drawing.Point(150, 100);
            this.textBoxTC.Name = "textBoxTC";
            this.textBoxTC.Size = new System.Drawing.Size(100, 20);
            this.textBoxTC.TabIndex = 4;
            this.textBoxTC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTC_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(37, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 7;
            // 
            // InternSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTC);
            this.Controls.Add(this.buttonSearchIntern);
            this.Controls.Add(this.labelTC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InternSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stajyer Arama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InternSearch_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTC;
        private System.Windows.Forms.Button buttonSearchIntern;
        private System.Windows.Forms.TextBox textBoxTC;
        private System.Windows.Forms.Label label4;
    }
}