using System;

namespace DelegateAssignment
{
    // Delegate declaration
    public delegate void MathOperation(int a, int b);

    // Class containing mathematical methods
    class Calculator
    {
        public void Add(int a, int b)
        {
            Console.WriteLine("Addition = " + (a + b));
        }

        public void Subtract(int a, int b)
        {
            Console.WriteLine("Subtraction = " + (a - b));
        }

        public void Multiply(int a, int b)
        {
            Console.WriteLine("Multiplication = " + (a * b));
        }

        public void Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero");
            }
            else
            {
                Console.WriteLine("Division = " + (a / b));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.Write("Enter First Number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Second Number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nChoose Operation");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            MathOperation operation;

            switch (choice)
            {
                case 1:
                    operation = calculator.Add;
                    break;

                case 2:
                    operation = calculator.Subtract;
                    break;

                case 3:
                    operation = calculator.Multiply;
                    break;

                case 4:
                    operation = calculator.Divide;
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    return;
            }

            // Calling the selected method using delegate
            operation(a, b);

            Console.ReadKey();
        }
    }
}