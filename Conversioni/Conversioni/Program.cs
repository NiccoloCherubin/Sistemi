using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversioneInBaseDieci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] bools = { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }; //1000 = 8            
            int[] decimalePuntato = { 128, 0, 0, 0 };
            //Console.WriteLine(Convert_Binario_To_Decimale(bools));
            Console.WriteLine(Convert_Decimale_Puntato_To_Decimale(decimalePuntato));
            //int[] interi = Convert_Numero_Decimale_To_Decimale_Puntato(4294967295);
            //foreach (int n in interi)
            //{
            //    Console.WriteLine(n);
            //}
            int[] interi = Convert_Binario_To_Decimale_Puntato(bools);
            foreach (int n in interi)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        }
        static int Convert_Binario_To_Decimale(bool[] b)
        {
            int convertito = 0;
            int potenza = 0;
            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (b[i])
                {
                    convertito += (int)Math.Pow(2, potenza);
                }
                potenza++;
            }
            return convertito;
        }
        static uint Convert_Decimale_Puntato_To_Decimale(int[] dp)
        {
            uint convertito = 0;
            int potenza = 0;
            for (int i = dp.Length - 1; i >= 0; i--)
            {
                convertito += (uint)dp[i] * (uint)Math.Pow(256, potenza);
                potenza++;
            }
            return convertito;
        }
        static int[] Convert_Binario_To_Decimale_Puntato(bool[] bools)
        {
            int[] decimalePuntato = new int[4];
            int numero;
            for (int i = decimalePuntato.Length - 1; i >= 0; i--)
            {
                numero = 0;
                for (int j = 0; j < 8; j++) // 8 = bit in un byte
                {
                    if (bools[j + 8 * i])
                    {
                        numero += (int)Math.Pow(2, 7 - j); // da binario ad intero
                    }
                }
                decimalePuntato[i] = numero;
            }
            return decimalePuntato;
        }
        static bool[] Convert_Decimale_Puntato_To_Binario(int[] decimalePuntato)
        {
            bool[] bools = new bool[decimalePuntato.Length * 8]; // calcola i byte
            int numero;
            for (int i = 0; i < decimalePuntato.Length; i++)
            {
                numero = decimalePuntato[i];
                for (int j = 7; j >= 0; j--) // converto ogni byte
                {
                    if (numero % 2 == 1)
                    {
                        bools[j + i * 8] = true; 
                    }
                    numero /= 2;
                    if(numero < 0) // significa che la conversione è finita
                    {
                        break;
                    }
                }
            }
            return bools;
        }
        static int[] Convert_Numero_Decimale_To_Decimale_Puntato(uint numero)
        {
            int[] numeroPuntato = new int[4];
            for (int i = numeroPuntato.Length - 1; i >= 0; i--)
            {
                numeroPuntato[i] = (int)(numero % 256);
                numero /= 256;
                if (numero < 0) // se numero divento < 0 significa che la conversione è finita
                {
                    break;
                }
            }
            return numeroPuntato;
        }
        static bool[] Convert_Numero_Decimale_To_Binario(uint numero)
        {
            bool[] bools = new bool[32];
            for (int i = bools.Length - 1; i >= 0; i--)
            {
                if (numero % 2 == 1)
                {
                    bools[i] = true;
                }
                numero /= 2;
                if(numero < 0)
                {
                    break;
                }
            }
            return bools;
        }
    }
}
