// Length units class
public class LengthUnit : IMeasurable
{
    private double factor;

    public LengthUnit(double factor)
    {
        this.factor = factor;
    }

    public double convertToBaseUnit(double value)
    {
        return value * factor;
    }

    public double convertFromBaseUnit(double value)
    {
        return value / factor;
    }

    public static LengthUnit FEET = new LengthUnit(1);
    public static LengthUnit INCHES = new LengthUnit(1.0 / 12);
}