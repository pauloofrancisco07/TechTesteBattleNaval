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
                    Console.Write(v_Batalha.m_matrizTabuleiroDefesa[j, i] + " ");
                }
                Console.WriteLine(" ");
            }

            String[] v_PosicaoNavio = { "B1", "B2", "B3" };

            bool v_check = v_Batalha.adicionarNavio(v_PosicaoNavio, Convert.ToInt64(NaviosEnum.Navios.m_Submarino));

            String[] v_PosicaoNavio2 = { "C3", "C4", "C5", "C6" };

            v_check = v_Batalha.adicionarNavio(v_PosicaoNavio2, Convert.ToInt64(NaviosEnum.Navios.m_Encouracado));

            String[] v_PosicaoNavio3 = { "D3", "E3", "F3", "G3", "H3" };

            v_check = v_Batalha.adicionarNavio(v_PosicaoNavio3, Convert.ToInt64(NaviosEnum.Navios.m_PortaAviao));

            for (int j = 0; j <= 10; j++)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Console.Write(v_Batalha.m_matrizTabuleiroDefesa[j, i] + " ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
