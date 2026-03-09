using System;

class Program
{
    static void Main()
    {
        // Length example
        Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
        Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(12, LengthUnit.INCHES);

        var result = q1.Add(q2);

        Console.WriteLine("Addition Result: " + result);

        // Subtraction
        var sub = q1.Subtract(q2);
        Console.WriteLine("Subtraction Result: " + sub);

        // Division
        double div = q1.Divide(q2);
        Console.WriteLine("Division Result: " + div);
    }
}