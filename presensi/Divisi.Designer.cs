namespace presensi
{
    partial class Divisi
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNik = new System.Windows.Forms.Label();
            this.tbNama = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbAktif = new System.Windows.Forms.CheckBox();
            this.cbTidakAktif = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(916, 193);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(414, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Divisi";
            // 
            // lblNik
            // 
            this.lblNik.AutoSize = true;
            this.lblNik.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNik.Location = new System.Drawing.Point(176, 312);
            this.lblNik.Name = "lblNik";
            this.lblNik.Size = new System.Drawing.Size(126, 25);
            this.lblNik.TabIndex = 5;
            this.lblNik.Text = "Nama Divisi";
            // 
            // tbNama
            // 
            this.tbNama.Location = new System.Drawing.Point(317, 318);
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(449, 20);
            this.tbNama.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(176, 359);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 25);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status";
            // 
            // cbAktif
            // 
            this.cbAktif.AutoSize = true;
            this.cbAktif.Location = new System.Drawing.Point(317, 367);
            this.cbAktif.Name = "cbAktif";
            this.cbAktif.Size = new System.Drawing.Size(47, 17);
            this.cbAktif.TabIndex = 7;
            this.cbAktif.Text = "Aktif";
            this.cbAktif.UseVisualStyleBackColor = true;
            // 
            // cbTidakAktif
            // 
            this.cbTidakAktif.AutoSize = true;
            this.cbTidakAktif.Location = new System.Drawing.Point(382, 367);
            this.cbTidakAktif.Name = "cbTidakAktif";
            this.cbTidakAktif.Size = new System.Drawing.Size(77, 17);
            this.cbTidakAktif.TabIndex = 8;
            this.cbTidakAktif.Text = "Tidak Aktif";
            this.cbTidakAktif.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(181, 453);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(585, 31);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // Divisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 500);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbTidakAktif);
            this.Controls.Add(this.cbAktif);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblNik);
            this.Controls.Add(this.tbNama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Divisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Divisi";
            this.Load += new System.EventHandler(this.Divisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNik;
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cbAktif;
        private System.Windows.Forms.CheckBox cbTidakAktif;
        private System.Windows.Forms.Button btnSubmit;
    }
}