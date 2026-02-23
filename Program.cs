class Program
{
    static void Main()
    {
        QuantityLength a = new QuantityLength(1, LengthUnit.FEET);
        QuantityLength b = new QuantityLength(12, LengthUnit.INCH);

        Console.WriteLine("Default add (UC6): " + a.Add(b));
        Console.WriteLine("Target FEET: " + a.Add(b, LengthUnit.FEET));
        Console.WriteLine("Target INCH: " + a.Add(b, LengthUnit.INCH));
        Console.WriteLine("Target YARD: " + a.Add(b, LengthUnit.YARD));
    }
}