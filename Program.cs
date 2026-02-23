class Program
{
    static void Main()
    {
        //  (UC5)
        Console.WriteLine("1 foot to inches = " +
            QuantityLength.Convert(1, LengthUnit.FEET, LengthUnit.INCH));

        Console.WriteLine("3 yards to feet = " +
            QuantityLength.Convert(3, LengthUnit.YARD, LengthUnit.FEET));

        // (UC4)
        QuantityLength q1 = new QuantityLength(1, LengthUnit.YARD);
        QuantityLength q2 = new QuantityLength(3, LengthUnit.FEET);
        Console.WriteLine("1 yard == 3 feet ? " + q1.Equals(q2));

        // (UC6)
        QuantityLength a = new QuantityLength(1, LengthUnit.FEET);
        QuantityLength b = new QuantityLength(12, LengthUnit.INCH);
        QuantityLength result1 = a.Add(b);
        Console.WriteLine("1 foot + 12 inches = " + result1);

        QuantityLength c = new QuantityLength(12, LengthUnit.INCH);
        QuantityLength d = new QuantityLength(1, LengthUnit.FEET);
        QuantityLength result2 = c.Add(d);
        Console.WriteLine("12 inches + 1 foot = " + result2);
    }
}