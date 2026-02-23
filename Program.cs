using System;

class Program
{
    static void Main()
    {
        QuantityLength q1 = new QuantityLength(1.0, LengthUnit.YARD);
        QuantityLength q2 = new QuantityLength(3.0, LengthUnit.FEET);

        Console.WriteLine("1 Yard == 3 Feet  " + q1.Equals(q2));

        QuantityLength q3 = new QuantityLength(1.0, LengthUnit.YARD);
        QuantityLength q4 = new QuantityLength(36.0, LengthUnit.INCH);

        Console.WriteLine("1 Yard == 36 Inches  " + q3.Equals(q4));

        QuantityLength q5 = new QuantityLength(1.0, LengthUnit.CENTIMETER);
        QuantityLength q6 = new QuantityLength(0.393701, LengthUnit.INCH);

        Console.WriteLine("1 CM == 0.393701 Inch  " + q5.Equals(q6));
    }
}