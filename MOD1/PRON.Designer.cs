namespace MOD1
{
    partial class PRONÓSTICO : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PRONÓSTICO()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.butCargarPron = this.Factory.CreateRibbonButton();
            this.butCalcPron = this.Factory.CreateRibbonButton();
            this.butEnvResult = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.checkBox_Navegar = this.Factory.CreateRibbonCheckBox();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.butPronMens = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.buttonPronSemCuant = this.Factory.CreateRibbonButton();
            this.butPronDiaCuant = this.Factory.CreateRibbonButton();
            this.box1 = this.Factory.CreateRibbonBox();
            this.butPronSemDisc = this.Factory.CreateRibbonButton();
            this.butPronDiaDisc = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Label = "PRONÓSTICO";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.butCargarPron);
            this.group1.Items.Add(this.butCalcPron);
            this.group1.Items.Add(this.butEnvResult);
            this.group1.Items.Add(this.separator1);
            this.group1.Items.Add(this.checkBox_Navegar);
            this.group1.Label = "Inicio";
            this.group1.Name = "group1";
            // 
            // butCargarPron
            // 
            this.butCargarPron.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.butCargarPron.Image = global::MOD1.Properties.Resources.load;
            this.butCargarPron.Label = "Cargar Pronóstico";
            this.butCargarPron.Name = "butCargarPron";
            this.butCargarPron.ShowImage = true;
            this.butCargarPron.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butCargarPron_Click);
            // 
            // butCalcPron
            // 
            this.butCalcPron.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.butCalcPron.Image = global::MOD1.Properties.Resources.calc;
            this.butCalcPron.Label = "Calcular Pronóstico";
            this.butCalcPron.Name = "butCalcPron";
            this.butCalcPron.ShowImage = true;
            this.butCalcPron.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butCalcPron_Click);
            // 
            // butEnvResult
            // 
            this.butEnvResult.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.butEnvResult.Image = global::MOD1.Properties.Resources.send;
            this.butEnvResult.Label = "Enviar Resultados";
            this.butEnvResult.Name = "butEnvResult";
            this.butEnvResult.ShowImage = true;
            this.butEnvResult.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butEnvResult_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // checkBox_Navegar
            // 
            this.checkBox_Navegar.Label = "Navegar";
            this.checkBox_Navegar.Name = "checkBox_Navegar";
            // 
            // group2
            // 
            this.group2.Items.Add(this.butPronMens);
            this.group2.Label = "Datos";
            this.group2.Name = "group2";
            // 
            // butPronMens
            // 
            this.butPronMens.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.butPronMens.Image = global::MOD1.Properties.Resources.Calendar_1;
            this.butPronMens.Label = "Pronóstico Mensual";
            this.butPronMens.Name = "butPronMens";
            this.butPronMens.ShowImage = true;
            this.butPronMens.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butPronMens_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.buttonPronSemCuant);
            this.group3.Items.Add(this.butPronDiaCuant);
            this.group3.Items.Add(this.box1);
            this.group3.Items.Add(this.butPronSemDisc);
            this.group3.Items.Add(this.butPronDiaDisc);
            this.group3.Label = "Resultados";
            this.group3.Name = "group3";
            // 
            // buttonPronSemCuant
            // 
            this.buttonPronSemCuant.Image = global::MOD1.Properties.Resources.forecast1;
            this.buttonPronSemCuant.Label = "Pronóstico Semanal Cuantitativo";
            this.buttonPronSemCuant.Name = "buttonPronSemCuant";
            this.buttonPronSemCuant.ShowImage = true;
            this.buttonPronSemCuant.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonPronSemCalc_Click);
            // 
            // butPronDiaCuant
            // 
            this.butPronDiaCuant.Image = global::MOD1.Properties.Resources.forecast2;
            this.butPronDiaCuant.Label = "Pronóstico Diario Cuantitativo";
            this.butPronDiaCuant.Name = "butPronDiaCuant";
            this.butPronDiaCuant.ShowImage = true;
            this.butPronDiaCuant.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butPronDiaCalc_Click);
            // 
            // box1
            // 
            this.box1.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box1.Enabled = false;
            this.box1.Name = "box1";
            this.box1.Visible = false;
            // 
            // butPronSemDisc
            // 
            this.butPronSemDisc.Image = global::MOD1.Properties.Resources.original;
            this.butPronSemDisc.Label = "Pronóstico Semanal Discrecional";
            this.butPronSemDisc.Name = "butPronSemDisc";
            this.butPronSemDisc.ShowImage = true;
            this.butPronSemDisc.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butPronSemDisc_Click);
            // 
            // butPronDiaDisc
            // 
            this.butPronDiaDisc.Image = global::MOD1.Properties.Resources.forecast3;
            this.butPronDiaDisc.Label = "Pronóstico Diario Discrecional";
            this.butPronDiaDisc.Name = "butPronDiaDisc";
            this.butPronDiaDisc.ShowImage = true;
            this.butPronDiaDisc.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.butPronDiaDisc_Click);
            // 
            // PRONÓSTICO
            // 
            this.Name = "PRONÓSTICO";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.PRON_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butCargarPron;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butCalcPron;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butEnvResult;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butPronMens;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonPronSemCuant;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butPronDiaCuant;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butPronSemDisc;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton butPronDiaDisc;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox_Navegar;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
    }

    partial class ThisRibbonCollection
    {
        internal PRONÓSTICO PRON
        {
            get { return this.GetRibbon<PRONÓSTICO>(); }
        }
    }
}
