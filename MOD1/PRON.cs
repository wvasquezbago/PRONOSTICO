using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using MOD1.Vistas;
using System.Diagnostics;
using Calculo_Pronostico_Diario;
using System.Windows.Forms;
using System.IO;
using CargaExcel;
using MOD1.Entidades;

namespace MOD1
{
    public partial class PRONÓSTICO
    {
        private void PRON_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void buttonPronSemCalc_Click(object sender, RibbonControlEventArgs e)
        {
            if (checkBox_Navegar.Checked)
            {                
                Globals.ThisWorkbook.Application.Run("VerPSC");
                Globals.ThisWorkbook.Application.Run("Cargar_pronostico_semanal_calculado");
            }
            frmPronSemCuant pron = new frmPronSemCuant();
            pron.WindowState = FormWindowState.Maximized;
            pron.Show();
        }

        private void butPronDiaCalc_Click(object sender, RibbonControlEventArgs e)
        {
            if (checkBox_Navegar.Checked)
            {
                Globals.ThisWorkbook.Application.Run("VerPDC");
                Globals.ThisWorkbook.Application.Run("Cargar_pronostico_diario_calculado");
            }
            frmPronDiaCuant pron = new frmPronDiaCuant();
            pron.WindowState = FormWindowState.Maximized;
            pron.Show();
        }

        private void butPronSemDisc_Click(object sender, RibbonControlEventArgs e)
        {
            if (checkBox_Navegar.Checked)
            {
                Globals.ThisWorkbook.Application.Run("VerPSD");
                Globals.ThisWorkbook.Application.Run("Cargar_pronostico_semanal_discreto");
            }
            frmPronSemDisc pron = new frmPronSemDisc();
            pron.WindowState = FormWindowState.Maximized;
            pron.Show();
        }

        private void butPronDiaDisc_Click(object sender, RibbonControlEventArgs e)
        {
            if (checkBox_Navegar.Checked)
            {
                Globals.ThisWorkbook.Application.Run("VerPDD");
                Globals.ThisWorkbook.Application.Run("Cargar_pronostico_diario_discreto");
            }
            frmPronDiaDisc pron = new frmPronDiaDisc();
            pron.WindowState = FormWindowState.Maximized;
            pron.Show();
        }

        private void butPronMens_Click(object sender, RibbonControlEventArgs e)
        {
            if (checkBox_Navegar.Checked)
            {
                Globals.ThisWorkbook.Application.Run("VerPM");
                Globals.ThisWorkbook.Application.Run("refrescar_pronostico_mensual");
            }
            frmPronMensual pron = new frmPronMensual();
            pron.WindowState = FormWindowState.Maximized;
            pron.Show();
        }

        private void butCargarPron_Click(object sender, RibbonControlEventArgs e)
        {
            BOGeneral bo = new BOGeneral();
            //Lee el archivo del pronòstico
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Excel files (*.xlsm;*.xlsx;*.xlsx)|*.xlsm;*.xlsx;*.xlsx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            Manager manager = Manager.getInstance();
                            manager.loadForecast(openFileDialog.FileName);
                            //Actualiza el registro Historico de Ventas por dia
                            //Referencia con conexion al baan            
                            bo.UpdHisDia();
                            bo.HisToMod1His();
                            //Validaciòn de los artìculos matriculados
                            int NumInc=bo.SelectNumInc();
                            if (NumInc>0)
                            {
                            MessageBox.Show("Existen " + NumInc + " nuevos artículos no matrículados, los demás fueron cargados correctamente");
                            Globals.ThisWorkbook.Application.Run("cargar_art_inc");
                            bo.NormProMen();
                            }
                            else
                            { 
                            MessageBox.Show("Carga finalizada correctamente");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    
                }
            }
        }

        private void butCalcPron_Click(object sender, RibbonControlEventArgs e)
        {
            frmPronPesosAnios frm = new frmPronPesosAnios();
            frm.Show();
        }

        private void butEnvResult_Click(object sender, RibbonControlEventArgs e)
        {
            Conex dbconex = new Conex();
            List<string> storedProcedures = new List<string>();
            storedProcedures.Add(StoredProcedure.MOD1_SET_PRONO_SEMANA);
            storedProcedures.Add(StoredProcedure.MOD1_SET_PRONO_MONTH_MOD);
            dbconex.executeStoredProcedures(storedProcedures);
            MessageBox.Show("Se enviaron los resultados correctamente.");
        }
    }
}
