using System;
using System.Collections.Generic;
using System.Text;

namespace TechTeste_BatalhaNaval
{
    public class BatalhaNaval
    {
        public String[,] m_matrizTabuleiro = new String[11, 11];

        public BatalhaNaval()
        {
            m_matrizTabuleiro = preencheDefaultTabuleiro(m_matrizTabuleiro);
        }



        private String[,] preencheDefaultTabuleiro(String[,] p_matrizTabuleiro)
        {
            String[] v_ColunaPadrao = { " A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J " };
            String[] v_LinhaPadrao = { " 1 ", " 2 ", " 3 ", " 4 ", " 5 ", " 6 ", " 7 ", " 8 ", " 9 ", " 10 " };

            for (int j = 0; j<=10; j++)
            {              
                for (int i = 0; i <= 10; i++)
                {
                    if (i == 0 && j != 0)
                    {
                        p_matrizTabuleiro[j, i] = v_ColunaPadrao[j-1];
                    }
                    else if(i != 0 && j == 0)
                    {
                        p_matrizTabuleiro[j, i] = v_LinhaPadrao[i-1];
                    }
                    else if(i != 0 && j != 0)
                    {
                        p_matrizTabuleiro[j, i] = " - ";
                    }
                    else
                    {
                        p_matrizTabuleiro[j, i] = "   ";
                    }
                }
            }

            return p_matrizTabuleiro;
        }

    }
}
