// Weight units class
public class Weight: IMeasurable
{
    private double factor;

    public Weight(double factor)
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

    public static Weight KILOGRAM = new Weight(1);
    public static Weight GRAM = new Weight(0.001);
}