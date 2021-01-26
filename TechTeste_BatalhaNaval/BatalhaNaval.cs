using System;
using System.Collections.Generic;
using System.Text;

namespace TechTeste_BatalhaNaval
{
    public class BatalhaNaval
    {
        public String[,] m_matrizTabuleiroDefesa = new String[11, 11];
        public String[,] m_matrizTabuleiroAtaque = new String[11, 11];
        public List<String> m_PortaAviao = new List<String>();
        public List<String> m_Encouracado = new List<String>();
        public List<String> m_Submarino = new List<String>();
        public List<String> m_Destroyer = new List<String>();
        public List<String> m_Patrulha = new List<String>();
        public List<String> m_Movimentos = new List<String>();

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
            List<String> v_PosicoesNavios = new List<String>(); // Transforma B4 passado na função por 4;4 que ai vai ser mais facil para pegar depois para salvar nas posicoes dos navios
            foreach (String v_Pos in p_Posicoes)
            {
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
                        v_PosicoesNavios.Add(v_ListPosicoesNavios[0] + ";" + v_ListPosicoesNavios[1]);
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
                        v_PosicoesNavios.Add(v_ListPosicoesNavios[0] + ";" + v_ListPosicoesNavios[1]);
                    }

                }
                else
                {
                    return false;
                }
            }
            guardarTipoNavio(v_PosicoesNavios, p_TipoNavio);
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

            m_Movimentos.Add(m_Movimentos == null ? v_Posicao : ", "+ v_Posicao);

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
                removerPosicaoNavioAcertado(m_matrizTabuleiroDefesa[v_ListCordenadas[0], v_ListCordenadas[1]], v_ListCordenadas[0], v_ListCordenadas[1]);
                m_matrizTabuleiroAtaque[v_ListCordenadas[0], v_ListCordenadas[1]] = " @ ";
                return true;
            }
            else
            {
                m_matrizTabuleiroAtaque[v_ListCordenadas[0], v_ListCordenadas[1]] = " X ";
                return false;
            }
        }

        private void guardarTipoNavio(List<String> v_Posicoes, Int64 p_TipoNavio)
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

        private void removerPosicaoNavioAcertado(String p_TipoNavio, Int64 p_Linha, Int64 p_Coluna  )
        {
            switch (Convert.ToInt32(p_TipoNavio))
            {
                case 1:
                    m_PortaAviao.Remove(m_PortaAviao[m_PortaAviao.IndexOf(p_Linha + ";"+ p_Coluna)]);
                    break;
                case 2:
                    m_Encouracado.Remove(m_Encouracado[m_Encouracado.IndexOf(p_Linha + ";" + p_Coluna)]);
                    break;
                case 3:
                    m_Destroyer.Remove(m_Destroyer[m_Destroyer.IndexOf(p_Linha + ";" + p_Coluna)]);
                    break;
                case 4:
                    m_Submarino.Remove(m_Submarino[m_Submarino.IndexOf(p_Linha + ";" + p_Coluna)]);
                    break;
                case 5:
                    m_Patrulha.Remove(m_Patrulha[m_Patrulha.IndexOf(p_Linha + ";" + p_Coluna)]);
                    break;
            }
        }
        public Boolean verificaGanhador()
        {
            if(m_Encouracado == null && m_Destroyer==null && m_PortaAviao == null && m_Patrulha == null && m_Submarino == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
