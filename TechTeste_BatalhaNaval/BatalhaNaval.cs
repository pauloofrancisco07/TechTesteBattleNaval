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
        public List<String> m_Movimentos;

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
            String[] v_PosicoesNavios = new String[p_Posicoes.Length]; // Transforma B4 passado na função por 4;4 que ai vai ser mais facil para pegar depois para salvar nas posicoes dos navios
            foreach (String v_Pos in p_Posicoes)
            {
                Int64 Contador = 0;
                Char[] v_ArrayChar = v_Pos.ToCharArray();
                List<Int64> v_ListPosicoesNavios;

                if (m_LinhaPadrao.Contains(v_ArrayChar[0].ToString()))
                {
                    v_ListPosicoesNavios = getNavioPosicao(v_ArrayChar, 0, 1);
                    if (v_ListPosicoesNavios == null)
                    {
                        return false;
                    }
                    if (m_matrizTabuleiroDefesa[v_ListPosicoesNavios[0], v_ListPosicoesNavios[1]] == " - ")
                    {
                        m_matrizTabuleiroDefesa[v_ListPosicoesNavios[0], v_ListPosicoesNavios[1]] = " " + p_TipoNavio.ToString() + " ";
                        v_PosicoesNavios[Contador] = v_ListPosicoesNavios[0] + ";" + v_ListPosicoesNavios[1];
                    }
                }
                else if (m_LinhaPadrao.Contains(v_ArrayChar[1].ToString()))
                {
                    v_ListPosicoesNavios = getNavioPosicao(v_ArrayChar, 1, 0);
                    if (v_ListPosicoesNavios == null)
                    {
                        return false;
                    }
                    if (m_matrizTabuleiroDefesa[v_ListPosicoesNavios[0], v_ListPosicoesNavios[1]] == " - ")
                    {
                        m_matrizTabuleiroDefesa[v_ListPosicoesNavios[0], v_ListPosicoesNavios[1]] = " " + p_TipoNavio.ToString() + " ";
                        v_PosicoesNavios[Contador] = v_ListPosicoesNavios[0] + ";" + v_ListPosicoesNavios[1];
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

        private List<Int64> getNavioPosicao(Char[] p_ArrayChar, int p_PosColuna, int p_PosLinha)
        {

            if (Convert.ToInt64(p_ArrayChar[p_PosColuna].ToString()) > 0 && m_ColunaPadrao.IndexOf(p_ArrayChar[p_PosLinha].ToString()) + 1 > 0)
            {
                List<Int64> v_ListPosicoes = new List<Int64>();
                v_ListPosicoes.Add(m_ColunaPadrao.IndexOf(p_ArrayChar[p_PosLinha].ToString()) + 1);
                v_ListPosicoes.Add(Convert.ToInt64(p_ArrayChar[p_PosColuna].ToString()));
                return v_ListPosicoes;
            }
            else
            {
                return null;
            }
        }

        public Boolean fazerAtaque(String v_Posicao)// IF e else para tratar caso o usuario passe B4 ou 4B
        {
            Char[] v_ArrayChar = v_Posicao.ToCharArray();
            List<Int64> v_ListPosicoesNavios;

            if (m_LinhaPadrao.Contains(v_ArrayChar[0].ToString()))
            {
                v_ListPosicoesNavios = getNavioPosicao(v_ArrayChar, 0, 1);

                if (v_ListPosicoesNavios != null && attackCerto(v_ListPosicoesNavios))
                {
                    return true;
                }

            }
            else if (m_LinhaPadrao.Contains(v_ArrayChar[1].ToString()))
            {
                v_ListPosicoesNavios = getNavioPosicao(v_ArrayChar, 1, 0);

                if (v_ListPosicoesNavios != null && attackCerto(v_ListPosicoesNavios))
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public Boolean attackCerto(List<Int64> v_ListCordenadas)
        {
            if (m_matrizTabuleiroDefesa[v_ListCordenadas[0], v_ListCordenadas[1]] != " - ")
            {
                m_matrizTabuleiroAtaque[v_ListCordenadas[0], v_ListCordenadas[1]] = " @ ";
                return true;
            }
            else
            {
                m_matrizTabuleiroAtaque[v_ListCordenadas[0], v_ListCordenadas[1]] = " X ";
                return false;
            }
        }

        private void guardarTipoNavio(String[] v_Posicoes, Int64 p_TipoNavio)
        {
            switch (p_TipoNavio)
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
