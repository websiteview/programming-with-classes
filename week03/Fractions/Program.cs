using System;

class Program
{
    static void Main(string[] args)
    {
        //Test Constructor 1
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString()); // 1/1
        Console.WriteLine(f1.GetDecimalValue());   // 1

        //Test Constructor 2
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString()); // 5/1
        Console.WriteLine(f2.GetDecimalValue());   // 5

        //Test Constructor 3
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString()); // 3/4
        Console.WriteLine(f3.GetDecimalValue());   // 0.75

        //Another test with 1/3
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString()); // 1/3
        Console.WriteLine(f4.GetDecimalValue());   // 0.333...

        //Test Getters and Setters
        f4.SetTop(2);
        f4.SetBottom(5);
        Console.WriteLine(f4.GetFractionString()); // 2/5
        Console.WriteLine(f4.GetDecimalValue());   // 0.4
    }
}
