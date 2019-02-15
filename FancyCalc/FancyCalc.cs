using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalc
{
    public class FancyCalcEnguine
    {

        public double Add(int a, int b)
        {
            return a + b;
        }


        public double Subtract(int a, int b)
        {
            return a - b;
        }


        public double Multiply(int a, int b)
        {
            return a * b;
        }

        //generic calc method. usage: "10 + 20"  => result 30 
        public double Culculate(string expression)
        {
            if ( expression == null )
            {
                throw new ArgumentNullException();
            }
            string ready = "";
            string znak = "";
            char[] a = expression.ToCharArray();
                        
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsDigit(a[i]))
                {
                    ready += a[i].ToString();
                }
                else if (a[i].ToString() == "+" || a[i].ToString() == "-" || a[i].ToString() == "*" || a[i].ToString() == "/")
                {
                    znak = a[i].ToString();
                    ready += " ";
                }
            }

            string[] numbers = ready.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length != 2) throw new ArgumentException();
            List<double> number = new List<double>();
            foreach (var item in numbers) number.Add(double.Parse(item));

            return Rezult(number, znak);
        }

        double Rezult(List<double> listNumbers, string znakNumber)
        {
            double num1 = listNumbers[0];
            double num2 = listNumbers[1];
            if (znakNumber == "+")
            {
                return num1 + num2;
            }
            else if (znakNumber == "-")
            {
                return num1 - num2;
            }
            else if (znakNumber == "*")
            {
                return num1 * num2;
            }
            else
            {
                if (num2 == 0)
                {
                    throw new DivideByZeroException();
                }
                return num1 / num2;
            }

        }
    }
}
