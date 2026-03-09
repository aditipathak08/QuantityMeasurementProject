using System;

class Program
{
    static void Main(string[] args)
    {
        // length example
        Quantity<LengthUnit> q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
        Quantity<LengthUnit> q2 = new Quantity<LengthUnit>(6, LengthUnit.INCHES);

        // subtraction
        var sub = q1.subtract(q2);
        Console.WriteLine("Subtract: " + sub);

        // subtraction with target unit
        var sub2 = q1.subtract(q2, LengthUnit.INCHES);
        Console.WriteLine("Subtract in inches: " + sub2);

        // division
        double ratio = q1.divide(q2);
        Console.WriteLine("Division: " + ratio);

        // weight example
        Quantity<Weight> w1 = new Quantity<Weight>(10, Weight.KILOGRAM);
        Quantity<Weight>w2 = new Quantity<Weight>(5000, Weight.GRAM);

        Console.WriteLine("Weight subtract: " + w1.subtract(w2));

        // volume example
        Quantity<VolumeUnit> v1 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);
        Quantity<VolumeUnit> v2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRE);

        Console.WriteLine("Volume subtract: " + v1.subtract(v2));
    }
}