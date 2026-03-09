// Generic Quantity class
public class Quantity<T> where T : IMeasurable
{
    private double value;
    private T unit;

    public Quantity(double value, T unit)
    {
        this.value = value;
        this.unit = unit;
    }

    // Central method for arithmetic (DRY principle)
    private double performBaseArithmetic(Quantity<T> other, string operation)
    {
        // convert both values to base unit
        double v1 = unit.convertToBaseUnit(value);
        double v2 = other.unit.convertToBaseUnit(other.value);

        if (operation == "ADD")
            return v1 + v2;

        if (operation == "SUBTRACT")
            return v1 - v2;

        if (operation == "DIVIDE")
        {
            if (v2 == 0)
                throw new System.ArithmeticException("Cannot divide by zero");

            return v1 / v2;
        }

        return 0;
    }

    // ADD
    public Quantity<T> Add(Quantity<T> other)
    {
        double baseResult = performBaseArithmetic(other, "ADD");

        double finalValue = unit.convertFromBaseUnit(baseResult);

        return new Quantity<T>(finalValue, unit);
    }

    // SUBTRACT
    public Quantity<T> Subtract(Quantity<T> other)
    {
        double baseResult = performBaseArithmetic(other, "SUBTRACT");

        double finalValue = unit.convertFromBaseUnit(baseResult);

        return new Quantity<T>(finalValue, unit);
    }

    // DIVIDE
    public double Divide(Quantity<T> other)
    {
        return performBaseArithmetic(other, "DIVIDE");
    }
}