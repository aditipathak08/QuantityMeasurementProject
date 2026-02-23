using System;

public enum LengthUnit
{
    FEET,
    INCH
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
        if (unit == LengthUnit.FEET)
            return value;

        if (unit == LengthUnit.INCH)
            return value / 12.0;

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