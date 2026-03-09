using System;

// Generic class that works for any unit
public class Quantity<U> where U : IMeasurable
{
    private double value;
    private U unit;

    public Quantity(double value, U unit)
    {
        this.value = value;
        this.unit = unit;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        Quantity<U> other = obj as Quantity<U>;

        if (other == null)
            return false;

        double v1 = unit.convertToBaseUnit(value);
        double v2 = other.unit.convertToBaseUnit(other.value);

        return v1 == v2;
    }

    public override string ToString()
    {
        return $"Quantity({value}, {unit.getUnitName()})";
    }
}