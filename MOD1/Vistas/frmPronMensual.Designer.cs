namespace MOD1.Vistas
{
    partial class frmPronMensual
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
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.gcVenta = new DevExpress.XtraPivotGrid.PivotGridField();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcId_articulo = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcDesc = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcUni = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcMes = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcCat = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcMa = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcSub = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcPre = new DevExpress.XtraPivotGrid.PivotGridField();
            this.butGuardar = new System.Windows.Forms.Button();
            this.butRefrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.gcVenta,
            this.gcId_articulo,
            this.gcDesc,
            this.gcUni,
            this.gcMes,
            this.gcCat,
            this.gcMa,
            this.gcSub,
            this.gcPre});
            this.pivotGridControl1.Location = new System.Drawing.Point(6, 40);
            this.pivotGridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.pivotGridControl1.Size = new System.Drawing.Size(896, 437);
            this.pivotGridControl1.TabIndex = 0;
            this.pivotGridControl1.EditValueChanged += new DevExpress.XtraPivotGrid.EditValueChangedEventHandler(this.pivotGridControl1_EditValueChanged);
            // 
            // gcVenta
            // 
            this.gcVenta.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.gcVenta.AreaIndex = 0;
            this.gcVenta.FieldEdit = this.repositoryItemTextEdit1;
            this.gcVenta.FieldName = "VENTA";
            this.gcVenta.Name = "gcVenta";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gcId_articulo
            // 
            this.gcId_articulo.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcId_articulo.AreaIndex = 0;
            this.gcId_articulo.Caption = "ID_ART";
            this.gcId_articulo.FieldName = "ID_ARTICULO";
            this.gcId_articulo.Name = "gcId_articulo";
            this.gcId_articulo.Width = 200;
            // 
            // gcDesc
            // 
            this.gcDesc.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcDesc.AreaIndex = 1;
            this.gcDesc.Caption = "DESC";
            this.gcDesc.FieldName = "DESCR";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.Width = 300;
            // 
            // gcUni
            // 
            this.gcUni.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcUni.AreaIndex = 6;
            this.gcUni.Caption = "Un.";
            this.gcUni.FieldName = "UNIDADES";
            this.gcUni.Name = "gcUni";
            this.gcUni.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.gcUni.Width = 200;
            // 
            // gcMes
            // 
            this.gcMes.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.gcMes.AreaIndex = 0;
            this.gcMes.Caption = "MES";
            this.gcMes.FieldName = "FECHA";
            this.gcMes.Name = "gcMes";
            // 
            // gcCat
            // 
            this.gcCat.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcCat.AreaIndex = 2;
            this.gcCat.Caption = "CATEGORIA";
            this.gcCat.FieldName = "DESCRC";
            this.gcCat.Name = "gcCat";
            this.gcCat.Width = 200;
            // 
            // gcMa
            // 
            this.gcMa.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcMa.AreaIndex = 3;
            this.gcMa.FieldName = "MARCA";
            this.gcMa.Name = "gcMa";
            this.gcMa.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.gcMa.Width = 200;
            // 
            // gcSub
            // 
            this.gcSub.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcSub.AreaIndex = 4;
            this.gcSub.FieldName = "SUBMARCA";
            this.gcSub.Name = "gcSub";
            this.gcSub.Width = 200;
            // 
            // gcPre
            // 
            this.gcPre.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcPre.AreaIndex = 5;
            this.gcPre.FieldName = "PRESENTACION";
            this.gcPre.Name = "gcPre";
            this.gcPre.Width = 200;
            // 
            // butGuardar
            // 
            this.butGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGuardar.BackColor = System.Drawing.Color.DarkOrange;
            this.butGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butGuardar.ForeColor = System.Drawing.Color.White;
            this.butGuardar.Location = new System.Drawing.Point(688, 4);
            this.butGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.butGuardar.Name = "butGuardar";
            this.butGuardar.Size = new System.Drawing.Size(105, 32);
            this.butGuardar.TabIndex = 1;
            this.butGuardar.Text = "GUARDAR";
            this.butGuardar.UseVisualStyleBackColor = false;
            this.butGuardar.Click += new System.EventHandler(this.butGuardar_Click);
            // 
            // butRefrescar
            // 
            this.butRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRefrescar.BackColor = System.Drawing.Color.DarkOrange;
            this.butRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRefrescar.ForeColor = System.Drawing.Color.White;
            this.butRefrescar.Location = new System.Drawing.Point(797, 4);
            this.butRefrescar.Margin = new System.Windows.Forms.Padding(2);
            this.butRefrescar.Name = "butRefrescar";
            this.butRefrescar.Size = new System.Drawing.Size(105, 32);
            this.butRefrescar.TabIndex = 2;
            this.butRefrescar.Text = "REFRESCAR";
            this.butRefrescar.UseVisualStyleBackColor = false;
            this.butRefrescar.Click += new System.EventHandler(this.butRefrescar_Click);
            // 
            // frmPronMensual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(908, 482);
            this.Controls.Add(this.butRefrescar);
            this.Controls.Add(this.butGuardar);
            this.Controls.Add(this.pivotGridControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPronMensual";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRONÓSTICO MENSUAL";
            this.Load += new System.EventHandler(this.frmPronMensual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField gcVenta;
        private DevExpress.XtraPivotGrid.PivotGridField gcId_articulo;
        private DevExpress.XtraPivotGrid.PivotGridField gcDesc;
        private DevExpress.XtraPivotGrid.PivotGridField gcUni;
        private DevExpress.XtraPivotGrid.PivotGridField gcMes;
        private System.Windows.Forms.Button butGuardar;
        private System.Windows.Forms.Button butRefrescar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraPivotGrid.PivotGridField gcCat;
        private DevExpress.XtraPivotGrid.PivotGridField gcMa;
        private DevExpress.XtraPivotGrid.PivotGridField gcSub;
        private DevExpress.XtraPivotGrid.PivotGridField gcPre;
    }
}