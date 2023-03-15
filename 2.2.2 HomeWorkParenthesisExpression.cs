using System;

namespace HWParenthesisExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            int count = 0;
            int exception = 0;
            int lengthText;
            int counterBuffer = 0;

            // 1( 2( 3( )3 )2 2( 3( )3 )2 )1
            Console.WriteLine("Введите скобочное выражение:");
            text = Console.ReadLine();

            lengthText = text.Length;

            for (int i = 0; i < lengthText; i++)
            {
                if (text[i] == '(')
                {
                    exception++;
                }
                else if (text[i] == ')')
                {
                    if (exception == 0)
                    {
                        Console.WriteLine("Выражение не корректно!");
                        return;
                    }
                    else if (i != lengthText - 1 && text[i + 1] == ')')
                    {
                        count++;
                    }
                    else if (i != lengthText - 1 && text[i + 1] == '(')
                    {
                        if (exception != 1)
                        {
                            count++;
                        }                        
                        if (count > counterBuffer)
                        {
                            counterBuffer = count;
                        }
                        count = 0;
                    }
                    if (i == lengthText - 1 && counterBuffer > count)
                    {
                        count = counterBuffer;
                    }

                    exception--;
                }
           }
            if (exception == 0)
            {
                Console.WriteLine($"Выражение: {text} корректно. \n Максимальная глубина вложенности скобок: {count + 1} ");
            }
            else
            {
                Console.WriteLine("Выражение не корректно!");
            }
        }
    }
}
