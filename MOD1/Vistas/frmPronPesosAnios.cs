using Calculo_Pronostico_Diario;
using MOD1.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace MOD1.Vistas
{
    public partial class frmPronPesosAnios : Form
    {
        public frmPronPesosAnios()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            Datos dat = new Datos();
            dat.abrirConexion();
            List<int> years = dat.getHDYears();
            float peso = 0.4f;
            float uni = 1;
            foreach (int year in years)
            {
                uni = uni - peso;
                this.dataGridView1.Rows.Add(year, peso);
                if (uni <= 0)
                {
                    peso = 0;
                }
                else
                {
                    peso = 0.3f;
                }
            }
        }

        private void butCalcularPron_Click(object sender, EventArgs e)
        {
            try
            {
                List<float> list = new List<float>();
                float suma = 0;
                float peso;

                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    peso = float.Parse(dataGridView1.Rows[row].Cells[1].Value.ToString());
                    list.Add(peso);
                    suma += peso;
                }

                if (suma == 1)
                {
                    PesosAnios pesos = new PesosAnios
                    {
                        pesos = list
                    };

                    this.Hide();
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Calculo calc = new Calculo();
                    calc.calcularPronosticoDiario(pesos);
                    sw.Stop();
                    MessageBox.Show("Pronóstico diario generado\nTiempo de ejecucción: " + sw.Elapsed);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los pesos deben sumar 1");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "\nEl campo debe contener un número.");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message + "\nEl campo no debe estar vacío.");
            }
        }
    }
}
