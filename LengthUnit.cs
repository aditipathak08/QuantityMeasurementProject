public class LengthUnit : IMeasurable
{
    private double factor;
    private string name;

    public LengthUnit(double factor, string name)
    {
        this.factor = factor;
        this.name = name;
    }

    public double getConversionFactor()
    {
        return factor;
    }

    public double convertToBaseUnit(double value)
    {
        return value * factor;
    }

    public double convertFromBaseUnit(double value)
    {
        return value / factor;
    }

    public string getUnitName()
    {
        return name;
    }

    public static LengthUnit FEET = new LengthUnit(1.0, "FEET");
    public static LengthUnit INCHES = new LengthUnit(1.0 / 12, "INCHES");
}