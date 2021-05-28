using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller3_Discretas.Logica
{
    class ServicioStrassen
    {
        
        private int[,] matrizC;
        
        public ServicioStrassen()
        {
            
        }

        public void multiplicarStrassen(int[,] matrizA, int[,] matrizB)
        {
            
            int[,] a = matrizA;
            int[,] b = matrizB;
            matrizC = new int[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i = i + 2)
            {
                for (int j = 0; j < a.GetLength(0); j = j + 2)
                {
                    for (int k = 0; k < a.GetLength(0); k = k + 2)
                    {
                        //aqui se saca r s t u
                        // 0,0

                        int a0 = a[i, k];
                        int b0 = a[i, k + 1];
                        int c0 = a[i + 1, k];
                        int d0 = a[i + 1, k + 1];
                        int e0 = b[k, j];
                        int f0 = b[k, j + 1];
                        int g0 = b[k + 1, j];
                        int h0 = b[k + 1, j + 1];
                        //=======================================
                        int p1 = a0*(f0 - h0);
                        int p2 = (a0 + b0) * h0;
                        int p3 = (c0 + d0) * e0;
                        int p4 = d0 * (g0 - e0);
                        int p5 = (a0 + d0) * (e0 + h0);
                        int p6 = (b0 - d0) * (g0 + h0);
                        int p7 = (a0 - c0) * (e0 + f0);
                        //=======================================
                        matrizC[i, j] += p5 + p6 + p4 - p2;

                        //0,1
                        matrizC[i, j + 1] += p1 + p2;

                        // 1,0
                        matrizC[i + 1, j] += p3 + p4;

                        //1,1
                        matrizC[i + 1, j + 1] += p1 - p7 - p3 + p5;

                    }
                }
            }
            
            
        }
        public int[,] getResultado()
        {
            for(int i = 0; i < matrizC.GetLength(0); i++)
            {
                for (int j = 0; j < matrizC.GetLength(0); j++)
                {
                    if (matrizC[i, j] > 0)
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
        
    }
}
