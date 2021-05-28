using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller3_Discretas.Logica
{
    class ServicioMultiplicar
    {

        
        private static int[,] matrizC;
        
        public ServicioMultiplicar()
        {
            
        }
        
        public  void multiplicarTradicional(int[,] matrizA, int[,] matrizB)
        {
            
            matrizC = new int[matrizA.GetLength(0), matrizB.GetLength(1)];
            for (int i = 0; i < matrizC.GetLength(0); i++)
            {
                for (int j = 0; j < matrizC.GetLength(1); j++)
                {
                    int suma = 0;
                    for (int k = 0; k < matrizA.GetLength(1); k++)
                    {
                        suma += matrizA[i, k] * matrizB[k, j];
                        if (suma > 0)
                        {
                            matrizC[i, j] = 1;
                        }
                        else
                        {
                            matrizC[i, j] = 0;
                        }
                        
                    }
                }
            }

        }
        public int[,] getResultado()
        {
            return matrizC;
        }
    }
}
