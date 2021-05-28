using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller3_Discretas.Logica
{
    class ServicioParticion
    {
        
        private static int[,] matrizC;
        
        public ServicioParticion()
        {
            
        }
        public void multiplicarParticion(int[,] matrizA, int[,] matrizB)
            {
            
            int[,] a = matrizA;
            int[,] b = matrizB;
            matrizC = new int[a.GetLength(1), a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i = i + 2)
            {
                for(int j = 0; j < a.GetLength(0); j = j + 2)
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
                        int f0= b[k, j + 1];
                        int g0= b[k + 1, j];
                        int h0= b[k + 1, j + 1];
                        matrizC[i, j] += ((a0 * e0) + (b0 * g0));

                        //0,1
                        matrizC[i, j + 1] += ((a0 * f0) + (b0 * h0));

                        // 1,0
                        matrizC[i + 1, j] += ((c0 * e0) + (d0 * g0));

                        //1,1
                        matrizC[i + 1, j + 1] += ((c0 * f0) + (d0 * h0));


                    }
                }
            }
            
            
        }
        public int[,] getResultado()
        {
            for (int i = 0; i < matrizC.GetLength(0); i++)
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
