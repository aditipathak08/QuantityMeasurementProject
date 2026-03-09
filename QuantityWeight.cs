using System;

// Class to represent a weight value
public class QuantityWeight
{
    private double value;     // weight number
    private WeightUnit unit;  // unit (kg, g, lb)

    // Constructor to create weight object
    public QuantityWeight(double value, WeightUnit unit)
    {
        this.value = value;
        this.unit = unit;
    }

    // Compare two weight objects
    public override bool Equals(object obj)
    {
        // check if object is null
        if (obj == null)
            return false;

        // check if object type is correct
        if (!(obj is QuantityWeight))
            return false;

        // convert object
        QuantityWeight other = (QuantityWeight)obj;

        // convert both values to kilogram
        double v1 = WeightUnitHelper.ToKilogram(this.value, this.unit);
        double v2 = WeightUnitHelper.ToKilogram(other.value, other.unit);

        // check if values are equal
        return v1 == v2;
    }

    // Convert weight to another unit
    public QuantityWeight ConvertTo(WeightUnit targetUnit)
    {
        // convert current value to kilogram
        double kg = WeightUnitHelper.ToKilogram(this.value, this.unit);

        // convert kilogram to target unit
        double newValue = WeightUnitHelper.FromKilogram(kg, targetUnit);

        // return new object
        return new QuantityWeight(newValue, targetUnit);
    }

    // Add two weight values
    public QuantityWeight Add(QuantityWeight other)
    {
        // convert both values to kilogram
        double v1 = WeightUnitHelper.ToKilogram(this.value, this.unit);
        double v2 = WeightUnitHelper.ToKilogram(other.value, other.unit);

        // add them
        double sum = v1 + v2;

        // convert result back to first unit
        double result = WeightUnitHelper.FromKilogram(sum, this.unit);

        // return new object
        return new QuantityWeight(result, this.unit);
    }
}