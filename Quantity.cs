// Generic Quantity class
public class Quantity<T> where T : IMeasurable
{
    private double value;
    private T unit;

    // constructor
    public Quantity(double value, T unit)
    {
        this.value = value;
        this.unit = unit;
    }

    // check equality
    public override bool Equals(object obj)
    {
        Quantity<T> other = obj as Quantity<T>;

        if (other == null)
            return false;

        // convert both values to base unit
        double v1 = unit.convertToBaseUnit(value);
        double v2 = other.unit.convertToBaseUnit(other.value);

        return v1 == v2;
    }

    // -----------------------------
    // SUBTRACTION
    // -----------------------------

    // subtract and return result in same unit
    public Quantity<T> subtract(Quantity<T> other)
    {
        // convert both to base unit
        double v1 = unit.convertToBaseUnit(value);
        double v2 = other.unit.convertToBaseUnit(other.value);

        // subtract
        double resultBase = v1 - v2;

        // convert result back to this unit
        double result = unit.convertFromBaseUnit(resultBase);

        return new Quantity<T>(result, unit);
    }

    // subtract and return in target unit
    public Quantity<T> subtract(Quantity<T> other, T targetUnit)
    {
        double v1 = unit.convertToBaseUnit(value);
        double v2 = other.unit.convertToBaseUnit(other.value);

        double resultBase = v1 - v2;

        double result = targetUnit.convertFromBaseUnit(resultBase);

        return new Quantity<T>(result, targetUnit);
    }

    // -----------------------------
    // DIVISION
    // -----------------------------

    // divide two quantities
    public double divide(Quantity<T> other)
    {
        double v1 = unit.convertToBaseUnit(value);
        double v2 = other.unit.convertToBaseUnit(other.value);

        if (v2 == 0)
            throw new System.ArithmeticException("Cannot divide by zero");

        return v1 / v2;
    }
}