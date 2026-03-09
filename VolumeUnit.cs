// Volume units class
public class VolumeUnit : IMeasurable
{
    private double factor;

    public VolumeUnit(double factor)
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

    public static VolumeUnit LITRE = new VolumeUnit(1);
    public static VolumeUnit MILLILITRE = new VolumeUnit(0.001);
    public static VolumeUnit GALLON = new VolumeUnit(3.78541);
}