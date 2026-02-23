class Program
{
    static void Main()
    {
        Console.WriteLine("1 foot to inches = " +
            QuantityLength.Convert(1, LengthUnit.FEET, LengthUnit.INCH));

        Console.WriteLine("3 yards to feet = " +
            QuantityLength.Convert(3, LengthUnit.YARD, LengthUnit.FEET));

        Console.WriteLine("36 inches to yard = " +
            QuantityLength.Convert(36, LengthUnit.INCH, LengthUnit.YARD));

        QuantityLength q1 = new QuantityLength(1, LengthUnit.YARD);
        QuantityLength q2 = new QuantityLength(3, LengthUnit.FEET);

        Console.WriteLine("1 yard == 3 feet  " + q1.Equals(q2));
    }
}