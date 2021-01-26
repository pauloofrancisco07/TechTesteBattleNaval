using System;
using NUnit.Framework;
using TechTeste_BatalhaNaval;

namespace BatalhaNavalTeste
{
    public class BatalhaNavalTeste
    {

        [Test]
        public void ConstruindoTabuleiro()
        {
            // Construindo um tabuleiro
            BatalhaNaval v_BatalhaNaval = new BatalhaNaval();
        }

        [Test]
        public void adicionandoNavios()
        {
            // Construindo um tabuleiro
            BatalhaNaval v_BatalhaNaval = new BatalhaNaval();

            String[] v_PosicaoNavio = { "B1", "B2", "B3" };

            Assert.IsTrue(v_BatalhaNaval.adicionarNavio(v_PosicaoNavio, Convert.ToInt64(NaviosEnum.Navios.m_Submarino)));

            String[] v_PosicaoNavio2 = { "C3", "C4", "C5", "C6" };

            Assert.IsTrue(v_BatalhaNaval.adicionarNavio(v_PosicaoNavio2, Convert.ToInt64(NaviosEnum.Navios.m_Encouracado)));

            String[] v_PosicaoNavio3 = { "D9", "E9", "F9", "G9", "H9" };

            Assert.IsTrue(v_BatalhaNaval.adicionarNavio(v_PosicaoNavio3, Convert.ToInt64(NaviosEnum.Navios.m_PortaAviao)));

            String[] v_PosicaoNavio4 = { "A1", "A2" };

            Assert.IsTrue(v_BatalhaNaval.adicionarNavio(v_PosicaoNavio4, Convert.ToInt64(NaviosEnum.Navios.m_Patrulha)));

            String[] v_PosicaoNavio5 = { "J3", "J4", "J5" };

            Assert.IsTrue(v_BatalhaNaval.adicionarNavio(v_PosicaoNavio5, Convert.ToInt64(NaviosEnum.Navios.m_Destroyer)));


        }

        [Test]
        public void fazendoAtaques()
        {
            // Construindo um tabuleiro
            BatalhaNaval v_BatalhaNaval = new BatalhaNaval();

            String[] v_PosicaoNavio = { "B1", "B2", "B3" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio, Convert.ToInt64(NaviosEnum.Navios.m_Submarino));

            String[] v_PosicaoNavio2 = { "C3", "C4", "C5", "C6" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio2, Convert.ToInt64(NaviosEnum.Navios.m_Encouracado));

            String[] v_PosicaoNavio3 = { "D9", "E9", "F9", "G9", "H9" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio3, Convert.ToInt64(NaviosEnum.Navios.m_PortaAviao));

            String[] v_PosicaoNavio4 = { "A1", "A2" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio4, Convert.ToInt64(NaviosEnum.Navios.m_Patrulha));

            String[] v_PosicaoNavio5 = { "J3", "J4", "J5" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio5, Convert.ToInt64(NaviosEnum.Navios.m_Destroyer));

            Assert.IsTrue(v_BatalhaNaval.fazerAtaque("A2"));

        }

        [Test]
        public void verificaGanhador()
        {
            // Construindo um tabuleiro
            BatalhaNaval v_BatalhaNaval = new BatalhaNaval();

            String[] v_PosicaoNavio = { "B1", "B2", "B3" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio, Convert.ToInt64(NaviosEnum.Navios.m_Submarino));

            String[] v_PosicaoNavio2 = { "C3", "C4", "C5", "C6" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio2, Convert.ToInt64(NaviosEnum.Navios.m_Encouracado));

            String[] v_PosicaoNavio3 = { "D9", "E9", "F9", "G9", "H9" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio3, Convert.ToInt64(NaviosEnum.Navios.m_PortaAviao));

            String[] v_PosicaoNavio4 = { "A1", "A2" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio4, Convert.ToInt64(NaviosEnum.Navios.m_Patrulha));

            String[] v_PosicaoNavio5 = { "J3", "J4", "J5" };

            v_BatalhaNaval.adicionarNavio(v_PosicaoNavio5, Convert.ToInt64(NaviosEnum.Navios.m_Destroyer));

            v_BatalhaNaval.fazerAtaque("C3");
            v_BatalhaNaval.fazerAtaque("B1");
            v_BatalhaNaval.fazerAtaque("B2");
            v_BatalhaNaval.fazerAtaque("B3");
            v_BatalhaNaval.fazerAtaque("C4");
            v_BatalhaNaval.fazerAtaque("C5");
            v_BatalhaNaval.fazerAtaque("C6");
            v_BatalhaNaval.fazerAtaque("D9");
            v_BatalhaNaval.fazerAtaque("E9");
            v_BatalhaNaval.fazerAtaque("F9");
            v_BatalhaNaval.fazerAtaque("G9");
            v_BatalhaNaval.fazerAtaque("H9");
            v_BatalhaNaval.fazerAtaque("A1");
            v_BatalhaNaval.fazerAtaque("A2");
            v_BatalhaNaval.fazerAtaque("J3");
            v_BatalhaNaval.fazerAtaque("J4");
            v_BatalhaNaval.fazerAtaque("J5");

            Assert.IsTrue(v_BatalhaNaval.adicionarNavio(v_PosicaoNavio5, Convert.ToInt64(NaviosEnum.Navios.m_Destroyer)));



        }

    }
}