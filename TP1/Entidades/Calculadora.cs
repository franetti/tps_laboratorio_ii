using System;

namespace Entidades
{
    public static class Calculadora
    {
        private static char ValidarOperador(char operador)
        {
            if (operador != '+' && operador != '-' && operador != '/' && operador != '*')
            {
                return '+';
            }            

            return operador;
        }

        public static double Operar (Operando num1, Operando num2, char operador)
        {
            char operadorCheck = ValidarOperador(operador);
            
            switch (operadorCheck)
            {
                case '+':
                    return num1 + num2;                    
                case '-':
                    return num1 - num2;                    
                case '/':
                    return num2 / num2;                    
                case '*':
                    return num1 * num2;                     
            }
            return 1;
        }
    }
}
