// Interface for measurement units
public interface IMeasurable
{
    // convert value to base unit
    double convertToBaseUnit(double value);

    // convert value from base unit
    double convertFromBaseUnit(double value);
}