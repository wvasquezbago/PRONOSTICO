namespace MOD1.Vistas
{
    partial class frmPronPesosAnios
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
            this.butCalcularPron = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.anios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // butCalcularPron
            // 
            this.butCalcularPron.Location = new System.Drawing.Point(76, 187);
            this.butCalcularPron.Name = "butCalcularPron";
            this.butCalcularPron.Size = new System.Drawing.Size(138, 39);
            this.butCalcularPron.TabIndex = 2;
            this.butCalcularPron.Text = "Calcular pronóstico";
            this.butCalcularPron.UseVisualStyleBackColor = true;
            this.butCalcularPron.Click += new System.EventHandler(this.butCalcularPron_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.anios,
            this.peso});
            this.dataGridView1.Location = new System.Drawing.Point(26, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(244, 156);
            this.dataGridView1.TabIndex = 3;
            // 
            // anios
            // 
            this.anios.HeaderText = "Años";
            this.anios.Name = "anios";
            this.anios.ReadOnly = true;
            // 
            // peso
            // 
            this.peso.HeaderText = "Pesos";
            this.peso.Name = "peso";
            // 
            // frmPronPesosAnios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 238);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butCalcularPron);
            this.Name = "frmPronPesosAnios";
            this.Text = "frmPronPesosAnios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button butCalcularPron;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn anios;
        private System.Windows.Forms.DataGridViewTextBoxColumn peso;
    }
}