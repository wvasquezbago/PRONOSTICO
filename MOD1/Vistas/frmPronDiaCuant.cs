using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOD1.Vistas
{
    public partial class frmPronDiaCuant : Form
    {
        BOGeneral obj = new BOGeneral();
        public frmPronDiaCuant()
        {
            InitializeComponent();
        }

        private void frmPronDiaCalc_Load(object sender, EventArgs e)
        {
            BOGeneral dtProd = new BOGeneral();
            DataTable dt = dtProd.SelectPronDiarioCalculado();
            pivotGridControl1.BeginUpdate();
            pivotGridControl1.DataSource = dt;
            pivotGridControl1.EndUpdate();
            pivotGridControl1.OptionsCustomization.AllowFilterBySummary = false;
            pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            pivotGridControl1.OptionsView.ShowRowGrandTotals = false;

            gcIdarticulo.Width = 90;
            gcDesc.Width = 180;
            gcCat.Width = 100;
            gcMa.Width = 100;
            gcSu.Width = 100;
            gcPre.Width = 100;
            gcUni.Width = 70;
        }
    }
}
