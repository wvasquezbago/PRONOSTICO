namespace MOD1.Vistas
{
    partial class frmPronDiaCuant
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
            this.gcIdarticulo = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcDesc = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcUni = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcFec = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcCat = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcMa = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcSu = new DevExpress.XtraPivotGrid.PivotGridField();
            this.gcPre = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.gcVenta,
            this.gcIdarticulo,
            this.gcDesc,
            this.gcUni,
            this.gcFec,
            this.gcCat,
            this.gcMa,
            this.gcSu,
            this.gcPre});
            this.pivotGridControl1.Location = new System.Drawing.Point(1, 2);
            this.pivotGridControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(898, 471);
            this.pivotGridControl1.TabIndex = 0;
            // 
            // gcVenta
            // 
            this.gcVenta.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.gcVenta.AreaIndex = 0;
            this.gcVenta.Caption = "VENTA";
            this.gcVenta.FieldName = "venta";
            this.gcVenta.Name = "gcVenta";
            // 
            // gcIdarticulo
            // 
            this.gcIdarticulo.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcIdarticulo.AreaIndex = 0;
            this.gcIdarticulo.Caption = "ID_ART";
            this.gcIdarticulo.FieldName = "ID_ARTICULO";
            this.gcIdarticulo.Name = "gcIdarticulo";
            this.gcIdarticulo.Width = 200;
            // 
            // gcDesc
            // 
            this.gcDesc.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcDesc.AreaIndex = 1;
            this.gcDesc.Caption = "DESCRIPCION";
            this.gcDesc.FieldName = "DESCR";
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.Width = 300;
            // 
            // gcUni
            // 
            this.gcUni.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcUni.AreaIndex = 6;
            this.gcUni.FieldName = "UNIDADES";
            this.gcUni.Name = "gcUni";
            this.gcUni.Width = 200;
            // 
            // gcFec
            // 
            this.gcFec.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.gcFec.AreaIndex = 0;
            this.gcFec.FieldName = "FECHA";
            this.gcFec.Name = "gcFec";
            // 
            // gcCat
            // 
            this.gcCat.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcCat.AreaIndex = 2;
            this.gcCat.FieldName = "CATEGORIA";
            this.gcCat.Name = "gcCat";
            this.gcCat.Width = 200;
            // 
            // gcMa
            // 
            this.gcMa.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcMa.AreaIndex = 3;
            this.gcMa.FieldName = "MARCA";
            this.gcMa.Name = "gcMa";
            this.gcMa.Width = 200;
            // 
            // gcSu
            // 
            this.gcSu.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcSu.AreaIndex = 4;
            this.gcSu.FieldName = "SUBMARCA";
            this.gcSu.Name = "gcSu";
            this.gcSu.Width = 200;
            // 
            // gcPre
            // 
            this.gcPre.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.gcPre.AreaIndex = 5;
            this.gcPre.FieldName = "PRESENTACION";
            this.gcPre.Name = "gcPre";
            this.gcPre.Width = 200;
            // 
            // frmPronDiaCuant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(903, 476);
            this.Controls.Add(this.pivotGridControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmPronDiaCuant";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRONÓSTICO DIARIO CUANTITATIVO";
            this.Load += new System.EventHandler(this.frmPronDiaCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField gcVenta;
        private DevExpress.XtraPivotGrid.PivotGridField gcIdarticulo;
        private DevExpress.XtraPivotGrid.PivotGridField gcDesc;
        private DevExpress.XtraPivotGrid.PivotGridField gcUni;
        private DevExpress.XtraPivotGrid.PivotGridField gcFec;
        private DevExpress.XtraPivotGrid.PivotGridField gcCat;
        private DevExpress.XtraPivotGrid.PivotGridField gcMa;
        private DevExpress.XtraPivotGrid.PivotGridField gcSu;
        private DevExpress.XtraPivotGrid.PivotGridField gcPre;
    }
}