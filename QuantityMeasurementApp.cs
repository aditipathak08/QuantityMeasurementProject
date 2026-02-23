using System;
class QuantityMeasurementApp
{
    public class Feet//5 ft table1 equals 5 ft table2
    {
        private double value;

        public Feet(double value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Feet))
                return false;

            Feet other = (Feet)obj;

            return this.value == other.value;
        }
    }
    public class Inches//5 inches table1 equals 5 inches table2
    {
        private double value;

        public Inches(double value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)//we override because == compares references and not values
        {
            if (obj == null)
                return false;

            if (!(obj is Inches))
                return false;

            Inches other = (Inches)obj;

            return this.value == other.value;
        }
    }
    public static bool CheckFeet(double v1, double v2)
    {
        Feet f1 = new Feet(v1);
        Feet f2 = new Feet(v2);

        return f1.Equals(f2);
    }
    public static bool CheckInches(double v1, double v2)
    {
        Inches i1 = new Inches(v1);
        Inches i2 = new Inches(v2);

        return i1.Equals(i2);
    }

    static void Main()
    {
        bool feetResult = CheckFeet(1.0, 1.0);
        Console.WriteLine("Feet Equal? " + feetResult);

        bool inchesResult = CheckInches(1.0, 1.0);
        Console.WriteLine("Inches Equal? " + inchesResult);
    }
}