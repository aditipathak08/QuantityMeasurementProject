using System;

class Program
{
    static void Main()
    {
        QuantityLength q1 = new QuantityLength(1.0, LengthUnit.FEET);
        QuantityLength q2 = new QuantityLength(12.0, LengthUnit.INCH);

        bool result = q1.Equals(q2);

        Console.WriteLine("Are Equal? " + result);
    }
}