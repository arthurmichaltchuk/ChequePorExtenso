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
            string tempValor = ArrumarFormato(valornumero);
            string NumSemPontosEVirgulas = TirarPontosVirgulas(tempValor);          
            
            numeros = NumSemPontosEVirgulas.ToCharArray();

            string temp = "";
            string temp2 = "";
            double[] tempNum = new double[20];


            for (int j = 0; j < numeros.Length-2; j += 3)
            {
                for (int i = j; i < j+3; i++)
                {
                    try
                    {
                        temp = Convert.ToString(numeros[i]);
                        tempNum[i] = Convert.ToDouble(temp);
                    }
                    catch
                    {
                        tempNum[i] = 0;
                    }
                }
                VerificarNumeros(tempNum[j], tempNum[j+1], tempNum[j+2]);
                VerificarNomenclarturaDoValor(j);
            }
            if (totalNumeros() != 0)
            {
                if (totalNumeros() == 1 && numeros[11] == '1')
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
            temp = Convert.ToString(numeros[12]);
            temp2 = Convert.ToString(numeros[13]);

            VerificarNumeros(0 , Convert.ToDouble(temp) , Convert.ToDouble(temp2));

            if (verificarCentavoNulo())
            {
                if (numeros[13] == '1' && numeros[12] == '0')
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
            return PrimeiraLetraMaiuscula();
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
            if (j == 0 && VerificarBilhoes() != 0)
            {
                if (numeros[0] == '0' && numeros[1] == '0' && numeros[2] == '1')
                    resultado += " bilhão ";
                else
                    resultado += " bilhões ";
            }
            else if (j == 3 && VerificarMilhoes() != 0)
            {
                if (numeros[3] == '0' && numeros[4] == '0' && numeros[5] == '1')
                    resultado += " milhão ";
                else
                    resultado += " milhões ";
            }
            else if (j == 6 && VerificarMil() != 0)
            {
                resultado += " mil ";
            }          
        }

        private int VerificarBilhoes()
        {
            int cont = 0; 
            for (int i = 0; i < 3; i++)
            {
                if (numeros[i] != '0')
                    cont++;              
            }
            return cont;
        }

        private int VerificarMilhoes()
        {
            int cont = 0;
            for (int i = 3; i < 6; i++)
            {
                if (numeros[i] != '0')
                    cont++;
            }
            return cont;
        }
        private int VerificarMil()
        {
            int cont = 0;
            for (int i = 6; i < 9; i++)
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

            return strValor;
        }

        private void VerificarNumeros(double numA, double numB, double numC)
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

            if (numB != 1 & numC != 0 & resultado != string.Empty) resultado += " e ";

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
