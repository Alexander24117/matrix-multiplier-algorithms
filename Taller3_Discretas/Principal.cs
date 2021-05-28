using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller3_Discretas.Logica;

namespace Taller3_Discretas
{
    public partial class Principal : Form
    {
        private static Logica.ServicioMatrices generar;
        public Principal()
        {
            InitializeComponent();
        }

        

        private void Principal_Load(object sender, EventArgs e)
        {
            generar = new Logica.ServicioMatrices();
            generar.SetGrafica(grafico);
            generar.SetMatrizA(GridA);
            generar.SetMatrizB(GridB);
            generar.SetMatrizM(GridT);
            generar.SetMatrizP(GridP);
            generar.SetMatrizS(GridS);
            generar.SetMatrizW(GridW);
            generar.SetMatrizC(GridRusos);
            btnGenerar.Enabled = false;
            btnGrafica.Enabled = false;
           
            btnParticion.Enabled = false;
            btnStrassen.Enabled = false;
            btnTradicion.Enabled = false;
            btnWinograd.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
            GridA.Rows.Clear();
            GridA.Columns.Clear();
            GridB.Rows.Clear();
            GridB.Columns.Clear();
            GridT.Rows.Clear();
            GridT.Columns.Clear();
            GridP.Rows.Clear();
            GridP.Columns.Clear();
            GridS.Rows.Clear();
            GridS.Columns.Clear();
            GridW.Rows.Clear();
            GridW.Columns.Clear();
            GridRusos.Rows.Clear();
            GridRusos.Columns.Clear();
            int nxm, min, max = 0;
            
            nxm = Convert.ToInt32(textN.Text);
            min = Convert.ToInt32(textMin.Text);
            max = Convert.ToInt32(textMax.Text);
            generar.llenarMatrices(nxm, min, max);
        }

        private void btnTradicion_Click(object sender, EventArgs e)
        {
            ServicioMatrices tiemposA = new ServicioMatrices();
            GridT.Rows.Clear();
            lblMetodo.Text = "Tradicional";
            tiemposA.IniciarTiempo();
            generar.llenarResultadoMultiplicar();
            lblInicial.Text = "0";
            lblFinal.Text = tiemposA.GetTiempoFinal() + " ms";
            lblTotal.Text = tiemposA.GetTiempoTotal() + " ms";

        }

        private void btnParticion_Click(object sender, EventArgs e)
        {
            GridP.Rows.Clear();
            ServicioMatrices tiemposA = new ServicioMatrices();
            lblMetodo.Text = "Partición";
            tiemposA.IniciarTiempo();
            generar.llenarResultadoParticion();
            lblInicial.Text = "0";
            lblFinal.Text = tiemposA.GetTiempoFinal() + " ms";
            lblTotal.Text = tiemposA.GetTiempoTotal() + " ms";
        }

        private void btnStrassen_Click(object sender, EventArgs e)
        {
            GridS.Rows.Clear();
            ServicioMatrices tiemposA = new ServicioMatrices();
            lblMetodo.Text = "Strassen";
            tiemposA.IniciarTiempo();
            generar.llenarResultadoStrassen();
            lblInicial.Text = "0";
            lblFinal.Text = tiemposA.GetTiempoFinal() + " ms";
            lblTotal.Text = tiemposA.GetTiempoTotal() + " ms";
        }

        private void btnWinograd_Click(object sender, EventArgs e)
        {
            GridW.Rows.Clear();
            ServicioMatrices tiemposA = new ServicioMatrices();
            lblMetodo.Text = "Winograd";
            tiemposA.IniciarTiempo();
            generar.llenarResultadoWinograd();
            lblInicial.Text = "0";
            lblFinal.Text = tiemposA.GetTiempoFinal() + " ms";
            lblTotal.Text = tiemposA.GetTiempoTotal() + " ms";
        }
        private void btnRusos_Click(object sender, EventArgs e)
        {
            GridRusos.Rows.Clear();
            lblMetodo.Text = "Cuatro Rusos";
            ServicioMatrices tiemposA = new ServicioMatrices();
            tiemposA.IniciarTiempo();
            generar.llenar4Rusos();
            lblInicial.Text = tiemposA.GetTiempoInicial() +" ms";
            lblFinal.Text = tiemposA.GetTiempoFinal() + " ms";
            lblTotal.Text = tiemposA.GetTiempoTotal() + " ms";
        }
        private void btnGrafica_Click(object sender, EventArgs e)
        {
            
            generar.GetTiempos(Convert.ToInt32(textm.Text));
            generar.grafico();
        }

        private void btnSetN_Click(object sender, EventArgs e)
        {
            generar.SetNxm(Convert.ToInt32(textN.Text));
            btnGenerar.Enabled = true;
            btnGrafica.Enabled = true;
            
            btnParticion.Enabled = true;
            btnStrassen.Enabled = true;
            btnTradicion.Enabled = true;
            btnWinograd.Enabled = true;
        }

        private void btnTiempo_Click(object sender, EventArgs e)
        {
            Tiempo gui = new Tiempo();
            gui.SetTablaTiempo(generar.GenerarTabla());
            gui.Show();
        }

        

        
    }
}
