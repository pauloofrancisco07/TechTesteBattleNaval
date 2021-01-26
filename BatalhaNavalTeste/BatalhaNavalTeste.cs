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

            Assert.IsTrue(v_BatalhaNaval.adicionarNavio(v_PosicaoNavio, Convert.ToInt64(NaviosEnum.Navios.m_Encouracado)));



        }

    }
}