using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }       
        public string BinarioDecimal(string binario)
        {
            double binConvertido = 0;
            int i = 0;
            int lengthBin = binario.Length - 1;
            StringBuilder strtBin = new StringBuilder();

            if (binario.Length > 0) 
            {
                if (binario.Trim().Contains('.'))
                {
                    strtBin.Append(binario.Trim().Split('.')[0]);
                }

                if (EsBinario(strtBin.ToString()))
                {
                    while (i <= lengthBin)
                    {
                        if (binario[lengthBin - i] == '1')
                        {
                            binConvertido += Math.Pow(2, i);
                        }
                        i++;
                    }
                    return binConvertido.ToString();
                }
                else
                {
                    return "Valor Invalido";
                }
            }
            else
            {
                return "Valor Invalido";
            }
        }

        public string DecimalBinario(string numero)
        {
            if (numero.Length > 0) 
            {
                StringBuilder strNum = new StringBuilder();

                if (numero.Trim().Contains('.'))
                {
                    strNum.Append(numero.Trim().Split('.')[0]);
                }
                else
                {
                    strNum.Append(numero);
                }

                double numParse = Double.Parse(strNum.ToString());

                if (Double.IsNormal(numParse))
                {
                    StringBuilder strNumToBin = new StringBuilder();

                    while ((int)numParse / 2 != 1)
                    {
                        if ((int)numParse % 2 == 0)
                        {
                            strNumToBin.Insert(0, '0');
                        }

                        if ((int)numParse % 2 == 1)
                        {
                            strNumToBin.Insert(0, '1');
                        }
                        numParse = Math.Floor(numParse / 2);
                    }

                    if (numParse / 2 == 1)
                    {
                        strNumToBin.Insert(0, '0');
                        strNumToBin.Insert(0, '1');
                    }

                    return strNumToBin.ToString();
                }
                else
                {
                    return "Valor Invalido";
                }
            }
            else
            {
                return "Valor Invalido";
            }

        }

        public string DecimalBinario(double numero)
        {
            if (numero > 0) 
            {
                double absNumero = Math.Truncate(numero);
                if (Double.IsNormal(absNumero))
                {
                    StringBuilder strNumToBin = new StringBuilder();

                    while ((int)absNumero / 2 != 1)
                    {
                        if ((int)absNumero % 2 == 0)
                        {
                            strNumToBin.Insert(0, '0');
                        }

                        if ((int)absNumero % 2 == 1)
                        {
                            strNumToBin.Insert(0, '1');
                        }
                        absNumero = Math.Floor(absNumero / 2);
                    }

                    if (absNumero / 2 == 1)
                    {
                        strNumToBin.Insert(0, '0');
                        strNumToBin.Insert(0, '1');
                    }

                    return strNumToBin.ToString();
                }
                else
                {
                    return "Valor Invalido";
                }
            }
            else
            {
                return "Valor Invalido";
            }

        }

        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }
        public Operando()
        {
            Numero = 0.ToString();
        }
        public Operando(double numero)
        {
            Numero = numero.ToString();
        }
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }

        public static double operator +(Operando n1, Operando n2) { return n1.numero + n2.numero;}
        public static double operator - (Operando n1, Operando n2) { return n1.numero - n2.numero; }
        public static double operator / (Operando n1, Operando n2){
            if (n2.numero == 0) {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
        public static double operator * (Operando n1, Operando n2) { return n1.numero * n2.numero; }

        private double ValidarOperando(string strNumero)
        {
            int i = 0;
            int largo = strNumero.Trim().Length;            

            if (largo == 0) 
            {
                return 0;
            }
                        
            while ( i < largo)
            {
                if (!Char.IsDigit(strNumero[i]))
                {
                    return 0;
                }
                i++;
            }

            return Double.Parse(strNumero);
        }
    }
}
