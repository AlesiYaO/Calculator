using System;


namespace Calculator
{
    public class Go
    {
   
        public static string result;
        public static string VScobcah;
     
        public static void Information()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("\t\tКОНСОЛЬНЫЙ КАЛЬКУЛЯТОР");
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Операции: сложение, вычитание, умножение и деление.");
            Console.WriteLine("Приоритеты можно изменять с помощью скобок.");
            Console.WriteLine("Дробная часть отделяется запятой.");
            Console.WriteLine("Введите, например, 80*(6-2)-500/5 и нажмите Enter");
            Console.WriteLine("Для выхода из калькулятора нажмите 'н'");
            Console.WriteLine("**********************************************************");
        }

        public static bool NotOperator(int j)
        {
            return VScobcah[j] != '+' && VScobcah[j] != '-' && VScobcah[j] != '*' && VScobcah[j] != '/';
        }

        public static double GetLeftOperand(int i)
        {
            
                string LeftOperand = "";
                for (int j = i - 1; j >= 0; j--)
                    if (NotOperator(j))
                        LeftOperand = VScobcah[j] + LeftOperand;
                    else
                        break;
                return double.Parse(LeftOperand);
          
        }

        public static double GetRightOperand(int i)
        {
            string RightOperand = "";
            for (int j = i + 1; j < VScobcah.Length; j++)
                if (NotOperator(j))
                    RightOperand += VScobcah[j];
                else
                    break;
            return double.Parse(RightOperand);
        }

        public static void ReplaceExp(int i, double ToThis)
        {
            int FromI = 0;
            int ToI = VScobcah.Length - 1;
            for (int j = i - 1; j >= 0; j--)
                if (NotOperator(j))
                    FromI = j;
                else
                    break;
            for (int j = i + 1; j < VScobcah.Length; j++)
                if (NotOperator(j))
                    ToI = j;
                else
                    break;
            VScobcah = VScobcah.Replace(VScobcah.Substring(FromI, ToI - FromI + 1), ToThis.ToString());
        }

        public static void vibUmnDel(int i)
        {
            double UmnogDelen;
            if (VScobcah[i] == '*')
                UmnogDelen = GetLeftOperand(i) * GetRightOperand(i);
            else
                UmnogDelen = GetLeftOperand(i) / GetRightOperand(i);
            ReplaceExp(i, UmnogDelen);
            Calcul();
        }

        public static void vibPlMin(int i)
        {
            double PlMin;
            if (VScobcah[i] == '+')
                PlMin = GetLeftOperand(i) + GetRightOperand(i);
            else
                PlMin = GetLeftOperand(i) - GetRightOperand(i);
            ReplaceExp(i, PlMin);
            Calcul();
        }

        public static void Calcul()
        {
            int i;
            for (i = 0; i < VScobcah.Length; i++)
                if (VScobcah[i] == '*' || VScobcah[i] == '/')
                {
                    vibUmnDel(i);
                    return;
                }
            for (i = 0; i < VScobcah.Length; i++)
                if (VScobcah[i] == '+' || VScobcah[i] == '-')
                {
                    vibPlMin(i);
                    return;
                }
        }
        public static bool FindBrackets(out int o)
        {
            o = 0;
            if (result.IndexOf('(') != -1)
            {
                int ClosedBracket = result.IndexOf(')');
                int OpenBracket = 0;
                for (int i = ClosedBracket - 1; i >= 0; i--)
                    if (result[i] == '(')
                    {
                        OpenBracket = i;
                        VScobcah = result.Substring(OpenBracket + 1, ClosedBracket - OpenBracket - 1);
                        o = OpenBracket;
                        result = result.Remove(OpenBracket, ClosedBracket - OpenBracket + 1);
                        break;
                    }
                return true;
            }
            return false;
        }
    }

}
