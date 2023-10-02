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
            bool[] bools = { true, false, false, false }; //1000 = 8            
            int[] decimalePuntato = { 10, 10, 10, 10 }; //168430090
            Console.WriteLine(Convert_Binario_To_Decimale(bools));
            Console.WriteLine(Convert_Decimale_Puntato_To_Decimale(decimalePuntato));
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
        static int Convert_Decimale_Puntato_To_Decimale(int[] dp)
        {
            int convertito = 0;
            int potenza = 0;
            for (int i = dp.Length - 1; i >= 0; i--)
            {
                convertito += dp[i] * (int)Math.Pow(256, potenza);
                potenza++;
            }
            return convertito;
        }
    }
}
