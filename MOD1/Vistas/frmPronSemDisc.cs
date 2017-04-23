using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace MOD1.Vistas
{
    public partial class frmPronSemDisc : Form
    {
        BOGeneral obj = new BOGeneral();
        public frmPronSemDisc()
        {
            InitializeComponent();
        }

        private void frmPronSemDisc_Load(object sender, EventArgs e)
        {
            BOGeneral dtProd = new BOGeneral();
            DataTable dt = dtProd.SelectPronSemDiscreto();
            pivotGridControl1.BeginUpdate();
            pivotGridControl1.DataSource = dt;
            pivotGridControl1.EndUpdate();
            pivotGridControl1.OptionsCustomization.AllowFilterBySummary = false;
            pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            //para diferenciar los editables
            gcVenta.Appearance.Cell.BackColor = Color.FromArgb(161, 226, 161);

            gcIdarticulo.Width = 90;
            gcDesc.Width = 180;
            gcCa.Width = 100;
            gcMa.Width = 100;
            gcSu.Width = 100;
            gcPre.Width = 100;
            gcUni.Width = 70;
        }

        private void butGuardar_Click(object sender, EventArgs e)
        {
            DataTable dtart = pivotGridControl1.DataSource as DataTable;
            try
            {
                DataTable dt = dtart.GetChanges(DataRowState.Modified);
                obj.updPronSemDiscreto(dt);
                dtart.AcceptChanges();
                Globals.ThisWorkbook.Application.Run("Cargar_pronostico_semanal_discreto");
                MessageBox.Show("Registros Guardados Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butRefrescar_Click(object sender, EventArgs e)
        {
            frmPronSemDisc_Load(this, e);
        }

        private void pivotGridControl1_EditValueChanged(object sender, DevExpress.XtraPivotGrid.EditValueChangedEventArgs e)
        {
            try
            {
                double newValue = Convert.ToDouble(e.Editor.EditValue);
                double oldValue = Convert.ToDouble(e.Value);

                PivotDrillDownDataSource ds = e.CreateDrillDownDataSource();
                for (int i = 0; i < ds.RowCount; i++)
                {
                    double rowValue = Convert.ToDouble(ds[i][e.DataField]);
                    ds.SetValue(i, e.DataField, newValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El valor asignado es incorrecto");
            }
        }
    }
}
