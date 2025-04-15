using System;

class MathFunctionsProgram
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("//////////////////////////////////////////////////////////");
            Console.WriteLine("//           Math Functions Program                     //");
            Console.WriteLine("//////////////////////////////////////////////////////////");
            Console.WriteLine("1. Factorial");
            Console.WriteLine("2. Exponential");
            Console.WriteLine("3. Fibonacci");
            Console.WriteLine("4. Exit");
            Console.Write("Please choose an option (1-4): ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunFactorial();
                    break;
                case "2":
                    RunExponential();
                    break;
                case "3":
                    RunFibonacci();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void RunFactorial()
    {
        Console.WriteLine("\n/////////////////////////// Factorial ///////////////////////////");
        Console.Write("Please enter a natural number: ");

        try
        {
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Factorial of {number} is: {GetFactorial(number)}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid integer number!");
        }
    }

    static int GetFactorial(int number)
    {
        if (number == 0)
        {
            return 1;
        }
        else if (number < 0)
        {
            Console.WriteLine("Factorial is not defined for negative numbers.");
            return -1; 
        }
        else
        {
            return GetFactorial(number - 1) * number;
        }
    }

    static void RunExponential()
    {
        Console.WriteLine("\n/////////////////////////// Exponential ///////////////////////////");

        try
        {
            Console.Write("Please enter the base number: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter the exponent (power): ");
            int y = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{x}^{y} = {GetExponential(x, y)}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid integer numbers!");
        }
    }

    static int GetExponential(int x, int y)
    {
        if (y == 0)
        {
            return 1;
        }
        else if (y > 0)
        {
            return GetExponential(x, y - 1) * x;
        }
        else
        {
            Console.WriteLine("Negative exponents not supported in this implementation.");
            return -1;
        }
    }

    static void RunFibonacci()
    {
        Console.WriteLine("\n/////////////////////////// Fibonacci ///////////////////////////");
        Console.Write("Please enter the position in Fibonacci sequence: ");

        try
        {
            int num = Convert.ToInt32(Console.ReadLine());

            if (num < 0)
            {
                Console.WriteLine("Please enter a non-negative number!");
            }
            else
            {
                Console.WriteLine($"Fibonacci({num}) = {Fibonacci(num)}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid integer number!");
        }
    }

    static int Fibonacci(int n)
    {
        if (n == 0)
            return 0;
        else if (n == 1)
            return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}