using System;

using static Calculator.Go;
using System.Text.RegularExpressions;

namespace Calculator
{
    class PerformOperation
    {

        static void Main(string[] args)
        {
            char l = 'д';
            while (l == 'д')
            {
                Information();
                Console.Write("Введите выражение: ");
             

                string pattern = @"[0-9]|\[([^\[\]]+)\]";//для дальнейшей проверки на буквы или любые недопустимые символы
               
                result = '(' + Console.ReadLine().Replace(" ", "") + ')';
 if (Regex.IsMatch(result, pattern, RegexOptions.IgnoreCase)) //проверка
                {
                    int o;
                    while (FindBrackets(out o))
                    {
                        Calcul();
                        result = result.Insert(o, VScobcah);
                    }
                    Console.WriteLine("Ответ: " + result);
                }
                else
               { Console.WriteLine("Это не число!"); }

                Console.WriteLine("Вы хотите продолжить работу с калькулятором? (д/н)");
                l = Convert.ToChar(Console.ReadLine());
            }
            
            Console.Out.Close();
        }
    }
}

