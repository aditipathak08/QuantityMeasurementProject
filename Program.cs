using System;

class Program
{
    static void Main()
    {
        // Create weight objects
        QuantityWeight w1 = new QuantityWeight(1, WeightUnit.KILOGRAM);
        QuantityWeight w2 = new QuantityWeight(1000, WeightUnit.GRAM);

        // Check equality
        Console.WriteLine(w1.Equals(w2));
        // Output: true

        // Convert 1 kg to grams
        QuantityWeight converted = w1.ConvertTo(WeightUnit.GRAM);

        // Add weights
        QuantityWeight sum = w1.Add(w2);

        Console.WriteLine("Converted: " + converted);
        Console.WriteLine("Sum: " + sum);
    }
}