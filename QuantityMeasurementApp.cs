using System;

class QuantityMeasurementApp
{
    public class Feet
    {
        private double value;

        public Feet(double value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)//== compares reference and not values
        {
            if (obj == null)
                return false;
            if (!(obj is Feet))
                return false;//means object==feet which is true
            Feet other = (Feet)obj;//converting that object into feet
            return this.value == other.value;//val1==val2
     }
    }

    static void Main()
    {
        Feet f1 = new Feet(1.0);
        Feet f2 = new Feet(1.0);

        bool result = f1.Equals(f2);

        Console.WriteLine(result);
    }
}