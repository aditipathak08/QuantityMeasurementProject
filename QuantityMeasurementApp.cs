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

    private static double ToFeet(double value, LengthUnit unit)
    {
        if (unit == LengthUnit.FEET)
            return value;

        if (unit == LengthUnit.INCH)
            return value / 12;

        if (unit == LengthUnit.YARD)
            return value * 3;

        if (unit == LengthUnit.CENTIMETER)
            return (value * 0.393701) / 12;

        return 0;
    }

    public static double Convert(double value, LengthUnit from, LengthUnit to)
    {
        double inFeet = ToFeet(value, from);

        if (to == LengthUnit.FEET)
            return inFeet;

        if (to == LengthUnit.INCH)
            return inFeet * 12;

        if (to == LengthUnit.YARD)
            return inFeet / 3;

        if (to == LengthUnit.CENTIMETER)
            return (inFeet * 12) / 0.393701;

        return 0;
    }

    public QuantityLength Add(QuantityLength other)
    {
        double totalFeet =
            ToFeet(this.value, this.unit) +
            ToFeet(other.value, other.unit);

        double result = Convert(totalFeet, LengthUnit.FEET, this.unit);

        return new QuantityLength(result, this.unit);
    }

    public QuantityLength Add(QuantityLength other, LengthUnit targetUnit)
    {
        if (other == null)
            throw new ArgumentException("Null value");

        double totalFeet =
            ToFeet(this.value, this.unit) +
            ToFeet(other.value, other.unit);

        double result = Convert(totalFeet, LengthUnit.FEET, targetUnit);

        return new QuantityLength(result, targetUnit);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (!(obj is QuantityLength))
            return false;

        QuantityLength other = (QuantityLength)obj;

        return ToFeet(this.value, this.unit) ==
               ToFeet(other.value, other.unit);
    }

    public override string ToString()
    {
        return value + " " + unit;
    }
}

