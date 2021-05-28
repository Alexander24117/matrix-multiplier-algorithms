using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Taller3_Discretas.Logica
{
    class ServicioMatrices
    {
        ServicioMultiplicar multiplicar;
        ServicioParticion particion;
        ServicioStrassen strassen;
        ServicioWinograd winograd;
        DateTime tiempoInicial, tiempoFinal;
        TimeSpan tiempoTotal;
        private DataGridView tablaA, tablaB, tablaR,tablaM,tablaP,tablaS,tablaW,tiempos;
        private Chart grafica;
        private int nxm;
        private List<String> tiemposTradicional, tiemposParticion, tiemposStrassen, tiemposWinograd, tiempos4R,Mvalues;
        private static int[,] matrizA, matrizB;
        private DataTable data;
        public ServicioMatrices()
        {
            multiplicar = new ServicioMultiplicar();
            particion = new ServicioParticion();
            strassen = new ServicioStrassen();
            winograd = new ServicioWinograd();
            tiemposTradicional = new List<String>();
            tiemposParticion = new List<String>();
            tiemposStrassen = new List<String>();
            tiemposWinograd = new List<String>();
            tiempos4R = new List<string>();
            Mvalues = new List<String>();
        }
        public void SetNxm(int nxm)
        {
            this.nxm = nxm;
        }
        
        public void SetMatrizA(DataGridView grid)
        {
            tablaA = grid;
        }
        public void SetMatrizB(DataGridView grid)
        {
            tablaB = grid;
        }
        public void SetMatrizC(DataGridView grid)
        {
            tablaR = grid;
        }
        public void SetMatrizM(DataGridView grid)
        {
            tablaM = grid;
        }
        public void SetMatrizP(DataGridView grid)
        {
            tablaP = grid;
        }
        public void SetMatrizS(DataGridView grid)
        {
            tablaS = grid;
        }
        public void SetMatrizW(DataGridView grid)
        {
            tablaW = grid;
        }
        public void SetTiempos(DataGridView grid)
        {
            tiempos = grid;
        }
        public void SetGrafica(Chart chart)
        {
            grafica = chart;
        }
        public int generateRandomNumber(int a,int b)
        {
            var guid = Guid.NewGuid();
            var numbers = new String(guid.ToString().Where(char.IsDigit).ToArray());
            var seed = Convert.ToInt32(numbers.Substring(0, 4));

            var random = new Random(seed);

            int number = random.Next(a, b + 1);
            return number;
        }

        public void llenarMatrices(int nxm, int rangeMin,int rangeMax)
        {
            matrizA = new int[nxm, nxm];
            matrizB = new int[nxm, nxm];
            for (int i = 0; i < nxm; i++)
            {
                tablaA.Columns.Add("", "");
                tablaB.Columns.Add("", "");
                tablaR.Columns.Add("", "");
                tablaM.Columns.Add("", "");
                tablaP.Columns.Add("", "");
                tablaS.Columns.Add("", "");
                tablaW.Columns.Add("", "");
            }
            //Matriz A
            for (int i = 0; i < nxm; i++)
            {
                int fila = tablaA.Rows.Add();
                for (int j = 0; j < nxm; j++)
                {
                    int numAleatoreo = generateRandomNumber(rangeMin, rangeMax);
                    
                    tablaA.Rows[fila].Cells[j].Value = numAleatoreo.ToString();
                    matrizA[i, j] = numAleatoreo;
                }
            }
            // Matriz B
            for (int i = 0; i < nxm; i++)
            {
                int fila = tablaB.Rows.Add();
                for (int j = 0; j < nxm; j++)
                {
                    int numAleatoreo = generateRandomNumber(rangeMin, rangeMax);
                    
                    tablaB.Rows[fila].Cells[j].Value = numAleatoreo.ToString();
                    matrizB[i, j] = numAleatoreo;
                }
            }

        }

        

        public int[,] getMatrizA() {
            
            return matrizA;
        }
        public int[,] getMatrizB()
        {
            return matrizB;
        }

        public void llenarResultadoMultiplicar()
        {
            
            multiplicar.multiplicarTradicional(getMatrizA(),getMatrizB());
            int[,] resultado = multiplicar.getResultado();
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                int fila = tablaM.Rows.Add();

                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    tablaM.Rows[fila].Cells[j].Value = resultado[i, j];
                }
            }
           
        }

        public void llenarResultadoParticion()
        {


            particion.multiplicarParticion(getMatrizA(), getMatrizB());
            int[,] resultado = particion.getResultado();
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                int fila = tablaP.Rows.Add();

                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    tablaP.Rows[fila].Cells[j].Value = resultado[i, j];
                }
            }
            
        }

        public void llenarResultadoStrassen()
        {
            strassen.multiplicarStrassen(getMatrizA(), getMatrizB());
            int[,] resultado = strassen.getResultado();
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                int fila = tablaS.Rows.Add();

                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    tablaS.Rows[fila].Cells[j].Value = resultado[i, j];
                }
            }
            
        }
        public void llenarResultadoWinograd()
        {


            winograd.multiplicarWinograd(getMatrizA(), getMatrizB());
            int[,] resultado = winograd.getResultado();

            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                int fila = tablaW.Rows.Add();

                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    tablaW.Rows[fila].Cells[j].Value = resultado[i, j];
                }
            }
            
        }

        public void llenar4Rusos()
        {
            
            Servicio4Rusos.multiplicacion4Rusos(matrizA,matrizB);
            int[,] resultado = Servicio4Rusos.GetResultado();
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                int fila = tablaR.Rows.Add();

                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    tablaR.Rows[fila].Cells[j].Value = resultado[i, j];
                }
            }
        }
        
        //metodo for haciemdo los tiempos 4 em orden 
        // como sacar los datos de cada uno 
        public void GetTiempos(int iteraciones)
        {
            Stopwatch tiempoT = new Stopwatch();
            Stopwatch tiempoP = new Stopwatch();
            Stopwatch tiempoS = new Stopwatch();
            Stopwatch tiempoW = new Stopwatch();
            Stopwatch tiempo4R = new Stopwatch();
            data =  new DataTable();
            data.Columns.Add("n", typeof(string));
            data.Columns.Add("Tradicional", typeof(string));
            data.Columns.Add("Particion", typeof(string));
            data.Columns.Add("Strassen", typeof(string));
            data.Columns.Add("Winograd", typeof(string));
            data.Columns.Add("4 Rusos", typeof(string));
            tiemposTradicional.Clear();
            tiemposParticion.Clear();
            tiemposStrassen.Clear();
            tiemposWinograd.Clear();
            tiempos4R.Clear();

            for (int i = 0; i < iteraciones; i++)
            {
                
                Mvalues.Add(Convert.ToString(i+1));
                //--------------------------------
                tiempoT.Start();
                multiplicar.multiplicarTradicional(getMatrizA(), getMatrizB());
                tiempoT.Stop();
                // 0.050 0.06 0.08
                // 0.05 0.07 0.1 0.12 0.4
                //string valueT = tiempoT.Elapsed.ToString("ss\\.fffffff");
                string valueT = Convert.ToString((tiempoT.Elapsed.Ticks)*1);
                tiemposTradicional.Add(valueT);

                //--------------------------------
                tiempoP.Start();
                particion.multiplicarParticion(getMatrizA(), getMatrizB());
                tiempoP.Stop();
                String valueP = Convert.ToString((tiempoP.Elapsed.Ticks)*1);
                tiemposParticion.Add(valueP);

                //--------------------------------
                tiempoS.Start();
                strassen.multiplicarStrassen(getMatrizA(), getMatrizB());
                tiempoS.Stop();
                String valueS = Convert.ToString(tiempoS.Elapsed.Ticks*1);
                tiemposStrassen.Add(valueS);

                //--------------------------------
                tiempoW.Start();
                winograd.multiplicarWinograd(getMatrizA(), getMatrizB());
                tiempoW.Stop();
                String valueW = Convert.ToString(tiempoW.Elapsed.Ticks *1);
                tiemposWinograd.Add(valueW);
                
                //--------------------------------
                tiempo4R.Start();
                Servicio4Rusos.multiplicacion4Rusos(getMatrizA(), getMatrizB());
                tiempo4R.Stop();
                String value4R = Convert.ToString(tiempo4R.Elapsed.Ticks *1);
                data.Rows.Add(Convert.ToString(i + 1), valueT, valueP, valueS, valueW,value4R);
            }


        }
        public void grafico()
        {
            grafica.Series.Clear();


            // n - T - P - S - W
            
            grafica.Series.Add("Tradicional");
            grafica.Series["Tradicional"].ChartType = SeriesChartType.Line;
            grafica.Series["Tradicional"].YValueMembers = "Tradicional";
            grafica.Series.Add("Particion");
            grafica.Series["Particion"].ChartType = SeriesChartType.Line;
            grafica.Series["Particion"].YValueMembers = "Particion";
            grafica.Series.Add("Strassen");
            grafica.Series["Strassen"].ChartType = SeriesChartType.Line;
            grafica.Series["Strassen"].YValueMembers = "Strassen";
            grafica.Series.Add("Winograd");
            grafica.Series["Winograd"].ChartType = SeriesChartType.Line;
            grafica.Series["Winograd"].YValueMembers = "Winograd";
            grafica.Series.Add("4 Rusos");
            grafica.Series["4 Rusos"].ChartType = SeriesChartType.Line;
            grafica.Series["4 Rusos"].YValueMembers = "4 Rusos";
            grafica.DataSource = GenerarTabla();
        }
        public DataTable GenerarTabla()
        {
            return data;
        }

        public void IniciarTiempo()
        {
            
            tiempoInicial = DateTime.Now;
        }
        public void PararTiempo()
        {
            tiempoFinal = DateTime.Now;
            tiempoTotal = new TimeSpan(tiempoFinal.Ticks - tiempoInicial.Ticks);
        }
        public String GetTiempoInicial()
        {
            return tiempoInicial.Millisecond.ToString("##.00");
        }
        public String GetTiempoFinal()
        {
            return tiempoFinal.Millisecond.ToString("##.00");
        }
        public String GetTiempoTotal()
        {
            return tiempoTotal.TotalMilliseconds.ToString();
        }
    }
}
