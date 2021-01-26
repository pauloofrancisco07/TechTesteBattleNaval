using System;
using System.Collections.Generic;
using System.Text;

namespace TechTeste_BatalhaNaval
{
    public class BatalhaNaval
    {
        public String[,] m_matrizTabuleiroDefesa = new String[11, 11];
        public String[,] m_matrizTabuleiroAtaque = new String[11, 11];
        public String[] m_PortaAviao = new String[5];
        public String[] m_Encouracado = new String[4];
        public String[] m_Submarino = new String[3];
        public String[] m_Destroyer = new String[3];
        public String[] m_Patrulha = new String[2];

        public List<String> m_ColunaPadrao = new List<String> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        public List<String> m_LinhaPadrao = new List<String> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        public BatalhaNaval()
        {
            m_matrizTabuleiroAtaque = preencheDefaultTabuleiro(m_matrizTabuleiroAtaque);
            m_matrizTabuleiroDefesa = preencheDefaultTabuleiro(m_matrizTabuleiroDefesa);
        }

        private String[,] preencheDefaultTabuleiro(String[,] p_matrizTabuleiro)
        {

            for (int j = 0; j <= 10; j++)
            {
                for (int i = 0; i <= 10; i++)
                {
                    if (i == 0 && j != 0)
                    {
                        p_matrizTabuleiro[j, i] = " " + m_ColunaPadrao[j - 1] + " ";
                    }
                    else if (i != 0 && j == 0)
                    {
                        p_matrizTabuleiro[j, i] = " " + m_LinhaPadrao[i - 1] + " ";
                    }
                    else if (i != 0 && j != 0)
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

        public Boolean adicionarNavio(String[] p_Posicoes, Int64 p_TipoNavio)
        {
            foreach (String v_Pos in p_Posicoes)
            {
                Char[] v_ArrayChar = v_Pos.ToCharArray();
                Int64 v_PosLinha = 0, v_PosColuna = 0;

                if (m_LinhaPadrao.Contains(v_ArrayChar[0].ToString()))
                {
                    v_PosColuna = Convert.ToInt64(v_ArrayChar[0].ToString());
                    v_PosLinha = m_ColunaPadrao.IndexOf(v_ArrayChar[1].ToString());
                    if (v_PosColuna > 0 && v_PosLinha > 0 && !m_matrizTabuleiroDefesa[v_PosLinha + 1, v_PosColuna].Equals(" @ "))
                    {
                        m_matrizTabuleiroDefesa[v_PosLinha + 1, v_PosColuna] = " @ ";

                    }
                    else
                    {
                        return false;
                    }
                }
                else if (m_LinhaPadrao.Contains(v_ArrayChar[1].ToString()))
                {
                    v_PosColuna = Convert.ToInt64(v_ArrayChar[1].ToString());
                    v_PosLinha = m_ColunaPadrao.IndexOf(v_ArrayChar[0].ToString());
                    if (v_PosColuna > 0 && v_PosLinha > 0 && !m_matrizTabuleiroDefesa[v_PosLinha + 1, v_PosColuna].Equals(" @ "))
                    {
                        m_matrizTabuleiroDefesa[v_PosLinha + 1, v_PosColuna] = " @ ";
                    }
                    else
                    {
                        return false;
                    }                        
                }
                else
                {
                    return false;
                }
            }
            guardarTipoNavio(p_Posicoes, p_TipoNavio);
            return true;
        }

        private void guardarTipoNavio(String[] v_Posicoes, Int64 p_TipoNavio)
        {
            switch(p_TipoNavio)
            {
                case 1:                    
                    m_PortaAviao = v_Posicoes;
                    break;
                case 2:
                    m_Encouracado = v_Posicoes;
                    break;
                case 3:
                    m_Destroyer = v_Posicoes;
                    break;
                case 4:
                    m_Submarino = v_Posicoes;
                    break;
                case 5:
                    m_Patrulha = v_Posicoes;
                    break;
            }
        }        
    }
}
