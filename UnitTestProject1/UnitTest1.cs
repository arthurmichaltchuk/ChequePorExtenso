using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChequePorExtenso.ConsoleApp;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeveRetonarCincoCentavos()
        {
            Numero numero = new Numero();
            numero.valor = "0,05";

            Assert.AreEqual("Cinco centavos de real", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarDoisReaisVinteCincoCentavos()
        {
            Numero numero = new Numero();
            numero.valor = "2,25";

            Assert.AreEqual("Dois reais e vinte e cinco centavos", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "7,00";

            Assert.AreEqual("Sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "37,00";

            Assert.AreEqual("Trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "637,00";

            Assert.AreEqual("Seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarUmMilSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "1.637,00";

            Assert.AreEqual("Um mil seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarQuinzeMilQuatrocentosQuinzeReaisDezesseisCentavos()
        {
            Numero numero = new Numero();
            numero.valor = "15.415,16";

            Assert.AreEqual("Quinze mil quatrocentos e quinze reais e dezesseis centavos", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarSessentaUmMilSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "61.637,00";

            Assert.AreEqual("Sessenta e um mil seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarNovecentosSessentaUmMilSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "961.637,00";

            Assert.AreEqual("Novecentos e sessenta e um mil seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarUmMilhãoOitocentosCinquentaDoisMilSetecentosReais()
        {
            Numero numero = new Numero();
            numero.valor = "1.852.700,00";

            Assert.AreEqual("Um milhão oitocentos e cinquenta e dois mil e setecentos reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarCincoMilhõesNovecentosSessentaUmMilSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "5.961.637,00";

            Assert.AreEqual("Cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarVinteCincoMilhõesNovecentosSessentaUmMilSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "25.961.637,00";

            Assert.AreEqual("Vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarQuatrocentosVinteCincoMilhõesNovecentosSessentaUmMilSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "425.961.637,00";

            Assert.AreEqual("Quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }

        [TestMethod]
        public void DeveRetonarOitoBilhõesQuatrocentosVinteCincoMilhõesNovecentosSessentaUmMilSeiscentosTrintaSeteReais()
        {
            Numero numero = new Numero();
            numero.valor = "8.425.961.637,00";

            Assert.AreEqual("Oito bilhões quatrocentos e vinte e cinco milhões novecentos e sessenta e um mil seiscentos e trinta e sete reais", numero.escreverPorExtenso());
        }
    }
}
