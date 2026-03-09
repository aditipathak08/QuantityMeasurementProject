public class WeightUnits : IMeasurable
{
    private double factor;
    private string name;

    public WeightUnits(double factor, string name)
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

    public static WeightUnits KILOGRAM = new WeightUnits(1.0, "KILOGRAM");
    public static WeightUnits GRAM = new WeightUnits(0.001, "GRAM");
}