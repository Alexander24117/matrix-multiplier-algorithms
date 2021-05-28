using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller3_Discretas.Logica
{
    class Servicio4Rusos
    {
        private static int[,] matrizC;
        //
       // private static int[,] a, b;

       /*public static void crear()
        {
            a = new int[8, 8];
            
           
            
            a[0, 0] = 0;
            a[0, 1] = 0;
            a[0, 2] = 1;
            a[0, 3] = 0;
            a[0, 4] = 0;
            a[0, 5] = 0;
            a[0, 6] = 1;
            a[0, 7] = 0;

            a[1, 0] = 1;
            a[1, 1] = 0;
            a[1, 2] = 0;
            a[1, 3] = 1;
            a[1, 4] = 1;
            a[1, 5] = 0;
            a[1, 6] = 1;
            a[1, 7] = 0;

            a[2, 0] = 1;
            a[2, 1] = 1;
            a[2, 2] = 1;
            a[2, 3] = 1;
            a[2, 4] = 1;
            a[2, 5] = 0;
            a[2, 6] = 1;
            a[2, 7] = 0;

            a[3, 0] = 1;
            a[3, 1] = 0;
            a[3, 2] = 0;
            a[3, 3] = 0;
            a[3, 4] = 1;
            a[3, 5] = 0;
            a[3, 6] = 1;
            a[3, 7] = 0;

            a[4, 0] = 1;
            a[4, 1] = 1;
            a[4, 2] = 0;
            a[4, 3] = 0;
            a[4, 4] = 0;
            a[4, 5] = 0;
            a[4, 6] = 1;
            a[4, 7] = 1;

            a[5, 0] = 1;
            a[5, 1] = 0;
            a[5, 2] = 1;
            a[5, 3] = 1;
            a[5, 4] = 0;
            a[5, 5] = 1;
            a[5, 6] = 0;
            a[5, 7] = 0;

            a[6, 0] = 0;
            a[6, 1] = 0;
            a[6, 2] = 0;
            a[6, 3] = 1;
            a[6, 4] = 0;
            a[6, 5] = 0;
            a[6, 6] = 1;
            a[6, 7] = 0;

            a[7, 0] = 0;
            a[7, 1] = 1;
            a[7, 2] = 1;
            a[7, 3] = 1;
            a[7, 4] = 0;
            a[7, 5] = 1;
            a[7, 6] = 0;
            a[7, 7] = 0;
            //---------------
            
        }

        public static void crearB()
        {
            b = new int[8, 8];
            b[0, 0] = 1;
            b[0, 1] = 1;
            b[0, 2] = 0;
            b[0, 3] = 1;
            b[0, 4] = 1;
            b[0, 5] = 0;
            b[0, 6] = 0;
            b[0, 7] = 0;

            b[1, 0] = 0;
            b[1, 1] = 0;
            b[1, 2] = 0;
            b[1, 3] = 0;
            b[1, 4] = 1;
            b[1, 5] = 0;
            b[1, 6] = 0;
            b[1, 7] = 1;

            b[2, 0] = 1;
            b[2, 1] = 0;
            b[2, 2] = 0;
            b[2, 3] = 0;
            b[2, 4] = 0;
            b[2, 5] = 0;
            b[2, 6] = 0;
            b[2, 7] = 0;

            b[3, 0] = 0;
            b[3, 1] = 0;
            b[3, 2] = 1;
            b[3, 3] = 0;
            b[3, 4] = 1;
            b[3, 5] = 1;
            b[3, 6] = 1;
            b[3, 7] = 1;

            b[4, 0] = 1;
            b[4, 1] = 1;
            b[4, 2] = 1;
            b[4, 3] = 0;
            b[4, 4] = 0;
            b[4, 5] = 0;
            b[4, 6] = 0;
            b[4, 7] = 0;

            b[5, 0] = 0;
            b[5, 1] = 1;
            b[5, 2] = 1;
            b[5, 3] = 0;
            b[5, 4] = 1;
            b[5, 5] = 0;
            b[5, 6] = 1;
            b[5, 7] = 1;

            b[6, 0] = 0;
            b[6, 1] = 0;
            b[6, 2] = 0;
            b[6, 3] = 0;
            b[6, 4] = 1;
            b[6, 5] = 1;
            b[6, 6] = 1;
            b[6, 7] = 0;

            b[7, 0] = 0;
            b[7, 1] = 1;
            b[7, 2] = 0;
            b[7, 3] = 0;
            b[7, 4] = 1;
            b[7, 5] = 0;
            b[7, 6] = 1;
            b[7, 7] = 0;
        }*/
        public static int[,] GetResultado()
        {
            for (int i = 0; i<matrizC.GetLength(0);i++)
            {
                for (int j = 0;j<matrizC.GetLength(1);j++)
                {
                    if (matrizC[i,j]>0)
                    {

                        matrizC[i, j] = 1;
                    }
                    else
                    {
                        matrizC[i, j] = 0;
                    }
                }
            }
            return matrizC;
        }
        public static void multiplicacion4Rusos(int[,]a,int[,]b)
        {
           
            int n = a.GetLength(0);
            matrizC = new int[n, n];
            int m = (int)Math.Floor(Math.Log(n,2));
            if (n > 3 && m < 2) m = 2;
            int nm = (int)Math.Ceiling((decimal)n / m);
            int[,] Ci = new int[n, n];
            int[,] Ctemp = new int[n, n];
            int dosM1 = ((int)(Math.Pow(2, m) - 1));
            
            for (int i = 1; i <= nm; i++)
            {
               
                int[,] subAi = darSubMatrizA(a,i,nm);
                int[,] subBi = darSubMatrizB(b, i, nm);
                int[,] rowsum = new int[n, n];
                for (int j = 1; j <= dosM1; j++)
                {
                    int k = (int)Math.Floor(Math.Log(j, 2));
                    for (int l = 0; l < n; l++)
                    {
                        if (rowsum[j - (int)(Math.Pow(2, k)), l] +subBi[k,l] > 0)
                        {

                            rowsum[j, l] = 1;
                        }
                        else
                        {
                            rowsum[j, l] = 0;
                        }

                    }
                }

                //invertir 
                for(int o =0; o < Ci.GetLength(0); o++)
                {
                    string binary = "";
                    for (int p = 0; p < subAi.GetLength(1); p++)
                    {
                        binary += subAi[o, p];

                    }
                    int pos =  DarNumeroInvertido(binary);
                    for (int q =0; q < rowsum.GetLength(1); q++)
                    {
                        if (rowsum[pos, q] + Ci[o, q] > 0)
                        {
                            Ci[o, q] = 1;
                        }
                        else
                        {
                            Ci[o, q] = 0;
                        }
                        Ctemp[o,q] += Ci[o,q];
                    }
                    
                }
                Ctemp = matrizC;
            }
            

        }
        public static int[,] darSubMatrizA(int[,]matrizA,int iteracion,int nm)
        {
            int[,] subMA = new int[ matrizA.GetLength(0), nm];
            // 3,6,9 -1 - nm

            // it =1 -> 0-3 it=2 -> 4-6 it=3->7-8
            for (int i = 0; i < matrizA.GetLength(0); i++)
            {
                int inicio = (iteracion * nm) - nm;

                for (int j = 0; j < subMA.GetLength(1); j++)
                {
                    if(inicio < matrizA.GetLength(1))
                    {
                        subMA[i, j] = matrizA[i, inicio];
                    }
                   
                    inicio++;
                }
                
                
            }
            return subMA;
        }
        public static int[,] darSubMatrizB(int[,] matrizB, int iteracion, int nm)
        {
            
            int[,] subMB = new int[nm,matrizB.GetLength(0)];
            int inicio = (iteracion * nm) - nm;
            for (int i = 0; i < subMB.GetLength(0); i++)
            {
                
                for (int j = 0 ; j < matrizB.GetLength(1); j++)
                {
                    if (inicio < matrizB.GetLength(0))
                    {
                        subMB[i, j] = matrizB[inicio, j];
                    }
                    
                }
                inicio++;
            }
            return subMB;
        }
        public static int DarNumeroInvertido(string numero)
        {
            char[] myArr = numero.ToCharArray();
            Array.Reverse(myArr);
            int sum = 0;
            int posB = myArr.Length - 1;
            for (int i =0;i<myArr.Length;i++)
            {
                
                if (myArr[i] > '0')
                {
                    sum +=(int)(Math.Pow(2, posB));
                }
                posB--;
            }
            return sum;
        }
    }
}
