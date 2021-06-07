using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequePorExtenso.ConsoleApp
{
    public class Numero : Cheque
    {
        public string valor;
        public string resultado = "";

        public string escreverPorExtenso()
        {
            string valornumero = valor;
            string ValorFormatoCorreto = ArrumarFormato(valornumero);

            numeros = ValorFormatoCorreto.ToCharArray();

            double[] tempNum = new double[20];
            string AuxConversao = "";
            for (int j = 0; j < numeros.Length - 2; j += 3)
            {
                for (int i = j; i < j + 3; i++)
                {
                    AuxConversao = Convert.ToString(numeros[i]);
                    tempNum[i] = Convert.ToDouble(AuxConversao);
                }
                VerificarNumeros(tempNum[j], tempNum[j + 1], tempNum[j + 2], 0);
                VerificarNomenclarturaDoValor(j);
            }
            if (totalNumeros() != 0)
                nomenclaturaFinalReais();

            fazerNomenclaturaCentavos();

            return PrimeiraLetraMaiuscula();
        }

        private void fazerNomenclaturaCentavos()
        {
            string centavoDezena = Convert.ToString(numeros[12]);
            string centavoUnidade = Convert.ToString(numeros[13]);

            VerificarNumeros(0, Convert.ToDouble(centavoDezena), Convert.ToDouble(centavoUnidade), 1);
            nomenclaturaFinalCentavos();
        }
        private void nomenclaturaFinalCentavos()
        {
            if (verificarCentavoNulo())
            {
                Boolean SeExisteSoUmCentavo = numeros[13] == '1' && numeros[12] == '0';

                if (SeExisteSoUmCentavo)
                    if (totalNumeros() != 0)
                        resultado += " centavo";
                    else
                        resultado += " centavo de real";
                else
                    if (totalNumeros() != 0)
                    resultado += " centavos";
                else
                    resultado += " centavos de real";
            }
        }

        private void nomenclaturaFinalReais()
        {
            if (totalNumerosPosMilhao() == 0 && totalNumerosPreMilhao() != 0)
                if (verificarCentavoNulo())
                    resultado += "de reais e ";
                else
                    resultado += "de reais";
            else if (totalNumeros() == 1 && numeros[11] == '1')
                if (verificarCentavoNulo())
                    resultado += " real e ";
                else
                    resultado += " real";
            else
                if (verificarCentavoNulo())
                    resultado += " reais e ";
                else
                    resultado += " reais";
        }

        private string PrimeiraLetraMaiuscula()
        {
            string ValorPorExtenso = char.ToUpper(resultado[0]) + resultado.Substring(1);
            return ValorPorExtenso;
        }

        private bool verificarCentavoNulo()
        {
            if (numeros[12] != '0' || numeros[13] != '0')            
                return true;
            else
                return false;
        }

        private void VerificarNomenclarturaDoValor(int j)
        {
            if (j == 0 && VerificarNumeros(0) != 0)
            {
                if (numeros[0] == '0' && numeros[1] == '0' && numeros[2] == '1')
                    resultado += " bilhão ";
                else
                    resultado += " bilhões ";
            }
            else if (j == 3 && VerificarNumeros(3) != 0)
            {
                if (numeros[3] == '0' && numeros[4] == '0' && numeros[5] == '1')
                    resultado += " milhão ";
                else
                    resultado += " milhões ";
            }
            else if (j == 6 && VerificarNumeros(6) != 0)
                resultado += " mil ";
        }

        private int VerificarNumeros(int tamanho)
        {
            int cont = 0;
            for (int i = 0 + tamanho; i < 3 + tamanho; i++)
            {
                if (numeros[i] != '0')
                    cont++;
            }
            return cont;
        }

        private int totalNumerosPreMilhao()
        {
            int cont = 0;
            for (int i = 0; i < 6; i++)
            {
                if (numeros[i] != '0')
                    cont++;
            }
            return cont;
        }


        private int totalNumerosPosMilhao()
        {
            int cont = 0;
            for (int i = 6; i < 12; i++)
            {
                if (numeros[i] != '0')
                    cont++;
            }
            return cont;
        }

        private int totalNumeros()
        {
            int cont = 0;
            for (int i = 0; i < 12; i++)
            {
                if (numeros[i] != '0')
                    cont++;        
            }
            return cont;
        }

        private string TirarPontosVirgulas(string numero)
        {
            string temp = numero.Replace(".", "");
            string temp2 = temp.Replace(",", "");
            return temp2;
        }

        private string ArrumarFormato(string valorstring)
        {
            double valorTemp = Convert.ToDouble(valorstring);
            string strValor = valorTemp.ToString("000000000000.00");
            return TirarPontosVirgulas(strValor);
        }

        private void VerificarNumeros(double numA, double numB, double numC, int ehCentavo)
        {
            if (numA != 0 && numB == 0 && numC == 0) resultado += "e ";
            if (numA == 1) resultado += (numA + numA == 0) ? "cem" : "cento";                   
            else if (numA == 2) resultado += "duzentros";
            else if (numA == 3) resultado += "trezentos";
            else if (numA == 4) resultado += "quatrocentos";
            else if (numA == 5) resultado += "quinhentos";
            else if (numA == 6) resultado += "seiscentos";
            else if (numA == 7) resultado += "setecentos";
            else if (numA == 8) resultado += "oitocentos";
            else if (numA == 9) resultado += "novecentos";

            if (numB == 1)
            {
                if (numC == 0) resultado += ((numA > 0) ? " e " : string.Empty) + "dez";
                else if (numC == 1) resultado += ((numA > 0) ? " e " : string.Empty) + "onze";
                else if (numC == 2) resultado += ((numA > 0) ? " e " : string.Empty) + "doze";
                else if (numC == 3) resultado += ((numA > 0) ? " e " : string.Empty) + "treze";
                else if (numC == 4) resultado += ((numA > 0) ? " e " : string.Empty) + "quatorze";
                else if (numC == 5) resultado += ((numA > 0) ? " e " : string.Empty) + "quinze";
                else if (numC == 6) resultado += ((numA > 0) ? " e " : string.Empty) + "dezesseis";
                else if (numC == 7) resultado += ((numA > 0) ? " e " : string.Empty) + "dezessete";
                else if (numC == 8) resultado += ((numA > 0) ? " e " : string.Empty) + "dezoito";
                else if (numC == 9) resultado += ((numA > 0) ? " e " : string.Empty) + "dezenove";
            }
            else if (numB == 2) resultado += ((numA > 0) ? " e " : string.Empty) + "vinte";
            else if (numB == 3) resultado += ((numA > 0) ? " e " : string.Empty) + "trinta";
            else if (numB == 4) resultado += ((numA > 0) ? " e " : string.Empty) + "quarente";
            else if (numB == 5) resultado += ((numA > 0) ? " e " : string.Empty) + "cinquenta";
            else if (numB == 6) resultado += ((numA > 0) ? " e " : string.Empty) + "sessenta";
            else if (numB == 7) resultado += ((numA > 0) ? " e " : string.Empty) + "setenta";
            else if (numB == 8) resultado += ((numA > 0) ? " e " : string.Empty) + "oitenta";
            else if (numB == 9) resultado += ((numA > 0) ? " e " : string.Empty) + "noventa";

            if (ehCentavo == 0)     
                if (numB != 1 & numC != 0 & resultado != string.Empty) resultado += " e ";

            if (ehCentavo == 1 && numB != 0)
                if (numB != 1 & numC != 0) resultado += " e ";

            if (numB != 1)
                if (numC == 1) resultado += "um";
                else if (numC == 2) resultado += "dois";
                else if (numC == 3) resultado += "três";
                else if (numC == 4) resultado += "quatro";
                else if (numC == 5) resultado += "cinco";
                else if (numC == 6) resultado += "seis";
                else if (numC == 7) resultado += "sete";
                else if (numC == 8) resultado += "oito";
                else if (numC == 9) resultado += "nove";
        }
    }
}