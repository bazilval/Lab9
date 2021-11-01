using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Смоделируйте работу простого калькулятора. 
 * Программа должна запрашивать 2 числа, а затем – код операции 
 * (например, 1 – сложение, 2 – вычитание, 3 – произведение, 4 – частное). 
 * После этого на консоль выводится ответ. Используйте обработку исключений для защиты от ввода некорректных данных.*/
namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator();
            PressToExit();
        }
        static void Calculator()
        {
            int a, b, op = 0;
            PrintLine("Вас приветствует калькулятор ОтВали!");

            a = IntInput("\nВведите целое число A: ");
            b = IntInput("\nВведите целое число B: ");

            PrintLine("\nВыберите код операции:");
            PrintLine("\t1 - сложение");
            PrintLine("\t2 - вычитание");
            PrintLine("\t3 - произведение");
            PrintLine("\t4 - частное");

            OperationInput(out op);

            switch (op)
            {
                case 1:
                    PrintLine($"\nРезультат: {a + b}.");
                    break;
                case 2:
                    PrintLine($"\nРезультат: {a - b}.");
                    break;
                case 3:
                    PrintLine($"\nРезультат: {a * b}.");
                    break;
                case 4:
                    try
                    {
                        double result = a / b;
                        PrintLine($"\nРезультат: {result}.");
                    }
                    catch (Exception e)
                    {
                        PrintLine(e.Message);
                        break;
                    }
                    break;
            }
        }
        static void OperationInput(out int op)
        {
            try
            {
                op = IntInput("\nВведите код операции: ");
                if (op < 1 || op > 4) throw new Exception("Значение вне диапазона от 1 до 4.");
            }
            catch (Exception e)
            {
                PrintLine(e.Message);
                OperationInput(out op);
            }
        }
        static int IntInput(string text)
        {
            Console.Write(text);
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                PrintLine("Ошибка ввода");
                return IntInput(text);
            }

        }
        static void PrintLine(string str)
        {
            Console.WriteLine(str);
        }
        static void PressToExit()
        {
            PrintLine("\nНажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
