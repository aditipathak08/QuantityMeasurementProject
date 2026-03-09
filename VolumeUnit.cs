// class for volume units
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

    public static VolumeUnit LITRE = new VolumeUnit(1.0);
    public static VolumeUnit MILLILITRE = new VolumeUnit(0.001);
}