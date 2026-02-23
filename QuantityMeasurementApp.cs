using System;

public enum LengthUnit
{
    FEET,
    INCH,
    YARD,
    CENTIMETER
}

public class QuantityLength
{
    private double value;
    private LengthUnit unit;

    public QuantityLength(double value, LengthUnit unit)
    {
        this.value = value;
        this.unit = unit;
    }
    private double ConvertToFeet()
    {
        if (unit == LengthUnit.FEET)//5 feet=5 feet
            return value;

        if (unit == LengthUnit.INCH)//60/12 feet
            return value / 12.0;

        if (unit == LengthUnit.YARD)//3*3 feet
            return value * 3.0;

        if (unit == LengthUnit.CENTIMETER)
        {
            // 1 cm = 0.3937 inch and inch/12=feet
            double inches = value * 0.393701;
            return inches / 12.0;
        }

        return 0;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (!(obj is QuantityLength))
            return false;

        QuantityLength other = (QuantityLength)obj;

        return this.ConvertToFeet() == other.ConvertToFeet();
    }
}