using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller3_Discretas.Logica;

namespace Taller3_Discretas
{
    public partial class Tiempo : Form
    {
        
        public Tiempo()
        {
            InitializeComponent();
           
        }
        private DataTable tablaTiempo;
        private void Tiempo_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataTime.Columns.Clear();
            dataTime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataTime.DataSource = tablaTiempo;
            
        }
        public void SetTablaTiempo(DataTable data)
        {
            tablaTiempo = data;
        }
    }
}
