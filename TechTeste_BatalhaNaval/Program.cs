using System;

namespace TechTeste_BatalhaNaval
{
    class Program
    {
        static void Main(string[] args)
        {
            BatalhaNaval v_Batalha = new BatalhaNaval();

            for (int j = 0; j <= 10; j++)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Console.Write(v_Batalha.m_matrizTabuleiro[j, i] + " ");
                }
                Console.WriteLine(" ");
            }

        }
    }
}
